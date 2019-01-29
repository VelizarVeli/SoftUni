function binarySearch() {
    let arr = document.getElementById("arr").value.split(", ");
    let num = document.getElementById("num").value;

    let resultSpan = document.getElementById("result");

    if(Array.from(arr).includes(num)){
        let index = Array.from(arr).indexOf(num);
        resultSpan.textContent = "Found " + num + " at index " + index;
    }
    else{
        resultSpan.textContent = num + " is not in the array";
    }
}