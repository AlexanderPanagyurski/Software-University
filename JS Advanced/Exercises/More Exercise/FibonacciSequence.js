console.log(FibonacciSequence(196418))

function FibonacciSequence(end){
    let sequence=[];

    let firstNum=0;
    let secondNum=1;
    sequence.push(firstNum);
    sequence.push(secondNum);

    for (let index = secondNum; index <= end; index+=firstNum) {

        let newNumber=firstNum+secondNum;
        firstNum=secondNum;
        secondNum=newNumber;
        sequence.push(secondNum);
    }

    return sequence;
}