<template>
    <div id="history-details">
        <div>
            <dl class="row">
                <dt class="col-sm-4">
                    Identyfikator rezerwacji
                </dt>
                <dd class="col-sm-5">
                    {{ reservation.id }}
                </dd>
                <dt class="col-sm-4">
                    Data przejazdu
                </dt>
                <dd class="col-sm-5">
                    {{ getDate(reservation.dateFrom) }}
                </dd>
                <dt class="col-sm-4">
                    Stacja początkowa
                </dt>
                <dd class="col-sm-5">
                    {{ reservation.from }}
                </dd>
                <dt class="col-sm-4">
                    Stacja docelowa
                </dt>
                <dd class="col-sm-5">
                    {{ reservation.to }}
                </dd>
                <dt class="col-sm-4">
                    Godzina odjazdu
                </dt>
                <dd class="col-sm-5">
                    {{ getTime(reservation.dateFrom) }}
                </dd>
                <dt class="col-sm-4">
                    Godzina przyjazdu
                </dt>
                <dd class="col-sm-5">
                    {{ getTime(reservation.dateTo) }}
                </dd>
                <dt class="col-sm-4">
                    Wartość zakupu
                </dt>
                <br>
                <dd class="col-sm-5">
                    <b>{{this.price}} PLN</b>
                </dd>
            </dl>
        </div>

        <br />

        

        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Identyfikator biletu</th>
                    <th scope="col">Miejsce</th>
                    <th scope="col">Wagon</th>
                    <th scope="col">Rodzaj biletu</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="ticket in tickets" :key="ticket.id">
                    <td scope="row" class="align-middle">{{ ticket.id }}</td>
                    <td scope="row" class="align-middle">{{ ticket.place }}</td>
                    <td scope="row" class="align-middle">{{ ticket.car }}</td>
                    <td scope="row" class="align-middle">{{ ticket.sort }}</td>
                </tr>
            </tbody>
        </table>

        <button 
            type="button"    
            @click="$router.push('/history')" 
            class="btn btn-outline-success">
            Powrót
        </button>


        <button 
            type="button"   
            :disabled="!reservation.isAbleToResign" 
            @click="resign()" 
            class="btn btn-danger ms-1">
            Anuluj rezerwację
        </button>

    </div>
</template>

<script>
import axios from 'axios'

export default {
    name: "history-details",
    props: {
        reservation: {},
        tickets: {},
        price: Number
    },
    methods: {
        getDate(dateStr) {
            var date = dateStr.split(' ')
            return date[0];
        },
        getTime(dateStr) {
            var date = dateStr.split(' ')
            return date[1];
        },
        async resign() {
            try {
                const response = await axios.get("/reservations/resign/" + this.reservation.id)
                this.reservation = await response.data;
            } catch (error) {
                console.log(error)
            }
            this.$router.push('/history')
        }
    },
};
</script>

<style scoped></style>
