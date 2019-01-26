function register() {
  let username = document.getElementById("username").value;
  let password = document.getElementById("password").value;
  
  let hiddenPassword = "";
  for(i=0; i<password.length; i++){
    hiddenPassword+="*";
  }

  let resultDiv = document.getElementById("result");

  let pattern = new RegExp(/(.+)@(.+).(com|bg)/);
  let email = document.getElementById("email").value;
  
  let matchResult = pattern.test(email);
  
  if(matchResult !== null && username.length > 0 && password.length > 0){
    
   setTimeout(() => {
     let heading = document.createElement("h1");
     heading.textContent = "Successful Registration!";

     resultDiv.appendChild(heading);

     resultDiv.innerHTML += ("Username: " + username);
     resultDiv.appendChild(document.createElement("br"));
     resultDiv.innerHTML += ("Email: " + email);
     resultDiv.appendChild(document.createElement("br"));
     resultDiv.innerHTML += ("Password: " + hiddenPassword);

   }, (1));
  }
  
}