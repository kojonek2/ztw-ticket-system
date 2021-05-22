import axios from 'axios'

const auth = {
    token: null,
    logedIn: false,
    user: null,

    login: async function(login, password) {
        try {
            var response = await axios.post("/authenticate", {
                login: login,
                password: password
            })
        } catch {
            this.logOut();
            return false;
        }

        return await this.processToken(response.data.token);
    },

    processToken: async function(token) {
        try {
            var userResponse = await axios.get("/user", {
                headers: {
                    Authorization: `bearer ${token}`
                }
            })
        } catch {
            this.logOut();
            return false;
        }

        this.token = token
        this.user = userResponse.data
        axios.defaults.headers.common = {'Authorization': `bearer ${token}`}
        this.logedIn = true;

        return true;
    },

    loginGoogle: async function(googleToken) {
        try {
            var response = await axios.post("/authenticateGoogle", {
                token: googleToken    
            });
        } catch {
            this.logOut();
            return false;
        }

        return await this.processToken(response.data.token);
    },

    logOut: function() {
        this.token = null;
        this.logedIn = false;
        this.user = null;
        delete axios.defaults.headers.common["Authorization"];
    }
}


export default auth