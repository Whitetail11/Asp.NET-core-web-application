<template>
<div class="container">
    <ul v-if="this.isvisible()"><strong>{{poll.name}}?  <button v-on:click="$emit('deletePoll', poll.id)" class="deletePoll"><Zondicon icon="CloseOutline" class="icon" v-if="isthisUser()"/></button></strong>
    <Variant 
        v-for="variant in poll.variants"
        :key="variant.id"
        v-bind:variant="variant"
        v-on:change="change"
    />

    <input type="text" placeholder="Введите новый вариант ответа..." v-model="name" v-if="UserId==poll.author_Id">
    <div class="button-container">
        <button class="buttons"
            v-if="name != ''"
            v-on:click="$emit('addvar', poll.id, name),name = ''">Добавить вариант ответа
        </button>
        
        <button class="buttons" v-on:click="$emit('voting', UserId, changed),name = ''">Проголосовать</button>
    </div>
    </ul>
    <ul v-else><strong>{{poll.name}}?</strong>
    <progressVariant 
        v-for="variant in poll.variants"
        :key="variant.id"
        v-bind:variant="variant"
        v-bind:poll="poll"
        v-bind:UserId="UserId"
    />
    </ul>
</div>
</template>

<script>
import Zondicon from "vue-zondicons";
import Variant from '@/components/Variant.vue'
import progressVariant from '@/components/progress-variant.vue'
export default {
    data() {
        return {
            name: '',
            changed: []
        }
    },
    methods: {
      isthisUser() {
        let res = false;
        console.log(this.poll.id)
        if(this.poll.author_Id == this.UserId) {
          res = true;
        } return res
      },
      change(id) {
        for(let i = 0; i < this.poll.variants.length; i++) {
          if(this.poll.variants[i].id == id) {
            if( this.poll.variants[i].choose == false) {
              this.changed.push( this.poll.variants[i].id)
              this.poll.variants[i].choose = ! this.poll.variants[i].choose
            } else {
              this.changed.pop( this.poll.variants[i].id)
            this.poll.variants[i].choose = ! this.poll.variants[i].choose
            }
          }
        }
      },
    isvisible: function() {
        for (let i = 0; i < this.poll.variants.length; i++) {
          for (let j = 0; j < this.poll.variants[i].users.length; j++) {
            if (this.UserId == this.poll.variants[i].users[j].id) { 
              return false;
            }
          }
      }
      return true;
    },
  },
  props: {
    poll: {
      type: Object,
      required: true,
    },
    UserId: {
        required: true,
    }
  },
  components: {
      Variant,progressVariant,Zondicon
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
    .buttons {
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
.buttons:hover {
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
    width: 90%;
    outline: none;
}
strong {
  margin-bottom: 5px;
}
.icon {
  height: 15px;
  width: 15px;

}
.deletePoll {
  background: none;
  border: none;
  cursor: pointer;
}
</style>
