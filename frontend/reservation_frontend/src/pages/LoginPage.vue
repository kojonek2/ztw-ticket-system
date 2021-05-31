<template>
    <div class="d-flex justify-content-center flex-column col-4">
        <logo-with-texts></logo-with-texts>
        <br>
        <br>
        <form v-on:submit.prevent="logIn">
            <div class="form-group">
                <label class="mb-1">Nazwa użytkownika</label>
                <input
                    v-model="login"
                    type="text"
                    class="form-control mb-3"
                    placeholder="Wpisz nazwę użytkownika"
                />
            </div>

            <div class="form-group">
                <label class="mb-1">Hasło</label>
                <input
                    v-model="password"
                    type="password"
                    class="form-control mb-3"
                    placeholder="Wpisz hasło"
                />
            </div>

            <input type="submit" value="Zaloguj się" class="btn btn-primary" />
        </form>
        <div class="d-inline-flex flex justify-content-center">
            <div id="signInButton"></div>
        </div>
        <p>
            {{ this.response }}
        </p>
    </div>
</template>

<script>
import auth from "../auth";

import LogoWithTexts from "../components/LogoWithTexts.vue";

export default {
    name: "LoginPage",
    components: {
        LogoWithTexts,
    },
    data() {
        return {
            login: "",
            password: "",
            response: "",
            clientId:
                "512875819210-kj997qkdnvsn3reuf6a1ee4egfu97ns3.apps.googleusercontent.com",
        };
    },
    methods: {
        logIn: async function () {
            if (this.login == "" || this.password == "") return;

            const success = await auth.login(this.login, this.password);
            this.loginResponse(success);
        },
        loginResponse: function (success) {
            if (!success) {
                this.response = "Błąd podczas logowania";
                return;
            }

            this.$router.push(this.$route.query.redirect || "/");
        },
        async OnGoogleAuthSuccess(info) {
            const success = await auth.loginGoogle(info.qc.id_token);
            this.loginResponse(success);
        },
        OnGoogleAuthFail(error) {
            console.log(error);
        },
    },
    mounted() {
        if (this.$route.meta.logOut) {
            auth.logOut();
            this.$router.push("/");
        }

        if (auth.logedIn) {
            this.$router.push(this.$route.query.redirect || "/");
        }

        window.gapi.signin2.render('signInButton',
            {
                'onsuccess': this.OnGoogleAuthSuccess,
                'onfailure': this.OnGoogleAuthFail,
                'scope':'https://www.googleapis.com/auth/plus.login'
            }
        );
    },
};
</script>

<style>
</style>
