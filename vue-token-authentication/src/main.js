import Vue from 'vue'
import App from './App.vue'
import router from './router'
import vuetify from '@/plugins/vuetify' 

Vue.config.productionTip = false
/*
new Vue({
  render: h => h(App),
}).$mount('#app')
*/

new Vue({
  el: '#app',
  router,
  vuetify,
  //components: { App },
  render: h => h(App),
}).$mount('#app')