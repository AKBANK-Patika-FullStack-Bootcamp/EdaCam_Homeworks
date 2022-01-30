//sayının yarısına 3 ekleyen fonksiyon
const girslPowerToplam=(sayi)=>(sayi/2)+3; 

//high order fonksiyon
//fonksiyon bir parametre alarak diğer parametresi olan arrayi mapleyerek itemlarında bu fonksiyonu çağırır.
const girlsPower=(toplamFunc,arr)=>arr.map((item)=>toplamFunc(item));

const array=[2,3,4];
console.log("cikti ", girlsPower(girslPowerToplam,array));

