<template>
    <div id="History" class="col-6 mt-2">
        <top-bar></top-bar>
        <div v-if="error" class="alert alert-danger" role="alert">
            Searching failed!
        </div>
        <div v-if="success" class="alert alert-success" role="alert">
            Ok.
        </div>

        <hr>
        <history-table class="ms-5 me-5" :reservationsSource="reservations" />

    </div>
</template>

<script>
import TopBar from "../components/TopBar.vue";
import HistoryTable from '../components/HistoryTable';
import auth from "../auth";
import axios from 'axios'

export default {
    name: "HistoryPage",
    components: {
        TopBar,
        HistoryTable,
    },
    data() {
        return {
            reservations: [],
        }
    },
    methods: {
        async getData() {
            try {
                //const responseStations = await fetch("https://localhost:44365/reservations");
                const responseStations = await axios.get("https://localhost:44365/reservations", {
                headers: {
                    Authorization: `bearer ${auth.token}`
                }
            })
                this.reservations = await responseStations.data;
            } catch (error) {
                console.log(error)
                //this.$router.push('/')
            }
        },
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
