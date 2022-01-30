
// stringin önce split metodu ile ayrılır, daha sonra elemanların yeri ters çevirilir ve join ile birleştirilir.
let reverse=(str)=> str.split("").reverse().join("");
// string kopyalanır,daha sonra elemanların yeri ters çevirilir ve join ile birleştirilir.
let reverse2=(str)=> [...str].reverse().join("");

// stringin indexleri tersten okunarak boş bir stringe + ile ekelnir
let reverse3=(str)=>{
    let newString="";
    for (var i = str.length - 1; i >= 0; i--) {
        newString += str[i];
    }
    return newString;
}

// stringin indexleri tersten okunarak bir array'a pushlanır 
// join metodu ile birleştirilir
let reverse4=(str)=>{
    let newString=[];
    for (var i = str.length - 1; i >= 0; i--) {
        newString.push(str[i]);
    }
    return newString.join('');
}

//reduce metotu current değer ile previous değeri toplar.
//reduce metodundaki acc parametresi previous,char parametresi current değeri belirtir,
// default previous değer ise '' olarak boş string olarak verilmiştir.
// acc+char yerine char + acc return edildiğinde prev+curr toplanarak iterasyonlar gerçekleştirilir
// bunun yerine reduceRight metodu ile iterasyonların tersten yapılması sağlanabilir.
//itration 1: 'e'   =>acc=''+char='e' 
//itration 2: 'de'  =>acc='e'+char='d'
//itration 3: 'ade' =>acc='ed'+char='a'
let reverse5=(str)=>[...str].reduce((acc, char) => char + acc, '');

//itration 1: 'a'   =>acc=''+char='a' 
//itration 2: 'ad'  =>acc='a'+char='d'
//itration 3: 'ade' =>acc='ad'+char='e'
let reverse6=(str)=>[...str].reduceRight((acc, char) => acc+char, '');

console.log(reverse("eda"));
console.log(reverse2("eda"));
console.log(reverse3("eda"));
console.log(reverse4("eda"));
console.log(reverse5("eda"));
console.log(reverse6("eda"));
