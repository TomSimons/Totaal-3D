import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Vergunningschecker from '../views/Terugmelden.vue'
import Sketchup2CityJson from '../views/Sketchup2CityJson.vue'
import Gemeenteblad from '../views/Gemeenteblad.vue'
import BimServerTest from '../views/BimServerTest.vue'
import UserFeedBack from '../views/UserFeedBack.vue'
import UserFeedBackList from '../views/UserFeedBackList.vue'
import Bevindingen from '../views/Bevindingen.vue'
import BevindingenEdit from '../views/BevindingenEdit.vue'
import Users from '../views/Users.vue'
import Activate from '../views/Activate.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Project T3D - team Amsterdam',
    component: Home
  },
  {
    path: '/terugmelden',
    name: 'Terugmelden',
    component: Vergunningschecker
  },
  {
    path: '/sketchup2cityjson',
    name: 'Sketchup2CityJson',
    component: Sketchup2CityJson
  },
  {
    path: '/bevindingen',
    name: 'Bevindingen',
    component: Bevindingen
  },
  {
    path: '/blog',
    name: 'BevindingenEdit',
    component: BevindingenEdit
  },
  {
    path: '/users',
    name: 'Users',
    component: Users
  },
  {
    path: '/activate',
    name: 'Activeer T3D Beheer',
    component: Activate
  },
  {
    path: '/gemeenteblad',
    name: 'Gemeenteblad',
    component: Gemeenteblad
  },
  {
    path: '/bim',
    name: 'BimServerTest',
    component: BimServerTest
  },
  {
    path: '/userfeedback',
    name: 'UserFeedBackList',
    component: UserFeedBackList
  },
  {
    path: '/userfeedback/:id',
    name: 'UserFeedBack',
    component: UserFeedBack
  }
]

const router = new VueRouter({
  routes,
  scrollBehavior() {
    document.getElementById('app').scrollIntoView({ behavior: 'smooth' });
}
})

export default router
