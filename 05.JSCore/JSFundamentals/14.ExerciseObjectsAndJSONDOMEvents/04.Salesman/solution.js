function solve() {

  let buttons = document.getElementsByTagName('button');

  buttons[0].addEventListener('click', add);
  buttons[1].addEventListener('click', buy);
  buttons[2].addEventListener('click', end);

  let textareas = document.getElementsByTagName('textarea');
  let storage = [];
  let profit = 0;

  function add() {

    let product = {
      name: '',
      quantity: 0,
      price: 0
    };

    let products = JSON.parse(document.getElementsByTagName('textarea')[0].value);

    for (let p of products) {

      if (storage.some(x => x.name === p.name)) {

        let currentProduct = storage.filter(product => product.name === p.name)[0];
        currentProduct.quantity += p.quantity;
        currentProduct.price = p.price;

      } else {
        product.name = p.name;
        product.quantity = p.quantity;
        product.price = p.price;

        storage.push(product);
      }
      textareas[2].value += `Successfully added ${p.quantity} ${p.name}. Price: ${p.price}\n`;
    }
  }

  function buy() {
    let wantedProduct = JSON.parse(textareas[1].value);

    if (storage.some(x => x.name === wantedProduct.name) &&
      storage.some(x => x.quantity >= wantedProduct.quantity)) {
      let currentProduct = storage.filter(product => product.name === wantedProduct.name)[0];
      currentProduct.quantity -= wantedProduct.quantity;
      let money = currentProduct.price * wantedProduct.quantity;
      profit += money;
      textareas[2].value += `${wantedProduct.quantity} ${wantedProduct.name} sold for ${money}.\n`;

    } else {
      textareas[2].value += `Cannot complete order.\n`;
    }
  }

  function end() {
    textareas[2].value += `Profit: ${profit.toFixed(2)}.\n`;

    document.getElementsByTagName('button')[0].removeEventListener('click', add);
    document.getElementsByTagName('button')[1].removeEventListener('click', buy);
    document.getElementsByTagName('button')[2].removeEventListener('click', end);
  }
}