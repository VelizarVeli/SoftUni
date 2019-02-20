function solve(arr) {
 
    let priceObj =
        {
            caffeine: 0.80,
            decaf: 0.90,
            tea: 0.80
        }
 
 
    let dictionary = [];
 
 
    let totalIncome = 0;
 
    let priceOfOrder = 0;
 
    for (let i = 0; i < arr.length; i++) {
        dictionary.push(arr[i].split(', '));
 
        //Current Order
        let innerArray = dictionary[i];
 
        //When it has length 5
        if (innerArray.length === 5) {
            if (innerArray.includes('caffeine')) {
              priceOfOrder=  priceObj['caffeine'] + 0.1;
 
            } else if (innerArray.includes('decaf')) {
               priceOfOrder= priceObj['decaf'] +0.1;
            }
        }
        //When it has length 4
               else if (innerArray.length === 4) {
            if (innerArray.includes('caffeine')) {
                priceOfOrder = priceObj['caffeine'];
 
 
            } else if (innerArray.includes('decaf')) {
                priceOfOrder = priceObj['decaf'];
 
            } else if (innerArray.includes('tea')) {
                priceOfOrder = priceObj['tea'] + 0.1;
            }
        }
        //When it has length 3
        else {
            priceOfOrder = priceObj['tea'];
        }
        //Add sugar
        innerArray[innerArray.length - 1] > 0 ? priceOfOrder += 0.1 : priceOfOrder = priceOfOrder;
       
        //Print Order
        if (priceOfOrder > innerArray[0]) {
            console.log(`Not enough money for ${innerArray[1]}. Need ${(priceOfOrder - innerArray[0]).toFixed(2)}$ more.`);
            priceOfOrder = 0;
        } else {
            console.log(`You ordered ${innerArray[1]}. Price: ${priceOfOrder.toFixed(2)}$ Change: ${(innerArray[0] - priceOfOrder).toFixed(2)}$`);
        }
        //Add to Total Income
        totalIncome += priceOfOrder;
    }
 
    //Print Total Income
    console.log(`Income Report: ${totalIncome.toFixed(2)}$`);
}

solve(['1.00, coffee, caffeine, milk, 4',
    '0.40, tea, milk, 2',
    '1.00, coffee, decaf, 0'
])

solve(['8.00, coffee, decaf, 4',
    '1.00, tea, -2'])