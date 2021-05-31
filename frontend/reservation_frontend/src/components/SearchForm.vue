<template>
    <div id="search-form">
        <form @submit.prevent="handleSubmit">
            <div class="form-group mb-3">
                <label for="example-datepicker">Wybierz datę odjazdu</label>
                <b-form-datepicker 
                    id="example-datepicker" 
                    v-model="dateNoFormat" 
                    menu-class="w-100"
                    calendar-width="70%"
                    class="mb-2"
                    label-help="Użyj myszki do wskazania daty!"
                    label-calendar="Kalendarz"
                    label-today-button="Dzisiaj"
                    today-button=true
                    :class="{ 'has-error': submitting }"
                ></b-form-datepicker>
                
            </div>

            <div class="form-group mb-3">
                <label for="example-datepicker">Wybierz godzinę odjazdu</label>
                <b-form-timepicker 
                    v-model="time" 
                    locale="pl"
                    label-no-time-selected="Wybierz godzinę odjazdu"
                    label-close-button="Zamknij"
                    now-button=true
                    label-now-button="Teraz"
                    :class="{ 'has-error': submitting }"
                ></b-form-timepicker>
            </div>

            <div class="form-group mb-3">
                <label>Stacja początkowa</label>
                <select class="form-control" v-model="fromStationId"
                :class="{ 'has-error': submitting && invalidFromStation }"
                @focus="clearStatus"
                @select="clearStatus">
                    <option v-for="station in stationsSource" :key="station.stationId" :value="station.stationId">
                        {{station.name}}
                    </option>
                </select>
            </div>

            <div class="form-group mb-3">
                <label>Stacja docelowa</label>
                <select class="form-control" v-model="toStationId"
                :class="{ 'has-error': submitting && invalidToStation }"
                @focus="clearStatus"
                @select="clearStatus">
                    <option v-for="station in stationsSource.filter(s => s.stationId !== fromStationId)" :key="station.stationId" :value="station.stationId">
                        {{station.name}}
                    </option>
                </select>
			</div>

            <p v-if="error && submitting" class="error-message">
                Please select indicated fields!
            </p>
            <button class="btn btn-primary">Szukaj</button>
        </form>
    </div>
</template>

<script>

export default {

    name: "search-form",
    components: {
    },
    props: {
        stationsSource: Array,
    },
    data() {
        const now = new Date()
        const today = now.getFullYear() + "-" + (now.getMonth() + 1) + "-" +  now.getDate();
        const nowTime = now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();


        return {
            submitting: false,
            error: false,
            success: false,
            fromStationId: -1,
            toStationId: -2,
            dateNoFormat: today,
            time: nowTime,
        };
    },
    methods: {
        handleSubmit() {
            this.submitting = true;
            this.clearStatus();

            //check form fields
            if (this.invalidFromStation || this.invalidToStation) {
                this.error = true;
                return;
            }

            var dateSplit = this.dateNoFormat.split('-')
            var timeSplit = this.time.split(':')

            var dateFormat = dateSplit[0] + "-" + dateSplit[1] + "-" + dateSplit[2] + "-" + timeSplit[0] + "-" + timeSplit[1];

            this.$emit("save:search", this.fromStationId, this.toStationId, dateFormat);

            this.error = false;
            this.success = true;
            this.submitting = false;
        },
        clearStatus() {
            this.success = false;
            this.error = false;
        },
    },
    computed: {
        invalidFromStation() {
            return this.fromStationId < 0;
        },

        invalidToStation() {
            return this.toStationId < 0;
        },

    },
};
</script>

<style scoped>
form {
    margin-bottom: 2rem;
}

[class*="-message"] {
    font-weight: 500;
}
.error-message {
    color: #d33c40;
}
.success-message {
    color: #32a95d;
}
</style>