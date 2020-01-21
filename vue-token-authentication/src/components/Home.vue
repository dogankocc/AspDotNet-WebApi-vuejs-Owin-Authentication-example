<template>
    <v-text-field v-model="text"></v-text-field>


</template>

<script>
export default {
  name: 'Home',
  props: {

  },
  components:{
      
  },
  data(){
      return{
        text:"Home"
      }
      
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.link_{
  cursor: pointer;
  color: #42b983;
  
}
</style>