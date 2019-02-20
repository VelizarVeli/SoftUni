function solve(input, command) {

    let commandWord = command.split(' ')[0];
    let word = command.split(' ')[1];

    if (commandWord === 'hide') {
        let chekc = input[0];
        let index = chekc.indexOf(word);
        for (let row = 0; row < input.length; row++) {
            for (let col = 0; col < input[row].length; col++) {
                if (col === index) {
                    input[row].splice(col, 1);
                }
            }
        }

        for (let row of input) {
            console.log(row.join(' | '));
        }
    }
    if (commandWord === 'sort') {

        let newMatrix = [];
        for (let row = 1; row < input.length; row++) {
            newMatrix.push(input[row]);
        }
        newMatrix.sort();
        newMatrix.unshift(input[0]);
        for (let ro = 0; ro < newMatrix.length; ro++) {
            console.log(newMatrix[ro].join(' | '));
        }


    } else if (commandWord === 'filter') {
        let word1 = command.split(' ')[2];

        for (let row = 0; row < input.length; row++) {
            for (let col = 0; col < input[row].length; col++) {
                if (input[row][col] === word1) {
                    console.log(input[0].join(' | '));

                    console.log(input[row].join(' | '));
                    return;
                }
            }
        }
    }
}

// solve([
//         ['name', 'age', 'grade'],
//         ['Peter', '25', '5.00'],
//         ['George', '34', '6.00'],
//         ['Marry', '28', '5.49']
//     ],
//     'hide name'
// );

solve([
        ['name', 'age', 'grade'],
        ['Peter', '25', '5.00'],
        ['George', '34', '6.00'],
        ['Marry', '28', '5.49']
    ],
    'sort name'
);

// solve([
//         ['firstName', 'age', 'grade', 'course'],
//         ['Peter', '25', '5.00', 'JS-Core'],
//         ['George', '34', '6.00', 'Tech'],
//         ['Marry', '28', '5.49', 'Ruby']
//     ],
//     'filter firstName Marry'
// );