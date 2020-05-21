<template>
<div>
 <h1>Simple voting</h1>
    <hr />
    <div class="header-center">
		<ul>
			<li><router-link :to="{ name: 'MyPolls', params: {UserId}}" tag="button">Мои опросы </router-link></li>
			<li><router-link :to="{ name: 'AddPoll', params: {UserId}}" tag="button">Добавить опрос</router-link></li>
			<li><router-link :to="{ name: 'home', params: {UserId}}" tag="button" >Все опросы</router-link></li>
		</ul>
	</div>
    <div class="addpoll-container">
    <h2>Создайте новый опрос</h2>
    <div class="names">
      <input type="text" placeholder="Введите имя..." v-model="name" />
      <input
        type="text"
        placeholder="Введите дату конца опроса..."
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
        v-on:change="isCanAddVariats = !isCanAddVariats"
      />
      <label for="canVoting">
        Возможность другим юзерам добавлять варианты</label
      >
        </div>    
    </div>
        <input type="text" v-model="href" v-if="href">
    <button v-if="IsCorrect()" v-on:click="addPoll()">
      <Zondicon icon="AddOutline" class="icon" />
    </button>
  </div>
</div>
  
</template>

<script>
import Zondicon from "vue-zondicons";
export default {
  data() {
    return {
      name: '',
      date: '',
      Count: '',
      UserId: this.$route.params.id,
      isCanAddVariats: 0,
      isActive: 0,
      variants: 2,
      nameVariant: '',
      href: ''
    };
  },
  components: {
    Zondicon,
  },
  methods: {
    IsCorrect() {
      let res = false;
      if ((this.name != "" && this.date != "", this.Count != "")) {
        res = true;
      }
      return res;
    },
    addPoll() {
      let newPoll = {
        Id: 1,
        Name: this.name,
        DatePublication: new Date(),
        DeadLine: new Date(this.date),
        Author_Id: +this.UserId,
        MaxVariantByUser: +this.Count,
        isActive: Boolean(this.isActive),
        IsCanAddVariants: Boolean(this.isCanAddVariats),
      };
      let responce = fetch("https://localhost:5001/api/poll", {
        method: "POST",
        headers: { "Content-Type": "application/json;charset=utf-8" },
        body: JSON.stringify(newPoll)
      }).finally(() => {
        fetch("https://localhost:5001/api/Poll")
          .then((response) => response.json())
          .then((json) => {
            let polls = json
            this.href = 'Ссылка на опрос: http://localhost:8080/Poll/' + polls[polls.length - 1].id
          });
          //this.$router.push({ path: `/MyPolls/${this.UserId}` })
      });
    },
  },
};
</script>

<style scoped>
ul {
  list-style: none;
  display: flex;
  justify-content: space-around;
}
strong {
  margin-bottom: 15px;
  margin-top: 15px;
}
.addpoll-container {
  height: 400px;
  display: flex;
  flex-direction: column;
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
.icon {
  margin-top: 20px;
  width: 25px;
  height: 25px;
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
.names {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  height: 100px;

}
.variants {
  display: flex;
  flex-direction: column;
  justify-content: space-around;
}
hr {
  color: lawngreen;
  height: 1px;
  width: 100%;
  background: lawngreen;
}
.checkboxes {
    margin: 20px;
}
</style>
