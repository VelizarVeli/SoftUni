function solve(arr) {
    let resultArr = arr.reduce((acc, el, idx) => {
        if (el === 'add') {
            acc.push(idx + 1);
        } else if (el === 'remove') {
            acc.pop();
        }
        return acc;
    }, []);
    if (resultArr.length > 0) {
        console.log(resultArr.join('\n'));
    } else {
        console.log('Empty');
    }
}

solve(['add', 'add', 'add', 'add']);