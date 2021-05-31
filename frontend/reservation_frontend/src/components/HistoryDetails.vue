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
                <dd class="col-sm-5">
                    ???
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
            @click="$router.push('/history')" class="my-5 btn btn-outline-success">&laquo; 
            Powrót
        </button>
    </div>
</template>

<script>
export default {
    name: "history-details",
    props: {
        reservation: {},
        tickets: {},
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
    },
};
</script>

<style scoped></style>
