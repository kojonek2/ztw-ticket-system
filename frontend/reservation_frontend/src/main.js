import Vue from 'vue'
import VueRouter from 'vue-router'

import App from './App.vue'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import router from './router'

import axios from 'axios'
axios.defaults.baseURL = 'https://localhost:44365'

Vue.config.productionTip = false

Vue.use(BootstrapVue)
Vue.use(IconsPlugin)
Vue.use(VueRouter)

new Vue({
  render: h => h(App),
  router
}).$mount('#app')
