document.querySelectorAll('.collapsible-header').forEach(header => {
    header.addEventListener('click', () => {
        const body = header.nextElementSibling;
        body.style.display = body.style.display === 'none' ? 'block' : 'none';
    });
});



function openAddPoint() {
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
        const section = document.getElementById(newPointcategorie+'list');
        const newItem = document.createElement('li');
        const checkbox = document.createElement('input');
        checkbox.type = 'checkbox';
        newItem.appendChild(checkbox);
        newItem.appendChild(document.createTextNode(' ' + newPointName));
        section.appendChild(newItem);
        closeAddPoint();
    } else {
        alert('Bitte geben Sie einen Namen für den neuen Punkt ein.');
    }
}

window.onload = () => {readJson();}


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
                    "categoryName": "Milch",
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
                    "categoryName": "Milch",
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
                    "categoryName": "Gemüse",
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
                    "categoryName": "Snacks",
                    "standardamount": 2
                }
            }
        ]
    };

        data.productlist.forEach((product)=>{

            /* Die Kategorien auch auslesen: Klappt noch nicht.
            const section1 = document.getElementById('einkaufsliste');
            const newItem1 = document.createElement('div');
            newItem1.id = 'einkaufsliste'+product.product.id;
            newItem1.classList.add('collapsible-body');
            newItem1.appendChild(document.createTextNode(' ' + product.product.categoryName));
            section1.appendChild(newItem1);*/
            


        const section = document.getElementById('category'+product.product.category+'list');
        const newItem = document.createElement('li');
        const checkbox = document.createElement('input');
        checkbox.type = 'checkbox';
        newItem.appendChild(checkbox);
        newItem.appendChild(document.createTextNode(' ' + product.product.name));
        section.appendChild(newItem);
        })

}
