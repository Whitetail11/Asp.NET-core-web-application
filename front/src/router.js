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
        },
        {
            path: '/AddPoll/:id',
            name: 'AddPoll',
            component: () =>
                import ('./views/AddPoll.vue')
        },
        {
            path: '/MyPolls/:id',
            name: 'MyPolls',
            component: () =>
                import ('./views/MyPolls.vue')
        },
        {
            path: '/EditPoll/:id',
            name: 'EditPoll',
            component: () =>
                import ('./views/EditPoll.vue')
        },
        {
            path: '/Poll/:id',
            name: 'Poll',
            component: () =>
                import ('./views/Poll.vue')
        }
    ]
})