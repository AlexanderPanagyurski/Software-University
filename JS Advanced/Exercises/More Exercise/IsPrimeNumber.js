console.log(IsPrime(11))

function IsPrime(number){
    let isPrime=true;
    for (let index = 2; index <= Math.sqrt(number); index++) {
            if(number%index==0){
                isPrime=false;
                break;
            }
    }
    return isPrime;
}