function solve() {
  let softUniDefaultVisitsCount = 1;
  let googleDefaultVisitsCount = 2;
  let youtubeDefaultVisitsCount = 3;
  let wikiDefaultVisitsCount = 4;
  let gmailDefaultVisitsCount = 5;
  let soDefaultVisitsCount = 6;

  let buttons = document.getElementsByTagName("a");
  let spans = document.getElementsByTagName("span");

  let softUniBtn = buttons[0];
  let softUniSpan = spans[0];
  softUniBtn.addEventListener("click", function(){
    softUniDefaultVisitsCount++;
    softUniSpan.textContent = "Visited: " + softUniDefaultVisitsCount + " times";
  });

  let googleBtn = buttons[1];
  let googleSPan = spans[1];
  googleBtn.addEventListener("click", function(){
    googleDefaultVisitsCount++;
    googleSPan.textContent = "Visited: " + googleDefaultVisitsCount + " times";
  });

  let youtubeBtn = buttons[2];
  let youtubeSPan = spans[2];
  youtubeBtn.addEventListener("click", function(){
    youtubeDefaultVisitsCount++;
    youtubeSPan.textContent = "Visited: " + youtubeDefaultVisitsCount + " times";
  });

  let wikiBtn = buttons[3]; 
  let wikiSPan = spans[3];
  wikiBtn.addEventListener("click", function(){
    wikiDefaultVisitsCount++;
    wikiSPan.textContent = "Visited: " + wikiDefaultVisitsCount + " times";
  });

  let gmailBtn = buttons[4];
  let gmailSPan = spans[4];
  gmailBtn.addEventListener("click", function(){
    gmailDefaultVisitsCount++;
    gmailSPan.textContent = "Visited: " + gmailDefaultVisitsCount + " times";
  });

  let soBtn = buttons[5];
  let soSPan = spans[5];
  soBtn.addEventListener("click", function(){
    soDefaultVisitsCount++;
    soSPan.textContent = "Visited: " + soDefaultVisitsCount + " times";
  });
  
}