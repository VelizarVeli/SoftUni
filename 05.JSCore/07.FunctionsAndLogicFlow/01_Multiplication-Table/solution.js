function solve() {
  let numberToBeMultiplied = Number(document.getElementById("num1").value);
  let multiplier = Number(document.getElementById("num2").value);

  let divResult = document.getElementById('result');

  function findWrongInput(numberToBeMultiplied, multiplier){
    if(numberToBeMultiplied > multiplier){
      document.getElementById("result").innerHTML = "Try with other numbers.";
    }
  }

  function printTable(numberToBeMultiplied, multiplier){

    for(let i = numberToBeMultiplied; i <= multiplier; i++){
      let result = multiplier * i;
      let p = document.createElement('p');
      p.innerHTML = `${i} * ${multiplier} = ${result}`;
      divResult.appendChild(p);
    }
  }

  divResult.innerHTML = '';

  findWrongInput(numberToBeMultiplied, multiplier);
  printTable(numberToBeMultiplied, multiplier);
}