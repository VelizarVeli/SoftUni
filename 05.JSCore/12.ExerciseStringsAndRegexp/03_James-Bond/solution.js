function solve() {

  let input = document.querySelector('#arr').value;
  input = JSON.parse(input);
  let output = document.querySelector('#result');
  let key = input.shift();

  let keyFinder = new RegExp(`((?<=(\\s)${key})|(?<=^${key}))\\s+([A-Z!%$#]{8,})([\\s.,]|$)`, 'gi');
  let caseChecher = /[a-z]+/g;

  let result;
  let resultArr = [];

  for (let i = 0; i < input.length; i++) {
      resultArr[i] = input[i];
      while (result = keyFinder.exec(input[i])) {
          if (!caseChecher.exec(result[3])) {
              input[i] = input[i].replace(result[3], decode(result[3]));
              resultArr[i] = input[i];
          }
      }
  }

  for (let row of resultArr) {
      createAddAppend('p', row, output);
  }

  function createAddAppend(child, text, parent) {
      let childElement = document.createElement(child);
      childElement.textContent = text;
      parent.appendChild(childElement);
  }
  function decode(text) {
      text = text.toLowerCase();
      for (let char of text) {
          if (text.includes('!')) {
              text = text.replace('!', '1');
          }
          if (text.includes('%')) {
              text = text.replace('%', '2');
          }
          if (text.includes('#')) {
              text = text.replace('#', '3');
          }
          if (text.includes('$')) {
              text = text.replace('$', '4');
          }
      }
      return text;
  }
}