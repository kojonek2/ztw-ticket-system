<template>
    <div class="d-flex justify-content-center align-items-center flex-column">
        <div class="d-flex justify-content-center align-items-center">
            <logo-with-texts />
            <div class="p-3 ms-5 border border-primary rounded">
                <div
                    v-if="logedIn"
                    class="d-flex flex-column justify-content-center align-items-center"
                >
                    <div class="logedText">Zalogowano</div>
                    <div>{{ user.login }}</div>
                </div>
                <div v-else class="logedText">Niezalogowany</div>
            </div>
        </div>
        
        <nav class="navbar navbar-expand-lg navbar-light bg-light w-100 d-flex justify-content-between">
            <div class="navbar-nav">
                <router-link class="nav-item nav-link" to='/' v-bind:class="{ active: $route.path == '/'}">Strona główna</router-link>
                <router-link class="nav-item nav-link" to='/bar' v-bind:class="{ active: $route.path == '/bar'}">Wyszukaj połączenie</router-link>
                <router-link class="nav-item nav-link" to='/'>Historia rezerwacji</router-link>
            </div>
            <div class="navbar-nav">
                <router-link v-if="!logedIn" class="nav-item nav-link" to='/login'>Logowanie do systemu</router-link>
                <router-link v-else class="nav-item nav-link" to='/logOut'>Wyloguj</router-link>    
            </div>
        </nav>
    </div>
</template>

<script>
import LogoWithTexts from "./LogoWithTexts.vue";
import auth from "../auth";

export default {
    components: {
        LogoWithTexts,
    },
    data() {
        return {
            logedIn: auth.logedIn,
            user: auth.user,
        };
    },
    name: "TopBar"
};
</script>

<style>
.logedText {
    font-size: 1.2rem;
}
</style>
