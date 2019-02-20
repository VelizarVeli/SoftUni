function greatestCD() {
    let resultSpan = document.getElementById("result");
 
    let firstNumber = Number(document.getElementById("num1").value);
    let secondNumber = Number(document.getElementById("num2").value);
 
    let num1 = firstNumber;
    let num2 = secondNumber;
 
    while (true) {
       let temp = num1 % num2;
       
       num1 = num2
       num2 = temp;
       
       if(!num2){
          resultSpan.textContent = num1;
          break;
       }
    }
 }