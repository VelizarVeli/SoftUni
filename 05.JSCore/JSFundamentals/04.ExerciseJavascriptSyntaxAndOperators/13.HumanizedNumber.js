function solve(input) {
    let inputArr = input.split(" ");
    for (let i = 0; i < inputArr.length; i++) {
        let numCheck = Number(inputArr[i]);
        if (Number.isInteger(numCheck)) {
            if (inputArr[i].slice(-1) === '1') {
                console.log(`${numCheck}st`);
            } else if (inputArr[i].slice(-1) === '2') {
                console.log(`${numCheck}nd`);
            } else if (inputArr[i].slice(-1) === '3') {
                console.log(`${numCheck}rd`);
            } else {
                console.log(`${numCheck}th`);
            }
        }
    }
}


solve('The school has 256 students. In each class there are 26 chairs, 13 desks and 1 board.')
solve('Yesterday I bought 12 pounds of peppers, 3 kilograms of carrots and 5 kilograms of tomatoes.')