console.log(IsMagicSquare([
    [2,7,6],
    [9,5,1],
    [4,3,8]
]))

function IsMagicSquare(input){
        let sum1 = 0
        let sum2 = 0; 
        let n=3;
  
        for (let i = 0; i < n; i++) 
            sum1 = sum1 + input[i][i]; 
  
        for (let i = 0; i < n; i++) 
            sum2 = sum2 + input[i][ n-1-i]; 
       
        if(sum1!=sum2) 
            return false; 

        for (let i = 0; i < n; i++) { 
  
            let rowSum = 0; 
            for (let j = 0; j < n; j++) 
                rowSum += input[i][ j]; 
  

            if (rowSum != sum1) 
                return false; 
        } 

        for (let i = 0; i < n; i++)  
        { 
  
            let colSum = 0; 
            for (let j = 0; j < n; j++) 
                colSum += input[j][i]; 
  
            if (sum1 != colSum) 
                return false; 
        } 
  
        return true; 
    } 