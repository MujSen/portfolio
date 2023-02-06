# vue aplikace s názvem vstupni-test
- Pinia _pro ukládání globálních proměnných ve storu_
- Router _pro navigaci stránek_

## Jak spustit aplikaci
Aplikace je napsáná ve vue. Je teda potřeba mít node.js nainstalovaný.
Po stáhnutí a rozbalení:
- Zapněte cmd...
- Najděte cestu k souboru...
- Příkaz cd...
- npm install...
- npm run dev
  - _Projekt je nyní stáhnutý, node-modules jsou nainstalované a live server běží na localhost_

## Vysvětlení projektu
### Projekt se skládá z 2 komponentů
- Kosik.vue, _pro App.js_
- Produkt.vue, _pro HomeView.vue_
### 3 views
  - _jsou pak používany v App.js pro přepínání stránek_
- HomeView.vue
- KosikView.vue
- ProfilView.vue
### 2 storů
- kosik.js, _pro Kosik.vue a Produkt.vue_
- profil.js, _pro ProfilView.vue_
### src > components
  - _Zde se ukládají komponenty (kód jenž lze znovu využívat, má v sobě svůj styl, svojí logiku a template)_
- Kosik.vue
  - Používá kosik.js pro zjištění počtu položek.
  - Pokud není žádná, nezobrazí počet položek ani jako 0 pokud 0 < zobrazí 1,2... uprostřed košíku 
- Produkt.vue
  - Manipuluje s kosik.js
  - Vykonává všechny funkce, od přídávání položek, po odstraňování. Velmi komplexní. 
### src > router
- index.js _> importuje views z ../views a přiřazuje jim cestu._
- / _-> home -> HomeView -> ../views/HomeView.vue zobrazí se po načtení stránky, titulní stránka_
- /kosik _-> kosik -> KosikView -> ../views/KosikView.vue přepne uživatele do košíku po kliknutí na košík_
- /profil _-> profil -> ProfilView -> ../views/ProfilView.vue přepne uživatele do profilu_
struktura v App.js _(jak to vypadá)_
**img**
**nav** _> RouterLink - přepíná mezi stránky_
**RouterView** _- zobrazuje stránky_
### src > stores
- kosik.js
    - Má svoje funkce a proměnné, cílem je aby manipuloval sám se svýma proměnnýma, když se používá, používá jenom funkce.
    - Pro testování jsem nechal některé proměnné přístupné
  - count
    - má v sobě počet položek v košíku
  - polozky
    - uchovává položky
  - cenaZaVse  
    - celková cena za všechny položky
  - pridejDoPole()
    - Manipuluje s polozky, odstraňuje + přidává. 
    - Manipuluje s count, sčítá + odčítá
    - Manipuluje s cenaZaVse, sčítá + odčítá
  - existujeVPoli()
    - Hledá v poli pomocí id, a jestli je položka v poli vrátí true
  - vratZPole()
    - Hledá v poli pomocí id, a jestli je položka v poli vrátí ji
- profil.js
  - uzivatele
    - Pole s uživateli, jeden je zadán jako testovní, jde se jako on přihlásit.
  - chyboveHlasky
    - Chybové hlášky pro mě nepužívají se nikde jinde, trochu jsem je i zapoměl smazat.
  - pridatUzivatele()
    - Přidá uživatele do pole uživatele.
    - Pokud je více uživatelů v poli začne hledat jestli již uživatel existuje s emailem nebo jménem.
    - Ověří jestli je email ve správném formátu, heslo je dostatečně silné (nešel mi z nějakého důvodu regex, tak jsem použil jen že musí být delší než 8 charakterů).
    - Pokud není error vytvoří id a přidá (Není přidané ověření id jestli již neexistuje v poli).
  - vypisChyboveHlasky()
    - Vypíše chybovou hlášku z chyboveHlasky. Taky by se mohl už smazat. Používal jsem pro zpříjemnění testování.
### src > views
- HomeView.vue
  - Používá komponment z src/components/Produkt.vue
    - Tento komponent sám osobně nazývám samostatný, jelikož umí všechno sám
  - v data()
    - Má uložený list objektů, každý pak vypisuje a jeho vlastnosti dává komponentu Produkt, který pak zařizuje všechnu svojí logiku.
  - ? Když se teď dívám s odstupem nemusel se deklarovat store, jelikož se nepoužívá
- KosikView.vue
  - Stejně jako HomeView používá z src/components/Produkt.vue
  - Používá store usePolozkyStore from '@/stores/kosik.js'
- ProfilView.vue
  - Používá store useProfilStore from '@/stores/profil.js'
  - Má 3 div elementy, každý se zobrazí v-if je splněná podmínka.
    - První se zobrazí jestli není přihlášen a není registrován
    - Druhý se zobrazí jestli se zaregistroval
    - Třetí se zobrazí jestli se přihlásil
