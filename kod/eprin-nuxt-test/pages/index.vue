<script setup lang="ts">
const { status, data, signOut, signIn } = useAuth()
const headers = useRequestHeaders(['cookie']) as HeadersInit
const userData = ref(null);
const userError = ref(null);
if (status.value === 'authenticated') {
  const { data } = await useFetch('/api/getuserinfo', { headers })
  userData.value = data.value;
}
else {
  console.log("NENí");
}
</script>
<template>
  <Header v-if="userData && userData.data" :userData="userData" />
  <WorkersTable v-if="userData && userData.data && userData.data.wasteCompanyBranch && userData.data.wasteCompanyBranch.id" :id="userData.data.wasteCompanyBranch.id"/>
  <LoginCard v-if="status !== 'authenticated'" />
  <button class="flex items-center justify-center space-x-2 bg-red-500 text-white rounded-lg py-2 px-3 text-lg" @click="signOut({ callbackUrl: '/' })">
    <span>Logout</span>
  </button>
  <p v-if="userError" class="error">{{ userError }}</p>
</template>
<style>
  .error{
    color: red;
  }
</style>