<script setup>
const { status, data, signOut, signIn } = useAuth()
let show = ref(false);
const props = defineProps(['userData']);

/*const wasteCompanyBranch = useCookie('wasteCompanyBranch');
const userData = ref(null);
if (status.value === 'authenticated' && userData.value === null) {
    const headers = useRequestHeaders(['cookie'])
    const { data } = await useFetch('/api/getuserinfo', { headers })
    userData.value = data.value.data;
    console.log("TEST", userData);
    wasteCompanyBranch.value=userData.value.wasteCompanyBranch;
}*/
</script>

<template>
    <nav>
        <div class="logo">
            <img src="~/assets/svg/logo.svg" alt="logo">
            <p>ECONIT</p>
        </div>
        <ul>
            <li><a href="/" v-if="$route.path !== '/'">Domů</a></li>
            <li v-if="status === 'authenticated' && $route.path !== '/pobocka'"><a href="/pobocka">Moje pobočka</a></li>
        </ul>
        <div class="profile">
            <button @click="() => show = !show">
                <img src="~/assets/svg/profilePicture.svg" alt="" v-if="status === 'authenticated'" :class="{ 'auth': status === 'authenticated' }">
                <img src="~/assets/svg/profile.svg" alt="profile" v-else>
            </button>
            <ProfilePopup v-if="show" :userData="props.userData"/>
        </div>
    </nav>
</template>
<style scoped>
nav {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 20px 40px;
    background-color: #86BB47;
}
nav > *{
    flex: 1;
    text-align: center;
}
button img{
    width: 60px;
    aspect-ratio: 1/1;
    
}
.auth{
    background-color: #fff;
    border-radius: 999999px;
    padding: 5px;
    width: 60px;
}
.logo {
    display: flex;
    align-items: center;
    gap: 8px;
    font-weight: 700;
}

.profile {
    position: relative;
    text-align: right;
}

ul {
    list-style-type: none;
    display: flex;
    justify-content: center;
    gap: 8px;
    color: #fff;
}

ul li {
    transition: color 1s;
}

ul li:hover {
    color: #618D2D;
}
</style>