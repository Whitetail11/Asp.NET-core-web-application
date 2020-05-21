<template>
  <div class="container">
    <h1>Simple voting</h1>
    <hr />
    <div class="header-center">
		<ul>
			<li><router-link :to="{ name: 'MyPolls', params: {UserId}}" tag="button">Мои опросы </router-link></li>
			<li><router-link :to="{ name: 'AddPoll', params: {UserId}}" tag="button">Добавить опрос</router-link></li>
			<li><router-link :to="{ name: 'home', params: {UserId}}" tag="button" >Все опросы</router-link></li>
		</ul>
	</div>
    <h2>Мои опросы</h2>
    <MyPoll
      v-for="poll in Polls"
      v-bind:poll="poll"
      :key="poll.id"
      v-on:addvar="addvar"
      v-bind:UserId="UserId"
      v-on:deletePoll="deletePoll"
      v-on:active="active"
    />
    <button v-on:click="addPoll">    
      <Zondicon icon="AddOutline" class="icon" />
    </button>
  </div>
  
</template>

<script>
import MyPoll from "@/components/MyPoll.vue";
import Zondicon from "vue-zondicons";
export default {
  data() {
    return {
      Polls: [],
      UserId: this.$route.params.id,
    };
  },
  components: {
    MyPoll, Zondicon
  },
  mounted() {
    fetch("https://localhost:5001/api/Poll")
      .then((response) => response.json())
      .then((json) => {
        this.Polls = json;
      });
  },
  methods: {
      active(id) {
          let index
          for(let i = 0; i<this.Polls.length; i++) {
              if(this.Polls[i].id == id) {
                  this.Polls[i].isActive = true;
                  index = i;
              }
          }
          let responce = fetch("https://localhost:5001/api/poll", {
        method: "PUT",
        headers: { "Content-Type": "application/json;charset=utf-8"},
        body: JSON.stringify(this.Polls[index])
      }).finally(() => {
        fetch("https://localhost:5001/api/Poll")
          .then((response) => response.json())
          .then((json) => {
            this.Polls = json;
          });
      });
      },
      addPoll() {
          this.$router.push({path: `/AddPoll/${this.UserId}`})
      },    
       deletePoll(id) {
       let responce = fetch("https://localhost:5001/api/poll/" + id, {
        method: "DELETE",
        headers: { "Content-Type": "application/json;charset=utf-8"}
      }).finally(() => {
        fetch("https://localhost:5001/api/Poll")
          .then((response) => response.json())
          .then((json) => {
            this.Polls = json;
          });
      });
    },
      addvar(Id_Poll, Name) {
      let variant = { Id: 1, Name, Id_Poll };
      let responce = fetch("https://localhost:5001/api/variant", {
        method: "POST",
        headers: { "Content-Type": "application/json;charset=utf-8" },
        body: JSON.stringify(variant),
      }).finally(() => {
        fetch("https://localhost:5001/api/Poll")
          .then((response) => response.json())
          .then((json) => {
            this.Polls = json;
          });
      });
    },
  }
};
</script>

<style scoped>
ul {
  list-style: none;
  display: flex;
  justify-content: space-around;
}
hr {
  color: lawngreen;
  height: 1px;
  width: 100%;
  background: lawngreen;
}
.icon {
  width: 100%;
  height: 100%;
}
button {
  border: none;
  outline: none;
  cursor: pointer;
  width: 40px;
  padding-top: 10px;
  background: none;
  margin: 0 auto;
}
</style>
