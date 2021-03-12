function solve() {
    var addPetNameInput = document.querySelector('#container > input[type=text]:nth-child(1)');
    var addPetAgeInput = document.querySelector('#container > input[type=text]:nth-child(2)');
    var addPetKindInput = document.querySelector('#container > input[type=text]:nth-child(3)');
    var addPetCurrentOwnerInput = document.querySelector('#container > input[type=text]:nth-child(4)');

    var addNewPetButton = document.querySelector('#container > button');

    addNewPetButton.addEventListener('click', function(e) {
        e.preventDefault();

        var name = addPetNameInput.value;
        var age = addPetAgeInput.value;
        var kind = addPetKindInput.value;
        var currentOwner = addPetCurrentOwnerInput.value;
        console.log(name, age, kind, currentOwner);

        var validInput = name.length > 0 && age > 0 && kind.length > 0 && currentOwner.length > 0;
        if (validInput) {
            var adoptionSectionUl = document.querySelector('#adoption > ul');
            var li = document.createElement('li');
            var paragraph = document.createElement('p');
            paragraph.innerHTML = `<strong>${name}</strong> is a <strong>${age}</strong> year old <strong>${kind}</strong>`;
            li.appendChild(paragraph);
            var span = document.createElement('span');
            span.innerText = `Owner: ${currentOwner}`;
            li.appendChild(span);
            var contactWithOwnerButton = document.createElement('button');
            contactWithOwnerButton.innerText = `Contact with owner`;
            li.appendChild(contactWithOwnerButton);
            adoptionSectionUl.appendChild(li);

            addPetNameInput.value = '';
            addPetAgeInput.value = '';
            addPetKindInput.value = '';
            addPetCurrentOwnerInput.value = '';

            contactWithOwnerButton.addEventListener('click', function(e) {
                e.preventDefault;

                contactWithOwnerButton.remove();

                var div = document.createElement('div');

                var enterYourNamesInput = document.createElement('input');
                enterYourNamesInput.placeholder = `Enter your names`;
                div.appendChild(enterYourNamesInput);

                var yesITakeItButton = document.createElement('button');
                yesITakeItButton.innerText = `Yes! I take it!`;
                div.appendChild(yesITakeItButton);

                li.appendChild(div);

                yesITakeItButton.addEventListener('click', function(e) {
                    e.preventDefault;

                    var newOwnerName = enterYourNamesInput.value;
                    var validOwnerName = newOwnerName.length > 0;

                    if (validOwnerName) {
                        var buddieWithNewHomeUl = document.querySelector('#adopted > ul');
                        div.removeChild(enterYourNamesInput);
                        yesITakeItButton.remove();
                        var checkedButton = document.createElement('button');
                        checkedButton.innerText = 'Checked';
                        li.appendChild(checkedButton);
                        span.innerText = `New Owner: ${newOwnerName}`;

                        buddieWithNewHomeUl.appendChild(li);
                    }

                    checkedButton.addEventListener('click', function(e) {
                        e.preventDefault
                        li.remove();
                    });
                });
            });
        }
    });
}