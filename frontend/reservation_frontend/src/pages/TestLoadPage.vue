<template>
    <div class="d-flex flex-column align-items-center w-100">
        <top-bar></top-bar>

        <div class="d-flex justify-content-between col-6 mt-4">
            <div class="border border-dark p-3 rounded trainCarList mt-5">
                <div class="d-flex align-items-center border border-dark rounded p-2 m-1" v-for="trainCar in train.trainCars" :key="trainCar.trainCarsId">
                    <div>Wagon nr. {{trainCar.number}} | Wolne: x</div>
                    <button class="btn btn-primary btn-sm ms-2" v-if="trainCar.trainCarsId != trainCarId" v-on:click="pickTrainCar(trainCar.trainCarsId.toString())">Wybierz</button>
                    <div class="flex-grow-1 text-center btn btn-sm" v-else>wybrany</div>
                </div>
            </div>

            <div>
                Wybrane miejsca:
                <div class="border border-dark p-3 rounded trainPlacesList">
                    <div class="border border-dark rounded p-2 m-1 pre" v-for="place in pickedPlaces" :key="place.trainCartNumber.toString() + place.placeNumber.toString()">
                        Miejsce: {{place.placeNumber.toString().padStart(3, ' ')}} | Wagon: {{place.trainCartNumber.toString().padStart(3, ' ')}}
                    </div>
                </div>
            </div>
        </div>

        <div v-if="trainCarNumber != ''">Wagon nr. {{trainCarNumber}}</div>
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
    name: "TestLoadPage",
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
                        places.push({ trainCartNumber: tc.number, placeNumber: p.number})
                    }
                })
            })

            return places
        }
    },
    methods: {
        pickTrainCar: function(val) {
            this.trainCarId = val
        }
    },
    async mounted() {
        try {
            var response = await axios.get(
                "/train/" + this.$route.params.name
            );
        } catch {
            return;
        }

        this.train = response.data
        this.train.trainCars.sort((a, b) => {
            return a.order - b.order;
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
</style>
