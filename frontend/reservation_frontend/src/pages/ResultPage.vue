<template>
    <div id="Result" class="d-flex flex-column align-items-center mt-2 w-100">
        <top-bar></top-bar>
        
        <hr>
        <div v-if="resId > 0" class="d-flex flex-column align-items-center mt-2 w-100">
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100" fill="currentColor" class="bi bi-check-circle" viewBox="0 0 16 16">
                <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>
                <path d="M10.97 4.97a.235.235 0 0 0-.02.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-1.071-1.05z"/>
            </svg>
            <br>
            <h5>Uprzejmie informujemy, że Państwa rezerwacja została przyjęta.</h5>
            <h5>Numer rezerwacji:</h5>
            <br>
            <h2>{{resId}}</h2>
            <br>

            <router-link class="btn btn-success mt-3" :to="{ name: 'home', }">Powrót na stronę główną</router-link>
        </div>
        <div v-else class="d-flex flex-column align-items-center mt-2 w-100">
            <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100" fill="currentColor" class="bi bi-x-circle" viewBox="0 0 16 16">
                <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>
                <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"/>
            </svg>
            <br>
            <h5>Uprzejmie informujemy, że Państwa rezerwacja nie została przyjęta.</h5>
            <h5>Przepraszamy</h5>
            <br>

            <router-link class="btn btn-danger mt-3" :to="{ name: 'home', }">Powrót na stronę główną</router-link>
        </div>

    </div>
</template>

<script>
import TopBar from "../components/TopBar.vue";

export default {
    name: "ResultPage",
    components: {
        TopBar,
    },
    data() {
        return {
        }
    },
    props: {
        resId: Number
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
