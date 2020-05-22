<template>
<li>
      <span>
          <input v-if="changed.length < poll.maxVariantByUser" type="checkbox" v-on:change="$emit('change',variant.id)">
          <input v-else-if="variant.choose == true" type="checkbox" v-on:change="$emit('change',variant.id)">
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
    poll: {
      type: Object,
      required: true,
    },
    changed: {
      type: Array,
      required: true,
    },
    index: {
      required: true,
    },
  },
  mounted() {
  }
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
    width: 90%;
}
.container {
    
    padding: 2px;
}
</style>
