<template>
   <div>
    <v-app id="inspire">
    <v-content>
      <v-container
        class="fill-height"
        fluid
      >
        <v-row
          align="center"
          justify="center"
        >
          <v-col
            cols="12"
            sm="8"
            md="4"
          >
            <v-card class="elevation-12">
              <v-toolbar
                color="primary"
                dark
                flat
              >
                <v-toolbar-title>Login form</v-toolbar-title>
                <v-spacer />
              </v-toolbar>
              <v-card-text>
                <v-form>
                  <v-text-field
                    label="Username"
                    name="username"
                    type="text"
                    :rules="rules" v-model="username"
                  />

                  <v-text-field
                    id="password"
                    label="Password"
                    name="password"
                    type="password"
                    :rules="rules" v-model="password"
                  />
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer />
                <v-btn color="primary" @click="signIn">Login</v-btn>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-content>
  </v-app>
  </div>
</template>

<script>
//import $ from 'jquery';

var accsess_token = null;
var dispatch = null;
var goHomeMethod = null;

export default {
  name: 'LoginForm',
  props: {
  },
  data(){
      return {
            username: "",
            password:"",
            rules: [
                    value => !!value || 'Required.',
                    value => (value && value.length >= 3) || 'Min 3 characters',
            ],
      }
  },
  methods:{
      signIn(){
        //alert(this.username+"  "+this.password)
        /*
       (async () => {
        const rawResponse = await fetch('', {
            method: 'POST',
            headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': 'https://javascript.info'
            },
            body: JSON.stringify({clientName: 'Login'}),
            mode:'no-cors'
        });
        const content = await rawResponse.json();

        alert("content : "+content);
        })();

        $.ajax({
            type: 'POST',
            url: "http://localhost:55808/User/GetClientIdentity",
            data: 'Login',//JSON.stringify({clientName: 'Login'}),
            dataType: "json",
             async: false,
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            xhrFields: {
                withCredentials: true
            },
            crossDomain: true,
            headers: {
                "Access-Control-Allow-Origin":"*"
            },
            error: function (req, status, error) {
                alert(error);
            }
        }).done(function(response) {
            alert(JSON.stringify(response))
        });
        */


        dispatch = this.$store.dispatch;
        goHomeMethod = this.goHome;
        //get clientId,clientSecret from database with user password
        //var clientId = "C3586A45-AF64-4B1C-AAEA-4BD9C1DA15B3";
        //var clientSecret = "9184BF83-4C1E-47FA-BD3C-A8CF70E00360";
        var clientId = null;
        var clientSecret = null;

        var request0 = new XMLHttpRequest();
        request0.open('POST', "http://localhost:55808/api/user/GetClientIdentity", true);
        request0.setRequestHeader('Content-Type', 'application/json');
        request0.setRequestHeader('Accept', 'application/json');
        //request0.setRequestHeader('Authorization', 'Bearer ' +accsess_token);
        request0.setRequestHeader('Access-Control-Allow-Origin','*');
        var model = {clientName:"Login"}
        request0.send(JSON.stringify(model));

        request0.onreadystatechange = function(){
            if (request0.readyState === 4) {
                var response = JSON.stringify(request0.responseText);
                alert("response GetClientIdentity:  "+response)
                response = JSON.parse(response);
                clientId = response.ClientId;
                clientSecret = response.ClientSecret;

                var authorizationBasic = window.btoa(clientId + ':' + clientSecret);
                var request = new XMLHttpRequest();
                
                request.open('POST', "http://localhost:55808/token", true);
                request.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded; charset=UTF-8');
                request.setRequestHeader('Authorization', 'Basic ' + authorizationBasic);
                request.setRequestHeader('Accept', 'application/json');
                //you could put this.username and this.password in here
                request.send("username=Anurag&password=123456&grant_type=password");

                request.onreadystatechange = function(){
                    if (request.readyState === 4) {
                        var resObj = JSON.parse(request.responseText);
                        accsess_token = resObj.access_token;    
                        dispatch("putToken" ,{username:'Anurag',token:accsess_token} );
                        alert("accsess_token recorded store state:  " +accsess_token)
                        goHomeMethod();
                    }
                }
            }
        }

        /*
        $.ajax({
            type: 'POST',
            url: "http://localhost:55808/token",
            data: { username: 'Anurag', password: '123456', grant_type: 'password' },
            dataType: "json",
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            xhrFields: {
                withCredentials: true
            },
            // crossDomain: true,
            headers: {
                'Authorization': 'Basic ' + authorizationBasic
            },
            //beforeSend: function (xhr) {
            //},
            success: function (result) {
                var token = result;
            },
            //complete: function (jqXHR, textStatus) {
            //},
            error: function (req, status, error) {
                alert(error);
            }
        });
        */
        },
        goHome:function(){
            this.$router.push({ name: "Layout" , params: {title: 'Home' }});//{ path: "App" ,component: FooComponent,  props: true } 
            //window.location.href = "/Home"
        }

  }
}
      
</script>

<style scoped>

</style>