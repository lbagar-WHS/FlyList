document.querySelectorAll('.collapsible-header').forEach(header => {
    header.addEventListener('click', () => {
        const body = header.nextElementSibling;
        body.style.display = body.style.display === 'none' ? 'block' : 'none';
    });
});

let currentSectionId;

function openAddPoint(sectionId) {
    currentSectionId = sectionId;
    document.getElementById('addPoint').style.display = 'flex';
}

function closeAddPoint() {
    document.getElementById('addPoint').style.display = 'none';
    document.getElementById('newPointName').value = '';
}

function addNewPoint() {//abfragen, ob dieser Punkt schon in der Liste exzistiert
    const newPointName = document.getElementById('newPointName').value;
    const newPointcategorie = document.getElementById('newPointcategorie').value;
    if (newPointName.trim() !== '') {
        const section = document.getElementById(currentSectionId);
        const collapsibleBody = section.querySelector('.collapsible-body');
        const newItem = document.createElement('li');
        const checkbox = document.createElement('input');
        checkbox.type = 'checkbox';
        newItem.appendChild(checkbox);
        newItem.appendChild(document.createTextNode(' ' + newPointName));
        collapsibleBody.appendChild(newItem);
        closeAddPoint();
    } else {
        alert('Bitte geben Sie einen Namen für den neuen Punkt ein.');
    }
}

function readJson() {
    const data = {
        "productlist": [
            {
                "isBought": false,
                "amount": 3,
                "product": {
                    "id": "85763098576",
                    "name": "Milch",
                    "description": "Eine Tetrapackung",
                    "category": 1,
                    "standardamount": 1
                }
            },
            {
                "isBought": true,
                "amount": 1,
                "product": {
                    "id": "0874956",
                    "name": "Hafermilch",
                    "description": "Eine Tetrapackung",
                    "category": 1,
                    "standardamount": 1
                }
            },
            {
                "isBought": true,
                "amount": 2,
                "product": {
                    "id": "dafhslu87",
                    "name": "Karrotte",
                    "description": "1kg",
                    "category": 2,
                    "standardamount": 4
                }
            },
            {
                "isBought": false,
                "amount": 2,
                "product": {
                    "id": "fgb7t7i4",
                    "name": "Chips",
                    "description": "175g Packung",
                    "category": 3,
                    "standardamount": 2
                }
            }
        ]
    };

    
        console.log(data.productlist[0].product.name);  // Gibt "Max Mustermann" aus
        console.log(data.productlist[0].product.category);   // Gibt 30 aus

}
