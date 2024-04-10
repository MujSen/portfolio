<script setup>
const { status, data, signOut, signIn } = useAuth()
const props = defineProps(['userData'])
</script>
<template>
    <div class="profilePopup">
        <ul v-if="status === 'authenticated'">
            <li><button>Profil</button></li>
            <li><button @click="signOut({ callbackUrl: '/' })">Odhlásit se</button></li>
        </ul>
        <div class="profileInfo" v-if="status === 'authenticated'">
            <div class="picture">
                <img src="~/assets/svg/profilePicture.svg" alt="">
            </div>
            <div class="info">
                <p>{{ props.userData.fullName }}</p>
                <p>{{ props.userData.email }}</p>
            </div>
        </div>
        <ul v-else>
            <li><p>Nejste přihlášený</p></li>
            <li><button @click="signIn('openid-connect', { callbackUrl: '/pobocka' })">Přihlásit se</button></li>
        </ul>
    </div>
</template>

<style scoped>
.profilePopup {
    position: absolute;
    top: 100%;
    right: 0;
    background-color: #618D2D;
    padding: 10px;
    color: #FFFFFF;
    display: flex;
    align-items: top;
    width: fit-content;
    gap: 10px;
}
@media screen and (max-width: 500px) {
    .profilePopup{
        flex-direction: column;
    }
}
.profilePopup ul {
    display: flex;
    flex-direction: column;
    gap: 10px;
}

.profilePopup ul li button {
    padding: 10px 40px;
    border-radius: 5px;
    background-color: #86BB47;
    transition: background-color 0.4s ease-in-out;
    white-space: nowrap;
}

.profilePopup ul li button:hover {
    background-color: #6CB416;
}

.profileInfo {
    border-radius: 12px;
    display: flex;
    background-color: #87bb4780;
    height: fit-content;
    gap: 50px;
    padding: 10px 14px;
}

.picture {
    border-radius: 10000px;
    background-color: #FFFFFF;
    padding: 5px;
    aspect-ratio: 1/1;
    width: 60px;
    height: fit-content;
}
.info{
    display: flex;
    flex-direction: column;
    gap: 10px;
}
</style>