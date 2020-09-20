console.log(solve(2014,2050))

function solve(startYear,endYear){
    var sb="";
    for (var year = startYear; year <= endYear; year++){
    
        var d = new Date(year, 0, 1);
        if ( d.getDay() === 0 ){
        sb+=`1st January is being a Sunday  ${year}\n`
        }
    }
    return sb;
}