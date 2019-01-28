function solve() {
  let uniqueChars = '';
  let string = document.getElementById("string").value;

  function isCharWhiteSpace(i) {
    if (string[i] === " ") {
      uniqueChars += string[i];
    }
  }

  function isCurrentCharUnique(i) {
    if (uniqueChars.indexOf(string[i]) === -1) {
      uniqueChars += string[i];
    }
  }

  function findUniqueChars(string) {
    for (let i = 0; i < string.length; i++) {
      isCharWhiteSpace(i);
      isCurrentCharUnique(i);
    }
  }

  findUniqueChars(string);
  document.getElementById("result").innerHTML = uniqueChars;
}