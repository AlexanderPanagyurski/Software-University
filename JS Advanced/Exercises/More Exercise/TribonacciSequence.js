FindNthTribonacciNumber(25)

function FindNthTribonacciNumber(n){

    let firstTribonacci=0;
    let secondTribonacci=1;
    let thirdTribonacci=1;
    console.log(firstTribonacci);
    console.log(secondTribonacci);
    console.log(thirdTribonacci);

    for (let index = 1; index <= n; index++) {

        let newNumber=firstTribonacci+secondTribonacci+thirdTribonacci;
        firstTribonacci=secondTribonacci;
        secondTribonacci=thirdTribonacci;
        thirdTribonacci=newNumber;
        console.log(thirdTribonacci);
    }
}