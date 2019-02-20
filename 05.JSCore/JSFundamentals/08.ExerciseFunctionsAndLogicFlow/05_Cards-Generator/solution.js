function solve() {

    let getCardsBtn = document.querySelector("button");
    getCardsBtn.addEventListener("click", function(){

        let validInputs = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" ];

        let cardsSection = document.getElementById("cards");
    
        let from = document.getElementById("from").value;
        let to = document.getElementById("to").value;
        
        let suit = document.querySelector("select").value;
        suit = suit.substr(suit.length - 1, 1);

        function getPositions(from, to, fromPosition, toPosition){
            for (let index in validInputs) {
                if (from === validInputs[index]) {
                    fromPosition = index;
                }
                if (to === validInputs[index]) {
                    toPosition = index;
                }
            }
            let result = {};
            result.fromPosition = fromPosition;
            result.toPosition = toPosition;
            
            return result;
        }

        function appendResult(cardsSection, validInputs, fromPosition, toPosition){
            for (let index = +fromPosition; index <= +toPosition; index++) {
            
                let div = document.createElement("div");
                div.classList.add("card");
                let upperParagraph = document.createElement("p");
                upperParagraph.textContent = suit;

                let middleParagraph = document.createElement("p");
                middleParagraph.textContent = validInputs[index];

                let lowerParagraph = document.createElement("p");
                lowerParagraph.textContent = suit;   
                
                div.appendChild(upperParagraph);
                div.appendChild(middleParagraph);
                div.appendChild(lowerParagraph);

                cardsSection.appendChild(div);
            }
        }

        if(validInputs.filter((i) => { return validInputs[i] === i;}) && validInputs.includes(to.toString())){

            let fromPosition = 0;
            let toPosition = 0;
            
            let positions = getPositions(from, to, fromPosition, toPosition);
            
            fromPosition = positions.fromPosition;
            toPosition = positions.toPosition;
            
           appendResult(cardsSection, validInputs, fromPosition, toPosition);
        }
            
    });
 
}