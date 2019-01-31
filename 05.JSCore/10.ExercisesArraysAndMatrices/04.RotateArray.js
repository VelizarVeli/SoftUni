function solve(arr) {
    let rotator = Number(arr.pop(arr.length - 1));
    for (let index = 0; index < rotator % arr.length; index++) {
        let last = arr.pop();
        arr.unshift(last);
    }
    console.log(arr.join(' '));
}

solve(['1',
    '2',
    '3',
    '4',
    '2'
]);

solve(['Banana',
    'Orange',
    'Coconut',
    'Apple',
    '15'
]);