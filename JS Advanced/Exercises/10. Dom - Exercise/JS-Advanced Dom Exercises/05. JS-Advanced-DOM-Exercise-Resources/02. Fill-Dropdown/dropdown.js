function addItem() {
    let newItemTextElement = document.getElementById('text').value;
    let newItemValueElement = document.getElementById('naming-convention').value;

    let array = newItemTextElement.split(' ');

    for (let i = 0; i < array.length; i++) {
        array[i] = array[i].toLowerCase();
    }

    if (newItemValueElement === 'Pascal Case') {
        for (let i = 0; i < array.length; i++) {
            var currElement = array[i].charAt(0).toUpperCase() + array[i].slice(1);
            array[i] = currElement;
        }
        document.getElementsByTagName('span')[0].innerHTML = array.join('');
    } else if (newItemValueElement === 'Camel Case') {
        for (let i = 1; i < array.length; i++) {
            var currElement = array[i].charAt(0).toUpperCase() + array[i].slice(1);
            array[i] = currElement;
        }
        document.getElementsByTagName('span')[0].innerHTML = array.join('');
    } else {
        array = 'Error!';
        document.getElementsByTagName('span')[0].innerHTML = array;
    }
}