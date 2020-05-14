<template>
  <div class="container">
    <h1>SImple voting</h1>
    <hr />
    <Poll
      v-for="poll in Polls"
      v-bind:poll="poll"
      :key="poll.id"
      v-on:addvar="addvar"
    />
  </div>
</template>

<script>
import Poll from "@/components/Poll.vue";
export default {
  data() {
    return {
      Polls: [],
    };
  },
  methods: {
      updatePolls() {
      fetch("https://localhost:5001/api/Poll")
        .then((response) => response.json())
        .then((json) => {
          this.Polls = json;
        });
    },
    addvar(Id_Poll, Name) {
        let variant = { Id: 1, Name , Id_Poll }
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
.container {
  padding: 16px;
  margin: 0 auto;
}
</style>
