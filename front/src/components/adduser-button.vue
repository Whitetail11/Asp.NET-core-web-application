<template>
  <div>
    <button v-on:click="adduser">
      add user
    </button>
  </div>
</template>

<script>
export default {
  props: ["users"],
  data() {
    return {
      user: {
        Id: 1,
        Email: "NEW USER123",
        Password: "44433",
        NickName: "NEW USER12123",
        Age: 12,
      },
    };
  },
  methods: {
    async adduser() {
      let responce = await fetch("https://localhost:5001/api/user", {
        method: "POST",
        headers: { "Content-Type": "application/json;charset=utf-8" },
        body: JSON.stringify(this.user),
      });
      if (responce.ok) {
        this.$emit("add-user", this.user);
      }
    },
  },
};
</script>
