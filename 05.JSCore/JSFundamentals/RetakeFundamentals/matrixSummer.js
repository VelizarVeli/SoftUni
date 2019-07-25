function matrix(matrix1, matrix2) {
  let resultMatrix = [];
  for (let row = 0; row < matrix1.length; row++) {
    resultMatrix[row] = [];
    let remainder = 0;
    for (let col = 0; col < matrix1[0].length; col++) {
      let sum = matrix1[row][col] + matrix2[row][col];
      if (remainder !== 0) {
        sum += remainder;
        if (col === matrix1[0].length - 1) {
          if (remainder + matrix2[row][col] > 9) {
           count = 1;
           let check = reminder + matrix2[row][col];
           while (check > 9) {
             resultMatrix[row][col + count] = 9;
             check -= 9;
             count++;
           }
           
            resultMatrix[row][col + count] = remainder + matrix2[row][col] - 9;
          } else {
            resultMatrix[row][col + 1] = remainder + matrix2[row][col];
          }
        }
        remainder = 0;
      }
      if (sum > 9) {
        remainder = sum - 9;
        sum = 9;
      }
      resultMatrix[row][col] = sum;
    }
  }

 // return JSON.stringify(resultMatrix);
  for (let row of resultMatrix) {
    console.log(row.join(" "));
  }
}

matrix([[9, 9], [4, 7]], 
       [[7, 5], [1, 2]]);
