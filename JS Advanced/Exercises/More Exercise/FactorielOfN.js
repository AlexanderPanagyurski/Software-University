console.log(Factoriel(10));


function Factoriel(input){
    let result=1;
    
    for (let index = 2; index <= input; index++) {
        result*=index;
    }

    return result;
}