<template>
    <div id="history-table">
        Filtruj bilety od:

        <b-form-datepicker id="filterStart" 
        v-model="filterStart"
        today-button
        label-today-button="Dzisiaj"
        reset-button
        label-reset-button="Wyczyść"
        close-button
        label-close-button="Zamknij"
        label-help="Użyj myszki do wskazania daty!"
        label-calendar="Kalendarz"
        label-no-date-selected="Nie wybrano daty"
        locale="pl" 
        class="m-2"></b-form-datepicker>

        do:

        <b-form-datepicker id="filterEnd" 
        v-model="filterEnd"
        today-button
        label-today-button="Dzisiaj"
        reset-button
        label-reset-button="Wyczyść"
        close-button
        label-close-button="Zamknij"
        label-help="Użyj myszki do wskazania daty!"
        label-calendar="Kalendarz"
        label-no-date-selected="Nie wybrano daty"
        locale="pl" 
        class="m-2"></b-form-datepicker>

        <sorted-table :values="filteredReservations" class="table">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">
                        <sort-link name="dateFrom" class="text-decoration-none">Data</sort-link>
                    </th>
                    <th scope="col">Godzina</th>
                    <th scope="col">Stacja początkowa</th>
                    <th scope="col">Stacja docelowa</th>
                    <th scope="col">Akcja</th>
                </tr>
            </thead>
            <template #body="{ values }">
                <tbody>
                    <tr v-for="res in values" :key="res.id">
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
            </template>
        </sorted-table>
    </div>
</template>

<script>
export default {
    name: "history-table",
    props: {
        reservationsSource: Array,
    },
    data() {
        return {
            filterStart: "",
            filterEnd: "",
        }
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
    computed: {
        filteredReservations() {
            var start = Date.parse(this.filterStart)
            var end = Date.parse(this.filterEnd)

            var results = this.reservationsSource
            if (!isNaN(start)) {
                results = results.filter(r => {
                    var st = this.getDate(r.dateFrom);
                    var pattern = /(\d{2})\/(\d{2})\/(\d{4})/;
                    var dt = Date.parse(st.replace(pattern,'$3-$2-$1'));
                    if (isNaN(dt)) {
                        var pattern2 = /(\d{2})\.(\d{2})\.(\d{4})/;
                        dt = Date.parse(st.replace(pattern2,'$3-$2-$1'));
                    }

                    return dt >= start;
                })
            }

            if (!isNaN(end)) {
                results = results.filter(r => {
                    var st = this.getDate(r.dateFrom);
                    var pattern = /(\d{2})\/(\d{2})\/(\d{4})/;
                    var dt = Date.parse(st.replace(pattern,'$3-$2-$1'));
                    if (isNaN(dt)) {
                        var pattern2 = /(\d{2})\.(\d{2})\.(\d{4})/;
                        dt = Date.parse(st.replace(pattern2,'$3-$2-$1'));
                    }

                    return dt <= end;
                })
            }

            return results
        }
    }
};
</script>

<style scoped></style>
