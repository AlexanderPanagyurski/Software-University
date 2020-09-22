console.log(Staircase(10));

function Staircase(input)
{
    let result='';

    for (let index = 1; index <= input; index++) {

        for (let innerIndex = 1; innerIndex <= index; innerIndex++) {
            result+='#';
        }
        result+='\n';
    }

    return result;
}