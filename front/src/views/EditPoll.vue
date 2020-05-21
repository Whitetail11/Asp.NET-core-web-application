<template>
    <div>
         <h1>Simple voting</h1>
    <hr />
    <div class="editpoll-container">
    <h2>Редактируйте опрос:</h2>
    <div class="names">
      <input type="text" placeholder="Измените имя..." v-model="name" />
      <input
        type="text"
        placeholder="Измените дату конца опроса..."
        v-model="date"
      />
      <input
        type="text"
        placeholder="За сколько вариантов может одновременно проголосовать отвечающий..."
        v-model="Count"
      />
    </div>
    <div class="checkboxes">
        <div class="checkbox">
            <input
        type="checkbox"
        name="canVoting"
        v-on:change="isCanAddVariants = !isCanAddVariants"
        v-bind:checked="isCanAddVariants"
      />
      <label for="canVoting">
        Возможность другим юзерам добавлять варианты</label
      >
        </div>    
    </div>
    <button v-if="IsCorrect()" v-on:click="EditPoll()">
      <strong>Сохранить</strong>
    </button>
  </div>
    </div>
</template>

<script>
import Variant from "@/components/Variant.vue"
export default {
    data() {
        return {
            id: this.$route.params.id,
            poll: '',
            name: '',
            date: '',
            Count: '',
            isCanAddVariants: 0,
        }
    },
    mounted() {
         fetch("https://localhost:5001/api/Poll/" + this.id)
      .then((response) => response.json())
      .then((json) => {
        this.poll = json;
        console.log(this.poll)
      }).then(() => {
          this.name = this.poll.name 
          this.date = this.poll.deadLine
          this.Count = this.poll.maxVariantByUser
          this.isCanAddVariants = this.poll.isCanAddVariants
          
      });
    },
    components: {
        Variant,
    },
    methods: {
          IsCorrect() {
      let res = false;
      if ((this.name != "" && this.date != "", this.Count != "")) {
        res = true;
      }
      return res;
    },
    EditPoll() {
        this.poll.name = this.name
        this.poll.deadLine = new Date(this.date)
        this.poll.maxVariantByUser = +this.Count
        this.poll.isCanAddVariants = this.isCanAddVariants
        let responce = fetch("https://localhost:5001/api/poll", {
        method: "PUT",
        headers: { "Content-Type": "application/json;charset=utf-8"},
        body: JSON.stringify(this.poll)}).finally(() => {
            this.$router.push({ path: `/MyPolls/${this.poll.author_Id}` })
      })
    },
    },
}
</script>

<style scoped>
hr {
  color: lawngreen;
  height: 1px;
  width: 100%;
  background: lawngreen;
}
input[type="text"] {
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
.names {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  height: 100px;

}
.checkboxes {
    margin: 20px;
}
.editpoll-container {
  height: 400px;
  display: flex;
  flex-direction: column;
}
button {
  background-color: #4CAF50;
  color: white;
  padding: 14px 20px;
  margin: 0 auto;
  border: none;
  cursor: pointer;
  width: 30%;
  opacity: 0.9;
}
button:hover {
  opacity:1;
}

</style>