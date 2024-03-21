<script setup>
    const props = defineProps(['userData'])
    const { status, data, signOut, signIn } = useAuth()
</script>
<template>
    <header v-if="props.userData && props.userData.data">
      <div class="card">
        <div class="profileImage w-32">
        </div>
        <div class="textContainer">
          <p v-if="props.userData.data.fullName" class="name">{{ props.userData.data.fullName }}</p>
          <ul class="profile" v-if="props.userData.data.roles" v-for="item in props.userData.data.roles">
            <li>{{ item.name }}</li>
          </ul>
          <button v-if="status === 'authenticated'" class="flex items-center justify-center space-x-2 bg-red-500 text-white rounded-lg py-1 px-3 text-md" @click="signOut({ callbackUrl: '/' })">
            <span>Odhlásit se</span>
          </button>
        </div>
      </div>
        <div class="branch" v-if="props.userData && props.userData.data">
            <img v-if="props.userData.data.wasteCompanyBranch && props.userData.data.wasteCompanyBranch.logoUrl"
                :src="'https://api-ts-dev.jrkdigital.eu/' + props.userData.data.wasteCompanyBranch.logoUrl" alt="profile img">
        </div>
    </header>


</template>
<style scoped>
header {
  background-color: aliceblue;
  display: flex;
  justify-content: space-around;
  align-items: center;
  padding: 10px;
}
.card {
  width: 210px;
  height: 280px;
  background: rgb(39, 39, 39);
  border-radius: 12px;
  box-shadow: 0px 0px 30px rgba(0, 0, 0, 0.123);
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: flex-start;
  transition-duration: .5s;
  box-sizing: content-box;
}
ul{
  list-style: none;
}
.profileImage {
  background: linear-gradient(to right,rgb(54, 54, 54),rgb(32, 32, 32));
  margin-top: 20px;
  aspect-ratio: 1/1;
  border-radius: 50%;
  box-shadow: 5px 10px 20px rgba(0, 0, 0, 0.329);
}

.textContainer {
  width: 100%;
  text-align: left;
  padding: 20px;
  display: flex;
  box-sizing: border-box;
  flex-direction: column;
  gap: 10px;
}

.name {
  font-size: 0.9em;
  font-weight: 600;
  color: white;
  letter-spacing: 0.5px;
}

.profile {
  font-size: 0.84em;
  color: rgb(194, 194, 194);
  letter-spacing: 0.2px;
}

.card:hover {
  background-color: rgb(106, 106, 106);
  transition-duration: .5s;
}
</style>