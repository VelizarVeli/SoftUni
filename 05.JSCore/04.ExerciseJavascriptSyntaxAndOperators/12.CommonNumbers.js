function solve(arr1, arr2, arr3) {
    let result = [];
    for (let i = 0; i < arr1.length; i++) {
        if (arr2.includes(arr1[i]) && arr3.includes(arr1[i])) {
            result.push(arr1[i])
        }
    }
    console.log(`The common elements are ${result.sort().join(', ')}.`);
    let sum = 0;
    for (let i = 0; i < result.length; i++) {
        sum += result[i];
    }
    let avg = sum / result.length;
    console.log(`Average: ${avg}.`);

    var median = 0,
        numsLen = result.length;
    result.sort();

    if (
        numsLen % 2 === 0
    ) {
        median = (result[numsLen / 2 - 1] + result[numsLen / 2]) / 2;
    } else {
        median = result[(numsLen - 1) / 2];
    }
    console.log(`Median: ${median}.`);
}

solve([5, 6, 50, 10, 1, 2],
    [5, 4, 8, 50, 2, 10],
    [5, 2, 50]);

solve([1, 2, 3, 4, 5],
    [3, 2, 1, 5, 8],
    [2, 5, 3, 1, 16]);