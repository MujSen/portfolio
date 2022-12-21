let ubehl = 0;

(function vyvolej(){
let d = new Date();
document.querySelector(".h").textContent=d.getHours();
document.querySelector(".m").textContent=d.getMinutes();
document.querySelector(".s").textContent=d.getSeconds();
 //Konec času
  
ubehl +=1;
let ub =document.querySelector(".ube");

if( Math.floor(ubehl/60) > 0){
  ub.textContent="Uběhlo "+ ubehl +" sekund " + Math.floor(ubehl/60) + " minut";
  
}
else if(Math.floor(ubehl/3600) > 0){
  
ub.textContent="Uběhlo "+ ubehl +" sekund " + Math.floor(ubehl/60)+ " minut " + Math.floor(ubehl/3600) + " hodin ";

}
  else{
    ub.textContent="Uběhlo "+ ubehl + " sekund ";
    
  }

setTimeout(vyvolej, 1000);
})();
