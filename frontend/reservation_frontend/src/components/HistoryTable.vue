<template>
    <div id="history-table">
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
                <tr v-for="res in reservationsSource" :key="res.id">
                    <td scope="row" class="align-middle">
                        <img src="../assets/train.png" height="70">
                    </td>
                    <td scope="row" class="align-middle">{{ getDate(res.dateFrom) }}</td>
                    <td scope="row" class="align-middle">{{ getTime(res.dateFrom) }}</td>
                    <td scope="row" class="align-middle">{{ res.from }}</td>
                    <td scope="row" class="align-middle">{{ res.to }}</td>
                    <td scope="row" class="align-middle">
                        <router-link class="btn btn-success me-3" :to="'/history/' + res.id">Wybierz</router-link>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
    name: "history-table",
    props: {
        reservationsSource: Array,
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
