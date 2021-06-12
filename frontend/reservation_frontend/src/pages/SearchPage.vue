<template>
    <div id="Search" class="d-flex flex-column align-items-center mt-2 w-100">
        <top-bar></top-bar>
        <div v-if="error" class="alert alert-danger" role="alert">
            Searching failed!
        </div>
        <div v-if="success" class="alert alert-success" role="alert">
            Ok.
        </div>
        <hr>
        <search-form class="ms-5 me-5 col-6" :stationsSource="stations" @save:search="sendSearch" />
        <hr>
        <search-result-table v-if="fromStation != '' && toStation != ''" class="ms-5 me-5 col-6" :connSource="connections" :fromStation="fromStation" :fromStationId="fromStationId" :toStation="toStation" :toStationId="toStationId" />

    </div>
</template>

<script>
import TopBar from "../components/TopBar.vue";
import SearchForm from '../components/SearchForm';
import SearchResultTable from '../components/SearchResultTable';
import axios from 'axios'

export default {
    name: "SearchPage",
    components: {
        TopBar,
        SearchResultTable,
        SearchForm,
    },
    data() {
        return {
            error: false,
            success: false,
            stations: {},
            connections: [],
            fromStation: '',
            fromStationId: -1,
            toStation: '',
            toStationId: -1,
        };
    },
    methods: {
        async getData() {
            try {
                const response = await axios.get("/stations")
                this.stations = await response.data;
            } catch (error) {
                console.log(error)
                this.$router.push('/')
            }
        },
        async sendSearch(from, to, date) {
            this.fromStation = this.stations.find(s => s.stationId == from).name;
            this.fromStationId = from;
            this.toStation = this.stations.find(s => s.stationId == to).name;
            this.toStationId = to;

            try {
                console.log("/connections/" + from + "/" + to + "/" + date)
                const response = await axios.get("/connections/" + from + "/" + to + "/" + date);
                this.connections = await response.data;
            } catch (error) {
                console.log(error)
                this.$router.push('/')
            }
        }
    },
    mounted() {
        this.getData()
    },
};
</script>

<style>
button {
    background: #009435;
    border: 1px solid #009435;
}
.small-container {
    max-width: 680px;
}
</style>
