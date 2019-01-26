function solve() {
	let textAreas = document.getElementsByTagName("textarea");
	let buttons = document.getElementsByTagName("button");

	function DecodeMessage(textArea) {
		let message = textArea.value;
		let decodedMessage = "";
		for (i = 0; i < message.length; i++) {
			decodedMessage += String.fromCharCode(message.charCodeAt(i) - 1);
		}

		decodeTextArea.value = decodedMessage; 
	}

	function EncodeMessage(textArea) {
		let message = encodeTextArea.value;
		let encodedMessage = "";
		for (i = 0; i < message.length; i++) {
			encodedMessage += String.fromCharCode(message.charCodeAt(i) + 1);
		}
		encodeTextArea.value = "";
		decodeTextArea.value = encodedMessage;
	}

	let decodeTextArea = textAreas[1];
	let decodeBtn = buttons[1];
	decodeBtn.addEventListener("click", function () {
		DecodeMessage(decodeTextArea);
	});

	let encodeTextArea = textAreas[0];
	let encodeBtn = buttons[0];
	encodeBtn.addEventListener("click", function () {
		EncodeMessage(encodeTextArea);
	});

}