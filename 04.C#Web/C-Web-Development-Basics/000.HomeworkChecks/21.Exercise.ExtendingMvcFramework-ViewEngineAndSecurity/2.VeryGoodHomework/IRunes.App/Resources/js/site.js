function authenticationCheck() {
    if (arguments[0] == true || arguments[0] == 1) {
	document.getElementById("anchorLogin").style.display = 'none';
	document.getElementById("anchorRegister").style.display = 'none';
	document.getElementById("greeting-loggedOut").style.display = 'none';
	document.getElementById("optionLogin").style.display = 'none';
	document.getElementById("optionRegister").style.display = 'none';
    } else {
	document.getElementById("anchorAlbums").style.display = 'none';
	document.getElementById("anchorLogout").style.display = 'none';
	document.getElementById("greeting-loggedIn").style.display = 'none';
	document.getElementById("wishes").style.display = 'none';
    }
}
function passwordValidate() {
    var password = document.getElementById("password");
    var rePassword = document.getElementById("rePassword");
    if (password.value != rePassword.value) {
	password.setCustomValidity("Passwords do not match!");
	rePassword.setCustomValidity("Passwords do not match!");
    } else {
	password.setCustomValidity('');
	rePassword.setCustomValidity('');
    }
}
