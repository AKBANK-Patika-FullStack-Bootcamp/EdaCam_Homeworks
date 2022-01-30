const {kopek}=require('./kopek.js')
const{kopekBakimSaati,kopegiTemizle}=require('./kopekBakimUtility')

console.log(`kopek adi : ${kopek.isim}\nkopek boyu : ${kopek.boy}`);
kopegiTemizle();
console.log(`kopek ilgi saati :${kopekBakimSaati}`)