<template>
    <div class="d-flex flex-column align-items-center w-100">
        <top-bar></top-bar>
        <div class="d-flex justify-content-between col-6 mt-4">
            <dl class="row">
                <dt class="col-5">Data przejazdu</dt>
                <dd class="col-5">{{date}}</dd>
                <dt class="col-5">Stacja początkowa</dt>
                <dd class="col-5">{{fromName}}</dd>
                <dt class="col-5">Stacja docelowa</dt>
                <dd class="col-5">{{toName}}</dd>
                <dt class="col-5">Godzina odjazdu</dt>
                <dd class="col-5">{{fromTime}}</dd>
                <dt class="col-5">Godzina przyjazdu</dt>
                <dd class="col-5">{{toTime}}</dd>
                <dt class="col-5">Wartość zakupu</dt>
                <dd class="col-5">{{price}}</dd>
            </dl>

            <div class="border border-dark p-3 rounded col-6">  
                <div class="d-flex justify-content-between align-items-center border border-dark rounded p-2 m-1" v-for="pickedPlace in pickedPlacesData" :key="pickedPlace">
                    <div>Miejsce: {{pickedPlace.placeNumber}} | Wagon: {{pickedPlace.trainCartNumber}}</div>
                    <select v-model="pickedPlace.pricePercentage" class="form-select form-select-sm w-50">
                        <option v-bind:value="ticketType.pricePercentage" v-for="ticketType in ticketTypes" :key="ticketType.ticketTypeId">{{ticketType.name}}</option>
                    </select>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import TopBar from "../components/TopBar.vue";
import axios from 'axios'

export default {
    components: {
        TopBar,
    },
    name: "ConfirmTicketsPage",
    data: function () {
        return {
            fromStop: null,
            toStop: null,
            ticketTypes: null,
            normalPrice: -1,
            pickedPlacesData: []
        };
    },
    computed: {
        date: function() {
            if (this.fromStop == null || this.fromStop.stopDateTime == null)
                return ""
            return this.fromStop.stopDateTime.substring(0, 10)
        },
        fromName: function() {
            if (this.fromStop == null || this.fromStop.station == null)
                return ""

            return this.fromStop.station.name
        },
        toName: function() {
            if (this.toStop == null || this.toStop.station == null)
                return ""

            return this.toStop.station.name
        },
        fromTime: function() {
            if (this.fromStop == null || this.fromStop.stopDateTime == null)
                return ""
            return this.fromStop.stopDateTime.substring(11, 16)
        },
        toTime: function() {
            if (this.toStop == null || this.toStop.stopDateTime == null)
                return ""
            return this.toStop.stopDateTime.substring(11, 16)
        },
        price: function() {
            if (this.normalPrice < 0)
                return "???"

            var sum = 0
            this.pickedPlacesData.forEach(p => {
                sum += this.normalPrice * p.pricePercentage
            })

            return sum
        }  
    },
    props: {
        pickedPlaces: Array,
        fromId: Number,
        toId: Number,
        trainId: Number,
    },
    async mounted() {
        if (this.pickedPlaces == null || this.fromId == null || this.toId == null || this.trainId == null) {
            this.$router.push('/')
        }
       
        try {
            var responseFrom = await axios.get(
                "/stops/train/" + this.trainId + '/station/' + this.fromId
            );
            var responseTo = await axios.get(
                "/stops/train/" + this.trainId + '/station/' + this.toId
            );
            var ticketTypes = await axios.get(
                "/ticketTypes"
            );
            var responsePrice = await axios.get(
                "/price/" + this.trainId + "/" + this.fromId + "/" + this.toId
            )
        } catch {
            return;
        }

        this.fromStop = responseFrom.data
        this.toStop = responseTo.data
        this.ticketTypes = ticketTypes.data
        this.normalPrice = responsePrice.data.price

        this.pickedPlacesData = this.pickedPlaces
        this.pickedPlacesData.forEach(p => {
            this.$set(p, "pricePercentage", this.ticketTypes[0].ticketTypeId)
        })
    }
};
</script>

<style>
</style>
