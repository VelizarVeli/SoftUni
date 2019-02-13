function solve(input) {

    //console.log(input);

    let check = input.reduce((acc, cur) => {
        
        if(!acc[cur.town]){
            acc[cur.town] = [];
        }

        acc[cur.town].push({
            model: cur.model,
            regNumber: cur.regNumber,
            price: cur.price
        });

        return acc;
    }, {});

    //console.log(check.Burgas);

    Object.keys(check).forEach((town) => {
        
        let totalProfit = check[town].reduce((a,b) => a.price + b.price);

        console.log(`${town} total profit - ${totalProfit}`);
    })
}

solve([
  {
    model: "BMW",
    regNumber: "B1234SM",
    town: "Varna",
    price: 2
  },
  {
    model: "BMW",
    regNumber: "C5959CZ",
    town: "Sofia",
    price: 8
  },
  {
    model: "Tesla",
    regNumber: "NIKOLA",
    town: "Burgas",
    price: 9
  },
  {
    model: "BMW",
    regNumber: "A3423SM",
    town: "Varna",
    price: 3
  },
  {
    model: "Lada",
    regNumber: "SJSCA",
    town: "Sofia",
    price: 3
  },
  {
    model: "Lada",
    regNumber: "SJSCA",
    town: "Burgas",
    price: 3
  }
]);
