console.log(ConvertTemperature(45,'Fahrenheit','Celsius'))

function ConvertTemperature(temperature,temperatureFrom,temperatureTo){
    if(temperatureFrom==='Celsius' && temperatureTo==='Fahrenheit'){
        return `${temperature} °C is ${(temperature/5*9+32).toFixed(2)} °F`
    } else if(temperatureFrom==='Fahrenheit' && temperatureTo==='Celsius'){
        return `${temperature} °F is ${(((temperature-32)*5)/9).toFixed(2)} °C`
    }
}