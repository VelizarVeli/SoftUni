function getNext() {
    let resultSpan = document.getElementById("result");

    let number = document.getElementById("num").value;

    let sequence = [number];

    let tempNumber = +number;
    while(tempNumber !== 1){
        if(tempNumber % 2 == 0){
            tempNumber = +tempNumber / 2;
        }
        else{
            tempNumber = (3 * +tempNumber) + 1;
        }
        sequence.push(tempNumber);
    }

    resultSpan.textContent = sequence.join(" ") + " ";
}