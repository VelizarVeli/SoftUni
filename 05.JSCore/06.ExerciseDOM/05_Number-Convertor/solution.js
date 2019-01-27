function solve() {
	let inputField = document.getElementById("input");
	
	let targetField = document.getElementById("result");

	let convertButton = document.getElementsByTagName("button")[0];

	let selectMenu = document.getElementById("selectMenuTo");
	
	let hexaOption = document.createElement("option");
	hexaOption.value = "hexadecimal";
	hexaOption.textContent = "Hexadecimal";
	
	selectMenu.appendChild(hexaOption);

	let binaryOption = document.createElement("option");
	binaryOption.value = "binary";
	binaryOption.textContent = "Binary";
	
	selectMenu.appendChild(binaryOption);

	let emptyButton = document.getElementsByTagName("option")[1];
	let hexaButton = document.getElementsByTagName("option")[2];
	let binaryButton = document.getElementsByTagName("option")[3];

	function ChangeSelectValue(convertButton){
		convertButton.addEventListener("click", function(){
			if(document.getElementById("selectMenuTo").value == emptyButton.value){
				emptyButton.setAttribute("selected", "");
				hexaButton.removeAttribute("selected");
				binaryButton.removeAttribute("selected");
			};
			
			if(document.getElementById("selectMenuTo").value == hexaButton.value){
				hexaButton.setAttribute("selected", "");
				emptyButton.removeAttribute("selected");
				binaryButton.removeAttribute("selected");
			};
		
			if(document.getElementById("selectMenuTo").value == binaryButton.value){
				binaryButton.setAttribute("selected", "");
				emptyButton.removeAttribute("selected");
				hexaButton.removeAttribute("selected");
			};
		});
	}

	ChangeSelectValue(convertButton);
	
	let button = document.getElementsByTagName("button")[0];
	button.addEventListener("click", function(){
		if(binaryButton.hasAttribute("selected") == true){
			let decimalNumber = Number(inputField.value);
			targetField.value = decimalNumber.toString(2);
		}
		
		if(hexaButton.hasAttribute("selected") == true){
			let decimalNumber = Number(inputField.value);
			targetField.value = decimalNumber.toString(16).toUpperCase();
		}
	});
}