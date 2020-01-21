import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'
import LoginForm from '../components/LoginForm.vue'
import Home from '../components/Home.vue'
import Layout from '../components/Layout.vue'

Vue.use(Router)

const routerPush = Router.prototype.push
Router.prototype.push = function push(location) {
  return routerPush.call(this, location).catch(error=> error)
}

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'HelloWorld',
      component: HelloWorld
    },
    {
        path:'/Login',
        name:'LoginForm',
        component:LoginForm ,
       
    },
    {
        path:'/Home',
        name:'Home',
        component:Home ,
       
    }
    ,
    {
        path:'/App',
        name:'Layout',
        component:Layout ,
       
    }
  ]
})
