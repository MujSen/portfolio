<script setup>
const { status } = useAuth()
const userData = ref(null);
if (status.value === 'authenticated' && !userData.value) {
    const headers = useRequestHeaders(['cookie'])
    const { data } = await useFetch('/api/getuserinfo', { headers })
    userData.value = data.value.data;
}
</script>
<template>
    <div class="heroSection" :class="{ 'center': $route.path !== '/'}">
        <Nav :userData="userData"/>
        <NuxtPage v-if="$route.path === '/'"/>
        <NuxtPage v-if="$route.path !== '/'" :wasteCompanyBranch="userData.wasteCompanyBranch"/>
    </div>
    <Footer/>
</template>
<style scoped>
.heroSection {
    height: 100vh;
    max-width: 100vw;
    display: flex;
    flex-direction: column;
}
.center{
    gap: 12px;
}
</style>