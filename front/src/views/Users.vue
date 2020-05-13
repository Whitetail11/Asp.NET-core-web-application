<template>
  <div>
    <h2>Voting Application</h2>
    <hr />
    <router-link to="/">Home</router-link>
    <Users v-bind:users="users"></Users>
    <adduserButton v-bind:users="users" @add-user="addUser"></adduserButton>
  </div>
</template>


<script>
import Users from "@/components/Users.vue";
import adduserButton from "@/components/adduser-button.vue";
export default {
  name: "App",
  methods: {
    addUser(user) {
      fetch("https://localhost:5001/api/user")
      .then((response) => response.json())
      .then((json) => {
        this.users = json;
      });
    },
  },
  data() {
    return {
      users: [
        // {id: 1, Email: 'ss', Password: '1234', NickName: 'Danya', Age: 12},
        // {id: 2, Email: 'rr', Password: '12343', NickName: 'Julia', Age: 12}
      ],
    };
  },
  mounted() {
    fetch("https://localhost:5001/api/user")
      .then((response) => response.json())
      .then((json) => {
        this.users = json;
      });
  },
  components: {
    Users,
    adduserButton,
  },
};
</script>