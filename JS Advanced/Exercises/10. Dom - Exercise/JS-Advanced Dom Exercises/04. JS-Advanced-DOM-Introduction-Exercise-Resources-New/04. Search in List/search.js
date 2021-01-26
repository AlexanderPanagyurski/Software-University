function search() {
    let towns = document.getElementsByTagName('li');
    let searchText = document.getElementById('searchText').value;
    let count = 0;

    for (const town of towns) {
        if (town.innerHTML.includes(searchText)) {
            count++;
            town.style = "text-decoration: underline; text-decoration: bold;";
        }
    }

    document.getElementById('result').innerHTML = `${count} matches found`;
}