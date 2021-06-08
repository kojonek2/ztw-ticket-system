<template>
    <div id="History" class="d-flex flex-column align-items-center mt-2 w-100">
        <top-bar></top-bar>
        <div v-if="error" class="alert alert-danger" role="alert">
            Searching failed!
        </div>
        <div v-if="success" class="alert alert-success" role="alert">
            Ok.
        </div>

        <hr>
        <history-details class="ms-5 me-5 col-6" :reservation="reservation" :tickets="tickets" />

    </div>
</template>

<script>
import TopBar from "../components/TopBar.vue";
import HistoryDetails from '../components/HistoryDetails';
import auth from "../auth";
import axios from 'axios'

export default {
    name: "HistoryDetailsPage",
    components: {
        TopBar,
        HistoryDetails,
    },
    data() {
        return {
            reservation: {},
            tickets: [],
        }
    },
    methods: {
        async getReservation() {
            try {
                const response = await axios.get("https://localhost:44365/reservations/" + this.$route.params.id, {
                headers: {
                    Authorization: `bearer ${auth.token}`
                }
            })
                this.reservation = await response.data;
            } catch (error) {
                console.log(error)
                //this.$router.push('/')
            }
        },
        async getTickets() {
            try {
                const response = await axios.get("https://localhost:44365/tickets/" + this.$route.params.id, {
                headers: {
                    Authorization: `bearer ${auth.token}`
                }
            })
                this.tickets = await response.data;
            } catch (error) {
                console.log(error)
                //this.$router.push('/')
            }
        },
    },
    mounted() {
        this.getReservation(),
        this.getTickets()
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
