function morseCode(input) {
  let morseAlphabet = {
    ".-": "a",
    "-...": "b",
    "-.-.": "c",
    "-..": "d",
    ".": "e",
    "..-.": "f",
    "--.": "g",
    "....": "h",
    "..": "i",
    ".---": "j",
    "-.-": "k",
    ".-..": "l",
    "--": "m",
    "-.": "n",
    "---": "o",
    ".--.": "p",
    "--.-": "q",
    ".-.": "r",
    "...": "s",
    "-": "t",
    "..-": "u",
    "...-": "v",
    ".--": "w",
    "-..-": "x",
    "-.--": "y",
    "--..": "z",
    ".----": "1",
    "..---": "2",
    "...--": "3",
    "....-": "4",
    ".....": "5",
    "-....": "6",
    "--...": "7",
    "---..": "8",
    "----.": "9",
    "-----": "0"
  };
  let result = "";
  let messageArray = input.split(" ");
  for (let i = 0; i < messageArray.length; i++) {
    for (let key in morseAlphabet) {
      if (key === messageArray[i]) {
        result += morseAlphabet[key];
      }
    }
  }
  console.log(result);
}

morseCode(".... . .-.. .-.. ---");
