function stringLength(arg1, arg2, arg3) {
    let firstLength = arg1.length;
    let secondLength = arg2.length;
    let thirdLength = arg3.length;
    let sum = (firstLength + secondLength + thirdLength);
    let average = Math.floor(sum/3);

    console.log(firstLength + secondLength + thirdLength);
    console.log(average);
}

stringLength('pasta','5', '22.3');