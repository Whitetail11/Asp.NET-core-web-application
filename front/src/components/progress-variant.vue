<template>
  <li>
    <span>
      <p>{{ variant.name }}({{ procent }}%) <Zondicon icon="checkmark" class="icon" v-if="isthisUser()" /></p>
      
      <div v-bind:title="getNickName()">
        <progress
          v-bind:max="getmax()"
          v-bind:value="variant.users.length"
        ></progress>
      </div>
    </span>
  </li>
</template>

<script>
import Zondicon from "vue-zondicons";
export default {
  data() {
    return {
      procent: (this.variant.users.length * 100) / this.getmax(),
    };
  },
  components: {
    Zondicon,
  },
  props: {
    variant: {
      type: Object,
      required: true,
    },
    poll: {
      type: Object,
      required: true,
    },
    UserId: {
      required: true,
    },
  },
  methods: {
    isthisUser() {
      let res = false;
      for (let i = 0; i < this.variant.users.length; i++) {
        if (this.variant.users[i].id == this.UserId) {
          res = true;
        }
      }
      return res;
    },
    getNickName() {
      let res = [];
      for (let i = 0; i < this.variant.users.length; i++) {
        if (this.variant.users[i].id == this.UserId) {
          res.push(" Вы");
        } else {
          res.push(" " + this.variant.users[i].nickname);
        }
      }
      return res;
    },
    getmax() {
      let res = 0;
      for (let i = 0; i < this.poll.variants.length; i++) {
        res += this.poll.variants[i].users.length;
      }
      return res;
    },
  },
};
</script>

<style scoped>
span {
  display: flex;
  flex-direction: column;
}

progress {
  height: 25px;
  width: 90%;
}
.thisUser {
  border: 4px double black;
  padding: 10px;
}
.icon {
  width: 2%;
  height: 15px;
  padding: 0;
  margin: 0;
}
p {
  margin: 0;
}
</style>
