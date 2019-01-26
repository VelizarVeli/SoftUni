  function solve() {
    let text = document.getElementById("input").textContent;
    let targetDiv = document.getElementById("output");
    let sentences = text.split(".");

    let paragraph = document.createElement("p");

    for (i = 0; i <= sentences.length; i++) {
      if ((i + 1) % 3 === 0) {
        targetDiv.appendChild(paragraph);
        paragraph = document.createElement("p");
      }

      paragraph.textContent += (sentences[i] + ".");
    }
  }