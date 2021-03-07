function solve() {
    let buttonElements = document.getElementsByTagName('button');
    let generateButtonElement = buttonElements[0];
    let buyButtonElement = buttonElements[1];
    let inputAreaElements = document.getElementsByTagName('textarea');
    let tableRows = document.getElementsByTagName('tbody')[0];

    generateButtonElement.addEventListener('click', () => {
        document.getElementsByTagName('input')[0].disabled = false;
        let objects = JSON.parse(inputAreaElements[0].value);

        for (let currentObj of objects) {
            let newTr = document.createElement('tr');

            let imgTd = document.createElement('td');
            let imgTag = document.createElement('img');
            imgTag.setAttribute('src', currentObj['img']);
            imgTd.appendChild(imgTag);

            let productTd = document.createElement('td');
            let productP = document.createElement('p');
            productP.textContent = currentObj['name'];
            productTd.appendChild(productP);

            let priceTd = document.createElement('td');
            let priceP = document.createElement('p');
            priceP.textContent = currentObj['price'];
            priceTd.appendChild(priceP);

            let decFacTd = document.createElement('td');
            let decFacP = document.createElement('p');
            decFacP.textContent = currentObj['decFactor'];
            decFacTd.appendChild(decFacP);

            let checkBoxTd = document.createElement('td');
            let checkBoxInput = document.createElement('input');
            checkBoxInput.setAttribute('type', 'checkbox');
            checkBoxTd.appendChild(checkBoxInput);

            newTr.appendChild(imgTd);
            newTr.appendChild(productTd);
            newTr.appendChild(priceTd);
            newTr.appendChild(decFacTd);
            newTr.appendChild(checkBoxTd);

            tableRows.appendChild(newTr);
        }
    });

    buyButtonElement.addEventListener('click', () => {
        let boughtFurnitureArray = [];
        let totalMoney = 0;
        let totalDecFactor = 0;

        let trElements = tableRows.getElementsByTagName('tr');

        for (let trElement of Array.from(trElements)) {
            if (trElement.getElementsByTagName('input')[0].checked === true) {
                let paragraphsElements = trElement.getElementsByTagName('p');
                if (!boughtFurnitureArray.includes(paragraphsElements[0].textContent)) {
                    boughtFurnitureArray.push(paragraphsElements[0].textContent);
                }
                totalMoney += Number(paragraphsElements[1].textContent);
                totalDecFactor += Number(paragraphsElements[2].textContent);
            }
        }

        let resultAreaElement = inputAreaElements[1];
        resultAreaElement.textContent += `Bought furniture: ${boughtFurnitureArray.join(', ')}\n`;
        resultAreaElement.textContent += `Total price: ${totalMoney.toFixed(2)}\n`;
        resultAreaElement.textContent += `Average decoration factor: ${(totalDecFactor / boughtFurnitureArray.length)}`;
    });
}

/*
[{
  "name": "Sofa",
  "img": "https://res.cloudinary.com/maisonsdumonde/image/upload/q_auto,f_auto/w_200/img/grey-3-seater-sofa-bed-200-13-0-175521_9.jpg",
  "price": 150,
  "decFactor": 1.2
}]
*/