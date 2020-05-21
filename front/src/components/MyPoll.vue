<template>
  <div class="container">
    <ul v-if="poll.author_Id == UserId && poll.isActive == 0">
    
      <strong>(Не активный)
        <button class="deletePoll" v-on:click="$router.push({ path: `/EditPoll/${poll.id}` })"><Zondicon icon="EditPencil" class="icon"/></button>
        <button v-on:click="$emit('deletePoll', poll.id)" class="deletePoll"><Zondicon icon="CloseOutline" class="icon"/></button>
        </strong>
      <strong>{{ poll.name }}? </strong>
      <Variant
        v-for="variant in poll.variants"
        :key="variant.id"
        v-bind:variant="variant"
        v-on:change="change"
      />
      <input
        type="text"
        placeholder="Введите новый вариант ответа..."
        v-model="name"
        v-if="poll.isActive == 0"
      />
      <div class="button-container">
        <button
          class="buttons"
          v-if="name != ''"
          v-on:click="$emit('addvar', poll.id, name), (name = '')"
        >
          Добавить вариант ответа
        </button>
        <button
          v-if="(+(new Date(this.poll.deadLine)  - new Date())/(60*60*24*1000)).toFixed(1) > 0"
          class="buttons"
          v-on:click="$emit('active', poll.id)"

        >
          Опубликовать
        </button>
        <strong v-else>Опрос окончен</strong>
      </div>
    </ul>
    <ul v-if="poll.author_Id == UserId && poll.isActive == 1">
         
      <strong>(Активный)
         <button class="deletePoll" v-on:click="$router.push({ path: `/EditPoll/${poll.id}` })"><Zondicon icon="EditPencil" class="icon"/></button>
        <button v-on:click="$emit('deletePoll', poll.id)" class="deletePoll"><Zondicon icon="CloseOutline" class="icon"/></button>
         </strong>
      <strong>{{ poll.name }}? </strong>
      <Variant
        v-for="variant in poll.variants"
        :key="variant.id"
        v-bind:variant="variant"
        v-on:change="change"
      />
    </ul>
  </div>
</template>

<script>
import Variant from "@/components/Variant.vue";
import Zondicon from "vue-zondicons";
export default {
  data() {
    return {
      name: "",
    };
  },
  components: {
    Variant, Zondicon 
  },
  props: {
    poll: {
      type: Object,
      required: true,
    },
    UserId: {
      required: true,
    },
  },
  methods: {
      change() {
          return 0
      }
  }
};
</script>

<style scoped>
.icon {
  height: 15px;
  width: 15px;
}

.deletePoll {
  background: none;
  border: none;
  width: 10px;
  cursor: pointer;
  margin-left: 10px;
}
.button-container {
  display: flex;
  justify-content: space-between;
  padding-left: 10px;
}
ul {
  list-style: none;
  margin: 0;
  padding: 5px;
  display: flex;
  flex-direction: column;
  text-align: start;
  padding-bottom: 10px;
}
hr {
  color: lawngreen;
  height: 1px;
  width: 100%;
  background: lawngreen;
}
input {
  border: 1px double rgb(60, 142, 180); /* Параметры границы */
  border-radius: 8px;
  background: ghostwhite;
  padding: 5px; /* Поля вокруг текста */
  display: flex;
  margin-bottom: 5px;
  width: 90%;
  outline: none;
}
.buttons {
  background-color: #4caf50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 30%;
  opacity: 0.9;
}
</style>
