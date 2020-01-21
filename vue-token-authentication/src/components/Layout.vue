<template>
<v-app>

    
      <v-app-bar
        dark
        height="50px"
        dense
        src="https://cdn.vuetifyjs.com/images/backgrounds/vbanner.jpg"
        fixed 
        class="toolbar"
        app>
              <v-navigation-drawer app
        v-model="drawer"
        absolute
        bottom
        temporary
      >
        <v-list
          nav
          dense
        >
          <v-list-item-group
            v-model="group"
            active-class="deep-purple--text text--accent-4"
          >
            <v-list-item>
              <v-list-item-title>Foo</v-list-item-title>
            </v-list-item>
  
            <v-list-item>
              <v-list-item-title>Bar</v-list-item-title>
            </v-list-item>
  
            <v-list-item>
              <v-list-item-title>Fizz</v-list-item-title>
            </v-list-item>
  
            <v-list-item>
              <v-list-item-title>Buzz</v-list-item-title>
            </v-list-item>
          </v-list-item-group>
        </v-list>
      </v-navigation-drawer>
        <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
        <v-toolbar-title>Vuetify</v-toolbar-title>
  
        <v-spacer></v-spacer>
          <v-btn icon>
              <v-icon>mdi-magnify</v-icon>
            </v-btn>
            <v-btn icon>
              <v-icon>mdi-heart</v-icon>
            </v-btn>
        <v-btn icon>
          <v-icon>mdi-export</v-icon>
        </v-btn>

        <v-menu
            left
            bottom
        >
        <template v-slot:activator="{ on }">
          <v-btn icon v-on="on">
            <v-icon>mdi-dots-vertical</v-icon>
          </v-btn>
        </template>

        <v-list>
          <v-list-item
            v-for="n in 5"
            :key="n"
            @click="() => {}"
          >
            <v-list-item-title>Option {{ n }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
        </v-app-bar>



  <!-- Sizes your content based upon application components -->
  <v-content>

    <!-- Provides the application the proper gutter -->
    <v-container fluid>
      <component :is="componentName"></component><!-- this.$route.params.title -->

    </v-container>
  </v-content>

  <v-footer app>
    <!-- -->
  </v-footer>
</v-app>

    

</template>

<script>
import Home from './Home'
export default {
  name: 'Layout',
  components:{
    Home
  },

  data: function() {
    return{
    drawer: false,
    group: null,
     componentName:this.$route.params.title
  }},

  watch: {
    group () {
      this.drawer = false
    },
  },
}


</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.toolbar{
  width: 100%;
  
}
</style>