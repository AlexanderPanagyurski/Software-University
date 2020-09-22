console.log(DrawRhombus(5))

function DrawRhombus(input){
    let result='';

    for (let row = 0; row < input; row++) {
        
        for (let col = 0; col < input-row; col++) {

            result+=' ';
        }
        result+='*'
        for (let col = 0; col < row; col++) {
            result+=' *';
        }
        result+='\n';
    }
    for(let row=input; row>=0; row--){
        for (let col = 0; col < input-row; col++) {
            result+=' ';
        }
        result+='*';
        for (let col = 0; col < row; col++) {
            result+=' *';
        }
        result+='\n';
    }
    return result;
}