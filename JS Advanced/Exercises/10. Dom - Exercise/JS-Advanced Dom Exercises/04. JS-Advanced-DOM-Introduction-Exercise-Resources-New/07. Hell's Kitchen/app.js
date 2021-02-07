function solve() {
    document.querySelector('#btnSend').addEventListener('click', onClick);
    let bestRestaurant = {
        name: '',
        averageSalary: 0.00,
        bestSalary: 0.00,
    }

    function onClick() {
        let input = document.getElementsByTagName('textarea')[0].value;
        let restaurantsData = input.split(',');
        for (let i = 0; i < restaurantsData.length; i++) {
            let resutaurantName = restaurantsData[i].split(' - ')[0];
            let employeesData = restaurantsData[i].split(' - ')[1].split(', ');
            let currBestSalary = 0;
            let salaries = 0;
            let avgSalary = 0;
            for (let j = 0; j < employeesData.length; j++) {
                let employeeSalary = employeesData[j].split(' ')[1];
                salaries += employeeSalary;
                if (currBestSalary < employeeSalary) {
                    currBestSalary = employeeSalary;
                }
            }
            avgSalary = salaries / employeesData.length;
            if (avgSalary > bestRestaurant.averageSalary) {
                bestRestaurant.name = resutaurantName;
                bestRestaurant.averageSalary = avgSalary;
                bestRestaurant.bestSalary = currBestSalary;
            }
        }
        document.getElementById('output').innerHTML = '<div id=\'bestRestaurant\'></div>';
        document.getElementById('output').innerHTML = '<div id=\'workers\'></div>';
        document.getElementById('bestRestaurant').innerHTML = '<h2>Best Restaurnat</h2>';
        document.getElementById('bestRestaurant').innerHTML += `<p>${bestRestaurant.name}</p>`;
    }
}