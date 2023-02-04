<script>
import Produkt from '../components/Produkt.vue';
import { usePolozkyStore } from '@/stores/kosik.js'

export default {
  setup() {
    const store = usePolozkyStore()

    return {
      store,
    }
  },
  data() {
    return {
      products: [
        { id: "AIX", txt: "Apple iPhone XR", cena: 500, img: "https://im9.cz/iR/short-tail/418754--mm1200x1200.jpg" },
        { id: "SGS", txt: "Samsung Galaxy S10", cena: 669, img: "https://d25-a.sdn.cz/d_25/c_img_H_GB/xpuBCPB.jpeg" },
        { id: "GP3", txt: "Google Pixel 3", cena: 12, img: "https://d25-a.sdn.cz/d_25/c_img_H_Fi/8E3BQtT.jpeg" },
        { id: "O7P", txt: "OnePlus 7 Pro", cena: 12356, img: "https://www.mall.cz/i/43048080/1000/1000" },
        { id: "HPP", txt: "Huawei P30 Pro", cena: 33224, img: "https://d25-a.sdn.cz/d_25/c_img_G_G4/fssCECI.jpeg" },
        { id: "LVT", txt: "LG V40 ThinQ", cena: 4000, img: "https://im9.cz/iR/importprodukt-orig/c62/c628047623a116d30434da5b44caa7f5--mmf350x350.jpg" },
        { id: "AMP", txt: "Apple MacBook Pro", cena: 3000, img: "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/og-macbook-pro-202301?wid=1200&hei=630&fmt=jpeg&qlt=95&.v=1670261864358" },
        { id: "MSP", txt: "Microsoft Surface Pro", cena: 60000, img: "https://cdn-dynmedia-1.microsoft.com/is/image/microsoftcorp/Surface-Pro-8-HL-Powerful:VP1-539x400" },
        { id: "DX1", txt: "Dell XPS 13", cena: 19000, img: "https://www.dellpoint.cz/e-shop/ilustration-exa.ashx?type=big&urli=D-N-9320-N3-714K/xs9320nt-xnb-shot-5-2-gy_s.jpg" },
        { id: "HPX", txt: "HP Spectre x360", cena: 20000, img: "https://cdn.myshoptet.com/usr/www.pocitarna.cz/user/shop/big/126743_hp-spectre-x360-16--1.jpg?63ab3922" }
      ]
    }
  },
  components: {
    Produkt
  }
}

</script>

<template>
  <main>
    <ul>
      <li v-for="product in products" :key="product.id">
        <Produkt :txt="product.txt" :img="product.img" :cena="product.cena" :id="product.id"/>
      </li>
    </ul>
  </main>
</template>
<style scoped>
  ul{
    display: flex;
    justify-content: space-around;
    flex-wrap: wrap;
  }
  ul li{
    background-color: rgb(18, 18, 19);
    padding: 2%;
  }
</style>
