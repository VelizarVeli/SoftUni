function solve(input) {
    let elements = input[0].split(' ');
 
    let bestTotalQuality = 0;
    let maxElements;
   
    let index = 0;
 
    while (elements[index] !== 'Bake') {
        let sum = elements[index].split('#').map(el => Number(el)).reduce((el1, el2) => el1 + el2);
       
        if (bestTotalQuality < sum) {
            bestTotalQuality = sum;
            maxElements = elements[index].split('#')
        }
 
        index++;
    }
 
    console.log(`Best Batch quality: ${bestTotalQuality}`);
    console.log(`${maxElements.join(' ')}`);
 
}

solve(['5#4#10#-2', '10#5#2#3#2', 'Bake It!']);