function solve(input) {
    let obj = {};
    for (let i = 0; i < input.length; i += 2) {
        let objKey = input[i];
        let objValue = +input[i + 1];

        obj[objKey] = objValue;
    }

    console.log(obj);
}

solve(['Yoghurt', 48, 'Rise', 138, 'Apple', 52])