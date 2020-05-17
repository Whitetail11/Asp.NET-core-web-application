import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/views/Home'


Vue.use(Router)
export default new Router({
    mode: 'history',
    routes: [{
            path: '/Home/:id',
            name: 'home',
            component: Home
        },
        {
            path: '/registration',
            component: () =>
                import ('./views/Registration.vue')
        },
        {
            path: '/',
            component: () =>
                import ('./views/Login.vue')
        }
    ]
})