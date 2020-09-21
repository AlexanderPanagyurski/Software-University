console.log(GetArmstronNumbersBetween(153,407))

function GetArmstronNumbersBetween(start,end){
    let sequence=[];
    let isArmstrongNumber=true;

    for (let index = start; index <= end; index++) {
            let digitsCount=index.toString().length;
            let buffer=index
            let sum=0;
            while (buffer>0) {
                let currDigit=buffer%10;
                buffer=Math.floor(buffer/10)
                sum+=Math.pow(currDigit,digitsCount);
            }
            if(index===sum){
                sequence.push(index);
            }
    }

    return sequence
}