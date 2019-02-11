function solve(rows, cols) {
    let matrix = [];
    for (let row = 0; row < rows; row++) {
        matrix[row] = [];
        for (let col = 0; col < cols; col++) {
            matrix[row][col] = 0;
        }
    }

    let counter = 1;
    let currRow = 0;
    let currCol = 0;
    let dir = 'r';

    for (let i = 0; i < rows * cols; i++) {
        matrix[currRow][currCol] = counter;
        counter++;

        if (dir === 'r') {
            if (currCol + 1 >= cols || matrix[currRow][currCol + 1] !== 0) {
                dir = 'd';
                currRow++;
            } else {
                currCol++;
            }
        } else if (dir === 'd') {
            if (currRow + 1 >= rows || matrix[currRow + 1][currCol] !== 0) {
                dir = 'l';
                currCol--;
            } else {
                currRow++;
            }
        } else if (dir === 'l') {
            if (currCol - 1 < 0 || matrix[currRow][currCol - 1] !== 0) {
                dir = 'u';
                currRow--;
            } else {
                currCol--;
            }
        } else if (dir === 'u') {
            if (currRow - 1 <= 0 || matrix[currRow - 1][currCol] !== 0) {
                dir = 'r';
                currCol++;
            } else {
                currRow--;
            }
        }
    }

    for (let row of matrix) {
        console.log(row.join(' '));
    }
}

solve(5, 5);