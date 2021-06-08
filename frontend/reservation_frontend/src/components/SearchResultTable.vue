<template>
    <div id="search-results-table">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Data</th>
                    <th scope="col">Godzina</th>
                    <th scope="col">Stacja początkowa</th>
                    <th scope="col">Stacja docelowa</th>
                    <th scope="col">Akcja</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="conn in connSource" :key="conn.stopId">
                    <td scope="row" class="align-middle">
                        <img src="../assets/train.png" height="70">
                    </td>
                    <td scope="row" class="align-middle">{{ getDate(conn.stopDateTime) }}</td>
                    <td scope="row" class="align-middle">{{ getTime(conn.stopDateTime) }}</td>
                    <td scope="row" class="align-middle">{{ fromStation }}</td>
                    <td scope="row" class="align-middle">{{ toStation }}</td>
                    <td scope="row" class="align-middle">
                        <router-link class="btn btn-success me-3" :to="'/pickPlace/' + conn.trainId + '/' + fromStationId + '/' + toStationId">Wybierz</router-link>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
    name: "search-results-table",
    props: {
        connSource: Array,
        fromStation: String,
        fromStationId: Number,
        toStation: String,
        toStationId: Number,
    },
    methods: {
        getDate(dateStr) {
            var date = new Date(dateStr);
            var yy = date.getFullYear();
            var mm = date.getMonth() + 1;
            var dd = date.getDate();
            return yy + "-" + ((mm>9 ? '' : '0') + mm) + "-" + ((dd>9 ? '' : '0') + dd);
        },
        getTime(dateStr) {
            var date = new Date(dateStr);
            var hh = date.getHours();
            var mm = date.getMinutes();
            return ((hh>9 ? '' : '0') + hh) + ":" + ((mm>9 ? '' : '0') + mm);
        },
    },
};
</script>

<style scoped></style>
