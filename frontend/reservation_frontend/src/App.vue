<template>
  <div id="app">
    
    <form v-on:submit.prevent="logIn" v-if="token == null">
      <input v-model="login" type="text">
      <input v-model="password" type="password">
      <input type="submit" value="Log in">
    </form>
    <div v-google-signin-button="clientId" class="g-signin2" v-if="token == null"></div>

    <p>
      {{this.response}}
    </p>
  </div>
</template>

<script>
import axios from 'axios'
import GoogleSignInButton from 'vue-google-signin-button-directive'

export default {
  name: 'App',
  directives: {
    GoogleSignInButton
  },
  data() {
    return {
      token: null,
      login: "",
      password: "",
      response: "",
      clientId: '512875819210-kj997qkdnvsn3reuf6a1ee4egfu97ns3.apps.googleusercontent.com'
    }
  },
  methods: {
    logIn: async function () {
      if (this.login == "" || this.password == "")
        return;

      try {
        var res = await axios.post("https://localhost:44365/authenticate", {
          login: this.login,
          password: this.password
        })
      } catch {
        this.response = 'Niepoprawny login lub hasło'
        return;
      }

      this.token = res.data.token
      axios.defaults.headers.common = {'Authorization': `bearer ${this.token}`}
      
      try {
        res = await axios.get("https://localhost:44365/test").catch();
      } catch {
        this.response = 'Not authorized';
        return;
      }
      this.response = res.data
    },
    async OnGoogleAuthSuccess (idToken) {
      try {
        var res = await axios.post("https://localhost:44365/authenticateGoogle", {
          token: idToken
        });
      } catch {
        this.response = 'Błąd autoryzacji';
        return;
      }

      this.token = res.data.token
      axios.defaults.headers.common = {'Authorization': `bearer ${this.token}`}

      try {
        res = await axios.get("https://localhost:44365/test");
      } catch {
        this.response = 'Not authorized'
        return;
      }

      this.response = res.data
    },
    OnGoogleAuthFail (error) {
      console.log(error)
    }
  },
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
