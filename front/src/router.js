import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/views/Home'


Vue.use(Router)
export default new Router({
    mode: 'history',
    routes: [{
            path: '/',
            component: Home
        },
        {
            path: '/users',
            component: () =>
                import ('./views/Users.vue')
        },
        {
            path: '/registration',
            component: () =>
                import ('./views/Registration.vue')
        },
        {
            path: '/login',
            component: () =>
                import ('./views/Login.vue')
        }
    ]
})