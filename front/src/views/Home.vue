<template>
  <div class="container">
    <h1>Simple voting</h1>
    <hr />
    <header>
	<div class="header-center">
		<ul>
			<li><router-link :to="{ name: 'MyPolls', params: {UserId}}" tag="button">Мои опросы </router-link></li>
			<li><router-link :to="{ name: 'AddPoll', params: {UserId}}" tag="button">Добавить опрос</router-link></li>
			<li><router-link :to="{ name: 'home', params: {UserId}}" tag="button" >Все опросы</router-link></li>
		</ul>
	</div>
</header>
    <div class="exit-button">
      <router-link to="/" tag="button"
        ><Zondicon icon="ArrowThinLeft" class="icon" />Выход</router-link
      >
    </div>
      <Poll
        v-for="poll in Polls"
        v-bind:poll="poll"
        :key="poll.id"
        v-on:addvar="addvar"
        v-bind:UserId="UserId"
        v-on:voting="voting"
        v-on:deletePoll="deletePoll"
      />
    <button v-on:click="addPoll">    
      <Zondicon icon="AddOutline" class="icon" />
    </button>
  </div>
</template>

<script>
import Zondicon from "vue-zondicons";
import Poll from "@/components/Poll.vue";
export default {
  data() {
    return {
      Polls: [],
      name: "",
      UserId: this.$route.params.id,
    };
  },
  
  methods: {
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
    voting(userid, changed) {
       let responce = fetch("https://localhost:5001/api/pollProcess", {
        method: "POST",
        headers: { "Content-Type": "application/json;charset=utf-8",
        "id": userid },
        body: JSON.stringify(changed),
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
    updatePolls() {
      fetch("https://localhost:5001/api/Poll")
        .then((response) => response.json())
        .then((json) => {
          this.Polls = json;
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
  },
  components: {
    Poll,
    Zondicon,
  },
  mounted() {
    fetch("https://localhost:5001/api/Poll")
      .then((response) => response.json())
      .then((json) => {
        this.Polls = json;
      });
  },
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
.exit-button {
  margin-right: auto;
  padding: 0;
}
.container {
  margin: 0 auto;
  display: flex;
  flex-direction: column;
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
input {
  border: 1px double rgb(60, 142, 180); /* Параметры границы */
  border-radius: 8px;
  background: ghostwhite;
  padding: 5px; /* Поля вокруг текста */
  display: flex;
  margin-bottom: 5px;
  width: 40%;
  outline: none;
  margin: 0 auto;
}
</style>
