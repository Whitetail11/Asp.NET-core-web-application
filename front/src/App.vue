<template>
  <div id="app">
    <h1>Voting Application</h1>
    <hr>
    <Users v-bind:users="users"></Users>
  </div>
</template>

<script>
import Users from '@/components/Users.vue'
export default {
  name: 'App',
  data() {
    return {
      users: [
       // {id: 1, Email: 'ss', Password: '1234', NickName: 'Danya', Age: 12},
      // {id: 2, Email: 'rr', Password: '12343', NickName: 'Julia', Age: 12}
      ]
    }
  },
  mounted() {
    fetch('https://localhost:5001/api/user')
    .then(response => response.json())
    .then(json => {
      this.users = json
    })
  },
  components: {
    Users
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
