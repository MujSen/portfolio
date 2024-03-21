<script setup>
const { status, data, signOut, signIn } = useAuth()

</script>
<template>
  <section>
    <div>
      <h2>Vypadá to že nejsi přihlášen</h2>
      <button class="flex items-center justify-center space-x-2 bg-green-500 text-white rounded-lg py-2 px-3 text-lg"
        @click="signIn('openid-connect')">
        <span>Login</span>
      </button>
    </div>
  </section>
</template>
<style scoped>
section {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100%;
  height: 100vh;
  box-sizing: content-box;
}

section div {
  box-sizing: border-box;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

section div h2 {
  margin-bottom: 1rem;
}
</style>