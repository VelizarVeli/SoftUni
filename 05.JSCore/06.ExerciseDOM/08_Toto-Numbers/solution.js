function solve() {
	let getNumbersBtn = document.getElementsByTagName("button")[0];

	let inputField = document.getElementsByTagName("input")[0];

	let targetDiv = document.getElementById("allNumbers");
	
	function CalculatingEndResult(inputNumbers, targetDiv){
		for(i=1; i<=49; i++){
			let div = document.createElement("div");
			div.textContent = i.toString();
			div.classList.add("numbers");

			if(inputNumbers.includes(i.toString())){
				div.style.backgroundColor = "orange";
			}

			targetDiv.appendChild(div);
		}
	}

	getNumbersBtn.addEventListener("click", function(){
		targetDiv.innerHTML = "";

		let inputNumbers = inputField.value.split(" ");

		if(inputNumbers.length == 6){

			let invalidNumbersCount = 0;
			
			for(i=0; i<inputNumbers.length; i++){
				if(inputNumbers[i] < 1 || inputNumbers[i] > 49){
					invalidNumbersCount++;
				}
			}

			if(invalidNumbersCount == 0){
				CalculatingEndResult(inputNumbers, targetDiv);
			}
		}
			
		inputField.setAttribute("disabled", "");
		getNumbersBtn.setAttribute("disabled","");
	});
}