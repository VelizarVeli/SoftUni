function solve() {
  let string = document.getElementById("string").value;
  let char = document.getElementById("character").value;
  let count = 0;
  let result = '';

  function findCharacterCount(string, char) {
    for (let i = 0; i < string.length; i++) {
      if (string[i] === char) {
        count++;
      }
    }
  }

  function evenOrOdd(string, char) {
    if (count % 2 === 0) {
      result = `Count of ${char} is even.`;
    } else {
      result = `Count of ${char} is odd.`;
    }
  }

  findCharacterCount(string, char);
  evenOrOdd(string, char);
  document.getElementById("result").innerHTML = result;
}