function solve() {
    document.getElementById('result').value = '';
    let fromNumber = document.getElementById('input').value;
    let toNumber = document.getElementById('selectMenuTo').value;
    if (toNumber === 'binary') {
        let convertedNumber = '';
        while (fromNumber !== 0) {
            let reminder = fromNumber % 2;
            convertedNumber += reminder;
            fromNumber = Math.floor(fromNumber / 2);
        }
        convertedNumber + '';
        convertedNumber = convertedNumber.split('').reverse().join('');
        document.getElementById('result').value = convertedNumber;
    } else if (toNumber === 'hexadecimal') {
        let convertedNumber = '';
        let hexString = parseInt(fromNumber).toString(16);
        convertedNumber = hexString.toUpperCase();
        document.getElementById('result').value = convertedNumber;
    }
}