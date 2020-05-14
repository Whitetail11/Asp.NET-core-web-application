<template>
<form  style="border:1px solid #ccc" @submit.prevent="registration">
  <div class="container">
    <h1>Sign Up</h1>
    <hr>

    <label for="email"><b>Email</b></label>
    <input type="text" placeholder="Enter Email" name="email" required v-model="Email">

    <label for="NickName"><b>Nickname</b></label>
    <input type="text" placeholder="Enter NickName" name="nickname" required v-model="Nickname">

    <label for="age"><b>Age</b></label>
    <input type="text" placeholder="Enter Age" name="age" required v-model="Age">

    <label for="psw"><b>Password</b></label>
    <input type="password" placeholder="Enter Password" name="psw" required v-model="Password">


    <div class="clearfix">
      <router-link to="/login" tag="button" class="signupbtn">Sign In</router-link>
      <button type="submit" class="signupbtn">Sign Up</button>
      
    </div>
    <label id="error">{{error}}</label>
  </div>
</form>
</template>

<script>
import router from '@/router.js'
export default {
    data() {
        return {
            isregistration: false,
            Email: '',
            Nickname:'',
            Password:'',
            Age: '',
            error: ''
        }
    },
    methods: {
        registration() {
            const user = {
                Id: 1,
                Email: this.Email,
                Nickname: this.Nickname,
                Password: this.Password,
                Age: +this.Age
            }
            
            let responce = fetch("https://localhost:5001/api/user", {
        method: "POST",
        headers: { "Content-Type": "application/json;charset=utf-8" },
        body: JSON.stringify(user),
         }).then(res => res.json()).then(json => this.isregistration = json).finally(() => {
            console.log(this.isregistration)
              if(this.isregistration) {
                  this.$router.push('/')
              }    
             else {
                 this.error = 'пользователь с таким Email уже есть!'    
                 this.Email = ''
                 this.Nickname = ''
                 this.Password = ''
                 this.Age = ''                
             }
             
         })
        }
    }
}
</script>

<style scoped>
*,
*::before,
*::after {
    box-sizing: border-box;
    margin: 0;
    padding: 0;
}
form {
    width: 60%;
    margin: 0 auto;
}

#error {
    color: red;
}
input[type=text], input[type=password] {
  width: 100%;
  padding: 15px;
  margin: 5px 0 22px 0;
  display: inline-block;
  border: none;
  background: #f1f1f1;
}

input[type=text]:focus, input[type=password]:focus {
  background-color: #ddd;
  outline: none;
}

hr {
  border: 1px solid #f1f1f1;
  margin-bottom: 25px;
}

button {
  background-color: #4CAF50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
  opacity: 0.9;
}

button:hover {
  opacity:1;
}

.cancelbtn {
  padding: 14px 20px;
  background-color: #f44336;
}

.cancelbtn, .signupbtn {
  float: left;
  width: 50%;
}

.container {
  padding: 16px;
}

.clearfix::after {
  content: "";
  clear: both;
  display: table;
}
</style>
