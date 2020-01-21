<template>
     <v-app>
        <v-content>
          <v-container>
            <img alt="Vue logo" src="../assets/logo.png">  
              <div class="hello">
                    {{msg}}
                  <p @click="goLogin" class="link_">Sign in</p>
              </div>
          </v-container>
        </v-content>
      </v-app>

</template>

<script>
export default {
  name: 'HelloWorld',
  props: {
    msg: String
  },
  methods:{
    goLogin:function(){
        this.$router.push({ name: "LoginForm" });
        //window.location.href = "/Login"
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