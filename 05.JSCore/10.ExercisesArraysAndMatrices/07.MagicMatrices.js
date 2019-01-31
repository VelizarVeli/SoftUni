function solve(matrix) {
    let rowSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        let curRowSum = 0;
        for (let col = 0; col < matrix[row].length; col++) {
            curRowSum += matrix[row][col];
        }
        if (row === 0) {
            rowSum = curRowSum;
        } else if (rowSum !== curRowSum) {
            return false;
        }
    }

    for (let col = 0; col < matrix[0].length; col++) {
        let colSum = 0;
        for (let row = 0; row < matrix.length; row++) {
            colSum += matrix[row][col];
        }
        if (colSum !== rowSum) {
            return false;
        }
    }
    return true;
    console.log(solve);
}
console.log(solve([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]
]));