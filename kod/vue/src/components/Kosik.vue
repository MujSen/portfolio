<template>
  <div>
    <img src="https://img.icons8.com/ios-filled/256/shopping-basket.png" alt="koš">
    <p v-if="store.count!=0">{{ store.count }}</p>
  </div>
</template>

<script>
import { usePolozkyStore } from '@/stores/kosik.js'
export default {
  setup() {
    const store = usePolozkyStore()

    return {
      store,
    }
  },
}
</script>

<style scoped>
div{
    position: relative;
    width: fit-content;
}
    img{
        max-width: 100px;
        position: relative;
    }
    p{
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%,-50%);
        z-index: 1;
        color: black;
    }
    p:before{
        content: " ";
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%,-50%);
        background-color: aquamarine;
        width: 500%;
        aspect-ratio: 1/1;
        border-radius: 100%;
        z-index: -1;
    }
</style>