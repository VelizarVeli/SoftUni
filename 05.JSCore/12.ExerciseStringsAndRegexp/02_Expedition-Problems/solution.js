function solve() {
  let inputStrElement = document.getElementById('str');
  let inputTextElement = document.getElementById('text');
  let outputElement = document.getElementById('result');

  let pattern = /(north|east)(?:[\s\S])*?([\d]{2})(?:[^,]+)*?,(?:[^,])*?([\d]{6})/gmi;
  let matches = inputTextElement.value.match(pattern);
  let matchedInfo = [];

  if (matches.length > 0) {
    matches.forEach((match) => {
      pattern = /(north|east)(?:[\s\S])*?([\d]{2})(?:[^,]+)*?,(?:[^,])*?([\d]{6})/gmi;
      let result = pattern.exec(match);

      if (result.length > 1) {
        matchedInfo.push(result.slice(1, 4).join(" "));
      }
    });
  } else {
    return;
  }

  let northCoords = takeRightCoords('NORTH');
  let eastCoords = takeRightCoords('EAST');

  let message = inputTextElement.value.split(inputStrElement.value)[1];

  appendToTheFather(`${northCoords[1]}.${northCoords[2]} ${northCoords[0][0]}`);
  appendToTheFather(`${eastCoords[1]}.${eastCoords[2]} ${eastCoords[0][0]}`);
  appendToTheFather(`Message: ${message}`);

  function takeRightCoords(rightWay) {

    console.log(matchedInfo);
    return matchedInfo
      .reverse()
      .map((coords) => coords.toUpperCase())
      .filter((coordsInfo) => coordsInfo
        .includes(rightWay))[0].split(' ');
  }

  function appendToTheFather(text) {
    let p = document.createElement('p');
    p.textContent = text;
    outputElement.appendChild(p);
  }

  inputStrElement.value = "";
  inputTextElement.value = "";
}
//another solution
// function solve() {
//   let keyword = document.getElementById('str').value;
//   let text = document.getElementById('text').value;

//   let outputElement = document.getElementById('result');

//   let regEx = new RegExp(`${keyword}(.*?)${keyword}`, "g");
//   let message = `Message: ${regEx.exec(text)[1]}`;
//   text = text.replace(message, "");

//   let regex = /(east|north)[\s\S]*?([\d]{2})[^,]*?,[^,]*?([\d]{6})/gi;

//   let m;

//   let east = "";
//   let north = "";

//   while ((m = regex.exec(text)) !== null) {
//     if (m[1].toUpperCase() === 'NORTH') {
//       north = `${m[2]}.${m[3]} N`;
//     } else if (m[1].toUpperCase() === "EAST") {
//       east = `${m[2]}.${[m[3]]} E`;
//     }
//   }

//   appendToParent(north);
//   appendToParent(east);
//   appendToParent(message);

//   function appendToParent(text) {
//     let p = document.createElement('p');
//     p.textContent = text;
//     outputElement.appendChild(p);
//   }
// }