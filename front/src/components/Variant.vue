<template>
<li>
      <span>
          <input type="checkbox">
          {{variant.name}}
      </span>
  </li>
  
</template>

<script>
export default {
  props: {
    variant: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style scoped>
li {
    border: 1px  double rgb(60, 142, 180); /* Параметры границы */
    border-radius: 8px;
    background: ghostwhite;
    padding: 5px; /* Поля вокруг текста */
    display: flex;
    margin-bottom: 5px;
    width: 100%;
}
.container {
    
    padding: 2px;
}
</style>
