import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

export const useProfilStore = defineStore('profil', () => {
    const uzivatele = [{id: 25, email: "fran@seznam.cz",jmeno: "test",heslo: "prihlasitUzivatele" }]
    const chyboveHlasky = {
        EMAIL_EXISTS: "Email již existuje.",
        JMENO_EXISTS: "Jméno již existuje.",
        EMAIL_INVALID: "Email není platný.",
        JMENO_INVALID: "Jméno musí být alespoň 3 znaky dlouhé.",
        HESLO_INVALID: "Heslo není dostatečně silné. Použijte alespoň 8 znaků, včetně velkých písmen, malých písmen a čísel."
      };

      function pridatUzivatele(email, jmeno, heslo) {
        let error = "";
        if (uzivatele.length>0) {
            for (let uzivatel of uzivatele) {
                if (uzivatel.email === email) {
                  error += "E";
                }
                if (uzivatel.jmeno === jmeno) {
                  error += "J";
                }
              }
        }
        
        if (!/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(email)) {
          error += "M";
        }
        
        if (jmeno.length < 3) {
          error += "N";
        }
        
        //if (!/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#\$%\^&\*])([a-zA-Z\d!@#\$%\^&\*]{8,})$/.test(heslo)) {
            
        if(heslo.length<8){ //Měl jsem zde regex ale nešel mi
          error += "P";
        }
        
        if (!error) {
          const id = Math.random().toString(36).substring(2, 15) + Math.random().toString(36).substring(2, 15);
          uzivatele.push({ id, email, jmeno, heslo });
        }
        return error;
      }
      function vypisChyboveHlasky(error) {
        if (!error) {
          console.log("Úspěšně přidán uživatel.");
          return;
        }
        
        for (const ch of error) {
          console.log(chyboveHlasky[ch]);
        }
      }
      function prihlasitUzivatele(email, heslo) {

        let error = "";
      
        if (!email || !heslo) {
          if (!email) {
            error += "E";
          }
          if (!heslo) {
            error += "H";
          }
          return error;
        }
      
        for (const uzivatel of uzivatele) {
          if (uzivatel.email === email || uzivatel.jmeno === email  && uzivatel.heslo === heslo) {
              return "";
            } else {
              return "P";
            }
          }

        }
      

    return { pridatUzivatele,vypisChyboveHlasky,prihlasitUzivatele,uzivatele }

})