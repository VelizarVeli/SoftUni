function SumOfNumbers(num1, num2) {
    let number1 = Number(num1);
    let number2 = Number(num2);

    result = 0;

    for (let i = number1; i <= number2; i++) {
        result += i;
    }
    console.log(result)
}

SumOfNumbers('-7', '2')