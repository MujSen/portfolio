<template>
  <NuxtLayout name="404">
    <div>
      <p>Stránka bohužel neexistuje</p>
      <button class="font-bold button" @click="goBack">Jít domů</button>
    </div>
  </NuxtLayout>
</template>

<script setup>
  navigateTo('/error')
</script>


<style scoped>
.button {
  padding: 4px 6px;
  margin: 10px 0px;
  background: black;
  color: white;
}
</style>