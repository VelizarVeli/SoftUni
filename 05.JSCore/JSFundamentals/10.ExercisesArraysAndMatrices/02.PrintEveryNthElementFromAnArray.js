function solve(input) {
    let delimeter = Number(input.pop());
    input.slice(input.length - 1);

    for (let index = 0; index < input.length; index++) {
        if (index % delimeter === 0) {
            console.log(input[index]);
        }
    }
}

solve(['5', '20', '31', '4', '20', '2']);
solve(['dsa', 'asd', 'test', 'tset', '2']);
solve(['1', '2', '3', '4', '5', '6']);