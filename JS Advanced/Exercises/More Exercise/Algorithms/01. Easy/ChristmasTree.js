console.log(DrawChristmasTree(4))

function DrawChristmasTree(input){
    let result='';

    for (let i = 0; i <= input; i++) {
        for (let j = 0; j < input-i; j++) {
            result+=' ';
        }
        for (let j = 0; j < i; j++) {
            result+='*';
        }
        result+='|'
        for(let j=i-1;j>=0;j--){
            result+='*';
        }
        for(let j=input-i;j>=0;j--){
            result+=' ';
        }
        result+='\n';
    }

    return result;
}