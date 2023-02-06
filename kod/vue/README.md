# vue aplikace s názvem vstupni-test
- Pinia pro ukládání globálních proměnných ve storu
- Router pro navigaci stránek

## Jak spustit aplikaci
Aplikace je napsáná ve vue. Je teda potřeba mít node.js nainstalovaný.
Po stáhnutí a rozbalení:
- Zapněte cmd...
- Najděte cestu k souboru...
- Příkaz cd...
- npm install...
- npm run dev
  - Projekt je nyní stáhnutý, node-modules jsou nainstalované a live server běží na localhost

## Vysvětlení projektu
Projekt se skládá z 2 komponentů
- Kosik.vue, pro App.js
- Produkt.vue, pro HomeView.vue
3 views jenž jsou pak používany v App.js pro přepínání stránek
- HomeView.vue
- KosikView.vue
- ProfilView.vue
2 storů
- kosik.js, pro Kosik.vue a Produkt.vue
- profil.js, pro ProfilView.vue
### src > components - Zde se ukládají komponenty (kód jenž lze znovu využívat, má v sobě svůj styl, svojí logiku a template)
- Kosik.vue
- Produkt.vue
### src > router
- index.js > importuje views z ../views a přiřazuje jim cestu.
- / -> home -> HomeView -> ../views/HomeView.vue zobrazí se po načtení stránky, titulní stránka
- /kosik -> kosik -> KosikView -> ../views/KosikView.vue přepne uživatele do košíku po kliknutí na košík
- /profil -> profil -> ProfilView -> ../views/ProfilView.vue přepne uživatele do profilu
struktura v App.js (jak to vypadá)
img
nav > RouterLink - přepíná mezi stránky
RouterView - zobrazuje stránky
### src > stores
- kosik.js <- Má svoje funkce a proměnné, cílem je aby manipuloval sám se svýma proměnnýma a jakýkoliv kód, co ho používá, používá jenom jeho funkce. Pro testování jsem nechal některé proměnné přístupné
  - count <- má v sobě počet položek v košíku
  - polozky <- uchovává položky
  - cenaZaVse  <- celková cena za všechny položky
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
