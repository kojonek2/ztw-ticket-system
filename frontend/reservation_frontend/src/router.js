const { default: VueRouter } = require("vue-router");


import Foo from './Foo.vue'
//import Bar from './Bar.vue'
import LoginPage from './pages/LoginPage.vue'
import TestPage from './pages/TestPage.vue'
import SearchPage from './pages/SearchPage.vue'
import HistoryPage from './pages/HistoryPage.vue'
import HistoryDetailsPage from './pages/HistoryDetailsPage.vue'
import PickPlacePage from './pages/PickPlacePage.vue'
import ConfirmTicketsPage from './pages/ConfirmTicketsPage.vue'

import auth from './auth'

const routes = [
    { path: '/', component: Foo },
    { path: '/search', component: SearchPage, meta: { requireLogin: true } },
    { path: '/history', component: HistoryPage, meta: { requireLogin: true } },
    { path: '/history/:id', component: HistoryDetailsPage, meta: { requireLogin: true } },
    { path: '/login', component: LoginPage},
    { path: '/logOut', component: LoginPage, meta: { logOut: true } },
    { path: '/test', component: TestPage},
    { path: '/pickPlace/:trainId/:fromId/:toId', component: PickPlacePage,  meta: { requireLogin: true } },
    { path: '/confirmTicket', name:'confirmTicket', component: ConfirmTicketsPage, props: true, meta: { requireLogin: true }}
  ]

const router = new VueRouter({
    routes
})

router.beforeEach((to, from, next) => {
    if (to.matched.some(record => record.meta.requireLogin)) {

      if (!auth.logedIn) {
        next({
          path: '/login',
          query: { redirect: to.fullPath }
        })
      } else {
        next()
      }
    } else {
      next() 
    }
  })

export default router;