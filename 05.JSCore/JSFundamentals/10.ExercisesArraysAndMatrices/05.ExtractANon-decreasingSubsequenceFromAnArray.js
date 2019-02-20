function solve(arr) {
    let min = -Infinity;

    let resultArr = arr.reduce((acc, el) => {
        if (el >= min) {
            acc.push(el);
            min = el;
        }
    return acc;
}, []);

    console.log(resultArr.join('\n'));
}

solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24
]);