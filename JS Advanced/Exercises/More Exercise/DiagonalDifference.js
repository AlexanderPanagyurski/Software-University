console.log(diagonalDifference([
    [1, 2, 3,5],
    [4, 5,6,7],
    [7, 8, 9,8],
    [10,11,12,8]
]))

function diagonalDifference(arr) {
    let firstDiagonalSum = 0;
    let secondDiagonalSum = 0;

  for(let i=0; i<arr.length; i++){
     for(let j=0; j<arr.length; j++){
       // finding the sum of primary diagonal
         if(i === j) {
           firstDiagonalSum += arr[i][j];
         }
       // finding the sum of secondary diagonal
         if(i + j === arr.length - 1){
            secondDiagonalSum += arr[i][j];
         }
      }
  }
  return Math.abs(firstDiagonalSum - secondDiagonalSum);
}