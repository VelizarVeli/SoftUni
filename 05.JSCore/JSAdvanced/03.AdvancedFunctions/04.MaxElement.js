function solve(arr) {
    return arr.reduce((a, b) => Math.max(a, b));
}

solve([10, 20, 5]);
solve([1, 44, 123, 33]);