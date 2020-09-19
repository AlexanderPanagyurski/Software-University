console.log(IsLeapYearInGregorianCalendar(2019))


//1. Write a JavaScript program to display the current day and time in the following format. 
function GetCurrentDayAndTime(){
    var today=new Date();
    
    return `Today is: ${today.getDay()}\n`+`Current time is: ${today.getHours()}:${today.getMinutes()}:${today.getSeconds()}`
}

//2. Write a JavaScript program to display the current day and time in the following format. 
function GetCurrentDateInFormat(input){
    var today = new Date();
    var dd = today.getDate();
    
    var mm = today.getMonth()+1; 
    var yyyy = today.getFullYear();
    if(dd<10) 
    {
        dd='0'+dd;
    } 
    
    if(mm<10) 
    {
        mm='0'+mm;
    } 

    switch (input) {
        case 'mm-dd-yyyy': today = mm+'-'+dd+'-'+yyyy;
            break;
        case 'mm/dd/yyyy': today = mm+'/'+dd+'/'+yyyy;
            break;
        case 'dd-mm-yyyy':today = dd+'-'+mm+'-'+yyyy;
            break;
        case 'dd/mm/yyyy':today = dd+'/'+mm+'/'+yyyy;
    }
    return today
}

//3. Write a JavaScript program to find the area of a triangle
// where lengths of the three of its sides are 5, 6, 7.
function GetAreaOfTriangle(a,b,c){
    var semiPerimeter=(a+b+c)/2

    return Math.sqrt(semiPerimeter*(semiPerimeter-a)*(semiPerimeter-b)*(semiPerimeter-c)).toFixed(2)
}

//4. Write a JavaScript program to determine whether a given year is a leap year in the Gregorian calendar
function IsLeapYearInGregorianCalendar(year){
    return (year % 100 === 0) ? (year % 400 === 0) : (year % 4 === 0);
}
