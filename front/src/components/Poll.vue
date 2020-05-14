<template>
<div class="container">
    <ul><strong>{{poll.name}}?</strong>
    <Variant 
        v-for="variant in poll.variants"
        :key="variant.id"
        v-bind:variant="variant"
    />
    <input type="text" placeholder="Введите новый вариант ответа..." v-model="name">
    <div class="button-container">
        <button 
            v-if="name != ''"
            v-on:click="$emit('addvar', poll.id, name),name = ''">Добавить вариант ответа
        </button>
        
        <button>Проголосовать</button>
    </div>
    </ul>
</div>
</template>

<script>
import Variant from '@/components/Variant.vue'
export default {
    data() {
        return {
            name: ''
        }
    },
  props: {
    poll: {
      type: Object,
      required: true,
    },
  },
  components: {
      Variant
  }
};
</script>

<style scoped>
    ul {
        list-style: none;
        margin: 0;
        padding: 5px;
        display: flex;
        flex-direction: column;
        text-align: start;
        padding-bottom: 10px;

    }
    button {
  background-color: #4CAF50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 30%;
  opacity: 0.9;
}
.button-container {
    display: flex;
    justify-content: space-between;
    padding-left: 10px;
}
button:hover {
  opacity:1;
}
.container {
    width: 60%;
    display: flex;
    flex-direction: column;
    justify-content: start;
    margin: 0;
}
input {
    border: 1px  double rgb(60, 142, 180); /* Параметры границы */
    border-radius: 8px;
    background: ghostwhite;
    padding: 5px; /* Поля вокруг текста */
    display: flex;
    margin-bottom: 5px;
    width: 100%;
    outline: none;
}
</style>
