<script setup>
const { status, data, signOut, signIn } = useAuth()

</script>
<template>
    <main>
        <div class="text">
            <h1>Chytré odpady</h1>
            <h2>Můžete se na nás spolehnout</h2>
        </div>
        <button @click="signIn('openid-connect', { callbackUrl: '/pobocka' })">Přihlásit se ➜</button>
    </main>
    <img src="~/assets/svg/recycling.svg" alt="recycle" class="recBack">

</template>
<style scoped>
    main{
        flex: 1;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        gap: 28px;
    }
    .recBack{
        position: absolute;
        right: 40px;
        bottom: 40px;
        z-index: -1;
        width: 30vw;
    }
    .text{
        display: flex;
        flex-direction: column;
        gap: 4px;
        color: #618D2D;
        text-align: center;
    }
    h2{
        color: #86BB47;
    }
    button{
        background-color: #86BB47;
        background: linear-gradient(to left, #3D5520, #86BB47 100%);
        padding: 20px 40px;
        color: #fff;
        border-radius: 1000px;
        font-size: 32px;
        font-weight: 500;
        background-size: 400% 400%;
    }
    button:hover{
        animation: linearColorChange 2s both;
    }
    @keyframes linearColorChange {
        0% {
            background-position: 0% 50%;
        }
        100% {
            background-position: 100% 50%;
        }
    }
</style>