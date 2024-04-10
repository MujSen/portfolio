<script setup lang="ts">
const { status, data, signOut, signIn } = useAuth()
definePageMeta({
  layout: 'default'
})
</script>
<template>
  <Hero />
</template>
<style scoped>
.error {
  color: red;
}
.heroSection{
  height: 100vh;
  max-width: 100vw;
  display: flex;
  flex-direction: column;
}
</style>
<style>
  button{
    border: none;
  }
</style>