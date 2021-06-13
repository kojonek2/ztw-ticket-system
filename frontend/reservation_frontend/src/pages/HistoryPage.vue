<template>
    <div id="History" class="d-flex flex-column align-items-center mt-2 w-100">
        <top-bar></top-bar>
        
        <hr>
        <history-table class="ms-5 me-5 col-6" :reservationsSource="reservations" />

    </div>
</template>

<script>
import TopBar from "../components/TopBar.vue";
import HistoryTable from '../components/HistoryTable';
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
                const responseStations = await axios.get("/reservations")
                this.reservations = await responseStations.data;
            } catch (error) {
                console.log(error)
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
