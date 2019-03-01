function solve(arr, firstIndex, secondIndex) {
    if (!Array.isArray(arr)) {
        return NaN;
    }

    if (arr.length === 0) {
        return 0;
    }

    if (firstIndex < 0) {
        firstIndex = 0;
    }

    if (secondIndex >= arr.length) {
        secondIndex = arr.length - 1;
    }

    let subArr = arr
        .slice(firstIndex, secondIndex + 1)

    if (!subArr.every(Number)) {
        return NaN;
    }

    return subArr
        .map(Number)
        .reduce((a, b) => a + b);
}

console.log(solve([10, 20, 30, 40, 50, 60], 3, 300));