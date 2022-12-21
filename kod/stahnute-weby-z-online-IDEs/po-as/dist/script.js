let lon= document.querySelector(".lon");
let lat= document.querySelector(".lat");
let buut = document.querySelector("#but");

//Přidání eventu na klik
buut.addEventListener("click",()=>{
  if(lon.value=="" || lat.value==""){}
  else{
    VyhledejA();
  }
});

//Funkce pro api pomocí fetch
function Vyhledej(){
fetch('https://api.open-meteo.com/v1/forecast?latitude='+lat.value+'&longitude='+lon.value+'&hourly=temperature_2m&temperature_unit=celsius')
  .then((respon)=> respon.json())
  .then((data) => {
  ZmenData(data);
});
  
  
}
//Funkce pro api pomocí XMLHttpRequest (zastaralé)
function VyhledejX(){
  let request = new XMLHttpRequest();
  request.open("GET",'https://api.open-meteo.com/v1/forecast?latitude='+lat.value+'&longitude='+lon.value+'&hourly=temperature_2m&temperature_unit=celsius');
  request.send();
  request.onload = () =>{
    if(request.status == 200){
      ZmenData(JSON.parse(request.response));
    }
    else{
      console.log("ajajaj chyba");
    }
  }
}
//Fetch s async await
async function VyhledejA(){
  let response = await fetch('https://api.open-meteo.com/v1/forecast?latitude='+lat.value+'&longitude='+lon.value+'&hourly=temperature_2m&temperature_unit=celsius');
  let data = await response.json();
  await ZmenData(data);
}
//Změnení dat na stránce
function ZmenData(data){
  document.querySelector(".aa").textContent="Teď " + data.hourly.temperature_2m[0];
  document.querySelector(".aaa").textContent="Za hodinu " + data.hourly.temperature_2m[1];
  document.querySelector(".aaaa").textContent="Za 2 hodiny " + data.hourly.temperature_2m[2];
  document.querySelector(".aaaaa").textContent="Za 3 hodiny " + data.hourly.temperature_2m[3];
  document.querySelector(".aaaaaa").textContent="Za 4 hodiny " + data.hourly.temperature_2m[4];
}