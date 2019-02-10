function solve() {

  let input = document.getElementsByTagName('textarea')[0];

  let nameArr = [];
  let priceArr = [];
  let factorsArr = [];

  let generateButton = document.getElementsByTagName('button')[0];

  generateButton.addEventListener('click', (e) => {

    let object = JSON.parse(input.value);
    for (let i = 0; i < object.length; i++) {

      let name = object[i].name;
      let imageSrc = object[i].img;
      let price = object[i].price;
      let factor = object[i].decFactor;

      let grandparentDiv = document.querySelector('#furniture-list');
      let parentDiv = createAddAppend('div', 'furniture', grandparentDiv);

      createAddAppend('p', `Name: ${name}`, parentDiv);
      createAddAppend('img', imageSrc, parentDiv);
      createAddAppend('p', `Price: ${price}`, parentDiv);
      createAddAppend('p', `Decoration factor: ${factor}`, parentDiv);
      createAddAppend('input', 'checkbox', parentDiv);
    }
  });

  let result = document.querySelectorAll('textarea')[1];
  let buyButton = document.getElementsByTagName('button')[1];

  buyButton.addEventListener('click', (e) => {

    let selected = Array.from(document.querySelectorAll('div .furniture'));
    console.log(selected);

    for (let item of selected) {
      let isChecked = item.querySelectorAll('input')[0].checked;
      if (isChecked) {
        let selectedName = item.querySelectorAll('p')[0].textContent.split(' ')[1];
        let selectedPrice = +item.querySelectorAll('p')[1].textContent.split(' ')[1];
        let selectedFactor = +item.querySelectorAll('p')[2].textContent.split(' ')[2];
        nameArr.push(selectedName);
        priceArr.push(selectedPrice);
        factorsArr.push(selectedFactor);
      }
    }

    let furnitureList = nameArr.join(', ');
    let totalPrice = priceArr.reduce((a, b) => a + b).toFixed(2);
    let averageFactor = factorsArr.reduce((a, b) => a + b) / factorsArr.length;

    result.textContent = `Bought furniture: ${furnitureList}\nTotal price: ${totalPrice}\nAverage decoration factor: ${averageFactor}`;
  });


  function createAddAppend(child, content, parent) {
    if (child === 'p') {
      let childElement = document.createElement(child);
      childElement.textContent = content;
      parent.appendChild(childElement);
    } else if (child === 'img') {
      let childElement = document.createElement(child);
      childElement.src = content;
      parent.appendChild(childElement);
    } else if (child === 'input') {
      let childElement = document.createElement(child);
      childElement.type = content;
      parent.appendChild(childElement);
    } else if (child === 'div') {
      let childElement = document.createElement(child);
      childElement.className = content;
      parent.appendChild(childElement);
      return childElement;
    }
  }
}