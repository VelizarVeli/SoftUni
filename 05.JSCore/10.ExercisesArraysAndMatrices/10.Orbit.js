function solve([cols, rows, startRow, startCol]) {
    let matrix = [];
    for (let row = 0; row < rows; row++) {
        matrix[row] = [];
        for (let col = 0; col < cols; col++) {
            matrix[row][col] = Math.max(Math.abs(row - startRow), Math.abs(col - startCol)) + 1;
        }
    }

    for (let row of matrix) {
        console.log(row.join(' '));
    }
}

solve([4, 4, 0, 0])