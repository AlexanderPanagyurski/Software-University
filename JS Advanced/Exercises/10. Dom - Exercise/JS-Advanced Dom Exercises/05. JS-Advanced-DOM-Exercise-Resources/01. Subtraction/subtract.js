function subtract() {
    var firstNumber = document.getElementById('firstNumber').value;
    var secondNumber = document.getElementById('secondNumber').value;

    var result = firstNumber - secondNumber;

    document.getElementById('result').innerHTML = result;
}