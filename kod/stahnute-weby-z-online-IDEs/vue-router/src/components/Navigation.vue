<template>
  <ul>
    <li>
      <router-link to="/">Domů</router-link>
    </li>
    <li>
      <router-link to="/about">O hře</router-link>
    </li>
    <li>
      <router-link to="/todos">Pravidla</router-link>
    </li>
    <li>
      <router-link to="/zprava">Zpráva</router-link>
    </li>
    <li>
      <router-link to="/obliben">Oblíbený hráč</router-link>
    </li>
  </ul>
</template>

<script>
export default {
  name: "Navigation",
};
</script>

<style scoped lang="scss">
ul {
  margin: 0;
  padding: 0;
  display: flex;
  justify-content: space-around;
  list-style-type: none;
  li {
    a {
      color: #EDEDED;
      text-decoration: none;
    }
  }
}
</style>