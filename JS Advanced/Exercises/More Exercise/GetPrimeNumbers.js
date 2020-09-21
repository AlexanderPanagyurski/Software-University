console.log(GetPrimeNumbers(2000,2100));

function GetPrimeNumbers(start,end){
    let numbersList=[];

    let isPrime=true;

    for (let currNumber = start; currNumber <= end; currNumber++) {
        
        for (let index = 2; index <= Math.sqrt(currNumber); index++) {
            if(currNumber%index===0){
             isPrime=false;   
             break;
            }
        }
        if(isPrime===true){
            numbersList.push(currNumber);
        }
        isPrime=true;
    }

    return numbersList;
}