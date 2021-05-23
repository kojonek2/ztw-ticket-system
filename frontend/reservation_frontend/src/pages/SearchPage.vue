<template>
    <div id="Search" class="col-6 mt-2">
        <top-bar></top-bar>
        <div v-if="error" class="alert alert-danger" role="alert">
            Searching failed!
        </div>
        <div v-if="success" class="alert alert-success" role="alert">
            Ok.
        </div>

        <search-form class="ms-5 me-5" :stationsSource="stations" @save:search="sendSearch" />
        <hr>
        <search-result-table v-if="fromStation != '' && toStation != ''" class="ms-5 me-5" :connSource="connections" :fromStation="fromStation" :toStation="toStation" />

    </div>
</template>

<script>
import TopBar from "../components/TopBar.vue";
import SearchForm from '../components/SearchForm';
import SearchResultTable from '../components/SearchResultTable';

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
            toStation: '',
        };
    },
    methods: {
        async getData() {
            try {
                const responseStations = await fetch("https://localhost:44365/stations");
                this.stations = await responseStations.json();
            } catch (error) {
                console.log(error)
                this.$router.push('/')
            }
        },
        async sendSearch(from, to, date) {
            this.fromStation = this.stations.find(s => s.stationId == from).name;
            this.toStation = this.stations.find(s => s.stationId == to).name;

            const responseStations = await fetch("https://localhost:44365/connections/" + from + "/" + to + "/" + date);
            this.connections = await responseStations.json();
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
