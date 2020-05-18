<template>
  <div class="container">
    <h1>Simple voting</h1>
    <hr />
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
    <input type="text" placeholder="Создайте новый опрос..." v-model="name" />
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
      let newPoll = {
        Id: 1,
        name: this.name,
        datePublication: new Date(),
        deadLine: new Date("2020-05-21"),
        author_Id: +this.UserId,
        maxVariantByUser: 1,
      };
      console.log(this.Polls[0].isActive)
      let responce = fetch("https://localhost:5001/api/poll", {
        method: "POST",
        headers: { "Content-Type": "application/json;charset=utf-8" },
        body: JSON.stringify(newPoll),
      }).finally(() => {
        fetch("https://localhost:5001/api/Poll")
          .then((response) => response.json())
          .then((json) => {
            this.Polls = json;
            this.name = "";
          });
      });
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
  padding: 16px;
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
