<template>

  <div id="app">


     <router-view><HelloWorld msg="Welcome to Your Vue.js App"/></router-view>
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue';
import { store } from "./store";
export default {
  name: 'app',
  store,
  components: {
    HelloWorld,
    
  },
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>