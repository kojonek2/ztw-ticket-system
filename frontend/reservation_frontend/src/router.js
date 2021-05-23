const { default: VueRouter } = require("vue-router");


import Foo from './Foo.vue'
import Bar from './Bar.vue'
import LoginPage from './pages/LoginPage.vue'
import TestPage from './pages/TestPage.vue'
import TestLoadPage from './pages/TestLoadPage.vue'

import auth from './auth'

const routes = [
    { path: '/', component: Foo },
    { path: '/bar', component: Bar, meta: { requireLogin: true } },
    { path: '/login', component: LoginPage},
    { path: '/logOut', component: LoginPage, meta: { logOut: true } },
    { path: '/test', component: TestPage},
    { path: '/load/:name', component: TestLoadPage},
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