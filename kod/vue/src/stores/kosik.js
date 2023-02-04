import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

export const usePolozkyStore = defineStore('kosik', () => {
  const count = ref(0);
  const polozky = [];
  const cenaZaVse = ref(0);

  function pridejDoPole(el) {
    let exists = false;

    polozky.forEach((p, index) => { //p = item, index
      if (p.id === el.id) { //pokud existuje
        exists = true;
        if (el.pocet < 1) { //pokud je pocet v nové proměnné nižší jak 1  =  0,-1
          polozky.splice(index, 1); //Odstranění
          cenaZaVse.value -= p.celkCen;
        } else { //Není nižší
          p.pocet = el.pocet; // změní se 
          cenaZaVse.value -= p.celkCen;
          p.celkCen = el.cena*el.pocet;
          cenaZaVse.value += p.celkCen;
        }
      }
    });
    if (!exists && el.pocet > 0) {  //Pokud neexistuje a jeho počet je véětší jak 0 = 1,2
      el.celkCen = el.cena*el.pocet;
      cenaZaVse.value += el.celkCen;
      polozky.push(el);
    }
    count.value = polozky.length;
  }
  function vratCenu(id){
    let cel = 0;
    polozky.forEach((p) =>{
      if (p.id === id) {
        cel = p.celkCen;
      }
    })
    return cel
  }
  function existujeVPoli(ide){
    let ff = false;
    polozky.forEach((p) =>{
      if (p.id === ide) {
        ff= true;
      }
    })
    return ff;
  }
  function vratZPole(ide){
    let ff;
    polozky.forEach((p) =>{
      if (p.id === ide) {
        ff= p;
      }
    })
    return ff;
  }

  return { count, pridejDoPole, polozky, vratCenu,existujeVPoli,vratZPole,cenaZaVse}
})
