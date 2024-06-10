/*document.querySelectorAll('.collapsible-header').forEach(header => {
    header.addEventListener('click', () => {
        const body = header.nextElementSibling;
        body.style.display = body.style.display === 'none' ? 'block' : 'none';
    });
});*/




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

window.onload = () => {
    readJson(); 
        document.querySelectorAll('.collapsible-header').forEach(header => {
        header.addEventListener('click', () => {
            const body = header.nextElementSibling;
           if (item.style.display === "none") {
                item.style.display = "block";
                } else {
                item.style.display = "none";
                }
                
            // über Klassen machen
            // Waren Korb Preis minimieren -> Angeboten im Inernet abfragen
        });
    });
    /*document.querySelectorAll('.collapsible-header').forEach(header => {
        header.addEventListener('click', event => {
          // Klasse 'hidden' ein- oder ausblenden
          const body = header.nextElementSibling;
          body.classList.toggle('hidden');
        });
      });*/

      /*document.querySelectorAll('.collapsible-header').forEach(header => {
        header.addEventListener('click', () => {
          // Finde das nächste Element mit der Klasse "collapsible-body"
          let body = header.nextElementSibling;
          
          // Wenn das nächste Element existiert und die Klasse "collapsible-body" hat
          if (body && body.classList.contains('collapsible-body')) {
            // Schalte die Klasse "hidden" ein oder aus
            body.classList.toggle('hidden');
          }
        });
      });*/

    
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

        /*data.productlist.forEach((product)=>{

            /* Die Kategorien auch auslesen: Klappt noch nicht.
            //let section12 = document.querySelector("einkaufsliste");
            const collapsibleList = document.getElementById('allList');
        //const section = document.getElementById('category'+product.product.category+'list');

            //const section1 = document.getElementById('einkaufsliste');
            const newList2 = document.createElement('li');
            const newItem1 = document.createElement('div');
            newItem1.classList.add('collapsible-header');
            newItem1.id = 'category'+product.product.id;
            const newList1 = document.createElement('ul');
            newList1.classList.add('collapsible-body');
            newList1.id = 'category'+product.product.category+'lists';
            newItem1.appendChild(document.createTextNode(' ' + product.product.categoryName));
            newItem1.appendChild(newList1);
            newList2.appendChild(newItem1);
            collapsibleList.appendChild(newList2);
 

        const section = document.getElementById('category'+product.product.category+'lists');
        const newItem = document.createElement('li');
        const checkbox = document.createElement('input');
        checkbox.type = 'checkbox';
        newItem.appendChild(checkbox);
        newItem.appendChild(document.createTextNode(' ' + product.product.name));
        section.appendChild(newItem);
        })*/

        data.productlist.forEach((product)=>{

            const collapsibleList = document.getElementById('allList');
        //const section = document.getElementById('category'+product.product.category+'list');

            //const section1 = document.getElementById('einkaufsliste');
            const newList2 = document.createElement('li');
            const newItem1 = document.createElement('div');
            newItem1.classList.add('collapsible-header');
            newItem1.id = 'category'+product.product.id;
            const newList1 = document.createElement('ul');
            newList1.classList.add('collapsible-body');
            newList1.id = 'category'+product.product.category+'lists';
            newItem1.appendChild(document.createTextNode(' ' + product.product.categoryName));
            newItem1.appendChild(newList1);
            newList2.appendChild(newItem1);
            collapsibleList.appendChild(newList2);



            const section = document.getElementById('category'+product.product.category+'lists');
            const newItem = document.createElement('li');
 
 
            const checkbox = document.createElement('input');
            checkbox.type = 'checkbox';
 
 
            const number = document.createElement('span');
            number.contentEditable = true;
            number.innerText = product.amount;
 
 
            number.addEventListener('keydown', (event) => {
                if ((event.key >= '0' && event.key <= '9') ||
                    event.key === 'Backspace' ||
                    event.key === 'ArrowLeft' ||
                    event.key === 'ArrowRight') {
                } else {
                    event.preventDefault();
                }
            });
 
 
            newItem.appendChild(checkbox);
            newItem.appendChild(number);
            newItem.appendChild(document.createTextNode(' ' + product.product.name));       
            section.appendChild(newItem);
        })
 

}