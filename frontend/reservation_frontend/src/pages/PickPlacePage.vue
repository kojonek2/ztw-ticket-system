<template>
    <div class="d-flex flex-column align-items-center w-100">
        <top-bar></top-bar>

        <div class="d-flex justify-content-between col-6 mt-4">
            <div>
                Dostępne wagony:
                <hr>
                <div class="border border-dark p-3 rounded trainCarList">
                    <div class="d-flex align-items-center border border-dark rounded p-2 m-1" v-for="trainCar in train.trainCars" :key="trainCar.trainCarsId">
                        <div class="pre">Wagon nr. {{trainCar.number}} | Wolne: {{getFreePlaces(trainCar)}}</div>
                        <button class="btn btn-primary btn-sm ms-2" v-if="trainCar.trainCarsId != trainCarId" v-on:click="pickTrainCar(trainCar.trainCarsId)">Wybierz</button>
                        <div class="flex-grow-1 text-center btn btn-sm" v-else>wybrany</div>
                    </div>
                </div>
            </div>

            <div class="d-flex flex-column align-items-center ">
                <div>
                    Wybrane miejsca:
                    <hr>
                    <div class="border border-dark p-3 rounded trainPlacesList">
                        <div class="border border-dark rounded p-2 m-1 pre" v-for="place in pickedPlaces" :key="place.trainCartNumber.toString() + place.placeNumber.toString()">
                            Miejsce: {{place.placeNumber.toString().padStart(3, ' ')}} | Wagon: {{place.trainCartNumber.toString().padStart(3, ' ')}}
                        </div>
                    </div>
                </div>

                <router-link v-bind:class="{ disabled: pickedPlaces.length <= 0 }" class="btn btn-success mt-3" 
                :to="{ 
                    name: 'confirmTicket', 
                    params: {
                        pickedPlaces: pickedPlaces,
                        fromId: $route.params.fromId,
                        toId: $route.params.toId,
                        trainId: $route.params.trainId,
                    }
                }">
                    Kup bilet
                </router-link>
                
            </div>
        </div>
        <hr>
        <div v-if="trainCarNumber != ''"><h5>Wagon nr. {{trainCarNumber}}</h5></div>
        <pick-place-canvas v-bind:train="train" :trainCarId="trainCarId" />
    </div>
</template>

<script>
import TopBar from "../components/TopBar.vue";
import PickPlaceCanvas from "../components/PickPlaceCanvas.vue"
import axios from 'axios'

export default {
    components: {
        TopBar,
        PickPlaceCanvas,
    },
    name: "PickPlacePage",
    data: function () {
        return {
            train: null,
            trainCarId: "-1",
        };
    },
    computed: {
        trainCarNumber: function() {
            if (this.train == null)
                return ""
            
            var trainCar = this.train.trainCars.find(tc => tc.trainCarsId == this.trainCarId)
            if (trainCar == null)
                return ""

            return trainCar.number
        },
        pickedPlaces: function() {
            if (this.train == null)
                return []

            const places = []
            this.train.trainCars.forEach(tc => {
                tc.car.places.forEach(p => {
                    if (p.picked) {
                        places.push({ trainCartNumber: tc.number, placeNumber: p.number, placeId: p.placeId, trainCarsId: tc.trainCarsId})
                    }
                })
            })

            return places
        },
    },
    methods: {
        pickTrainCar: function(val) {
            this.trainCarId = val
        },
        getFreePlaces(trainCar) {
            var len = trainCar.car.places.filter(p => !p.occupied).length
            if(len < 10)
                return " " + len;
            else
                return len;
        }
    },
    async mounted() {
        try {
            var response = await axios.get(
                "/train/" + this.$route.params.trainId
            );
        } catch {
            return;
        }

        try {
            var responseOccupiedPlaces = await axios.get(
                "/train/" + this.$route.params.trainId + "/occupiedPlaces/" + this.$route.params.fromId + "/" + this.$route.params.toId
            );
        } catch {
            return;
        }

        this.train = response.data
        this.train.trainCars.sort((a, b) => {
            return a.order - b.order;
        })

        responseOccupiedPlaces.data.forEach(o => {
            var trainCar = this.train.trainCars.find(c => c.trainCarsId == o.trainCarId)
            if (trainCar != undefined) {

                var place = trainCar.car.places.find(p => p.placeId == o.placeId)
                if (place != undefined) {
                    this.$set(place, "occupied", true)
                }
            }
        })

        if (this.train.trainCars.length > 0)
            this.trainCarId = this.train.trainCars[0].trainCarsId
    },
};
</script>

<style>
.trainCarList {
    height: 200px;
    overflow: auto;
}

.trainPlacesList {
    height: 200px;
    width: 260px;
    overflow-y: scroll;
}

.pre {
    white-space: pre;
}

.disabled {
    opacity: 0.5;
    pointer-events: none;
}
</style>
