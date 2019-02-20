function solve(input){
    let depArr =  input[0];
    let destination = input[1];
    let time = input[2];
    let flight = input[3];
    let gate = input[4];

    console.log(`${depArr}: Destination - ${destination}, Flight - ${flight}, Time - ${time}, Gate - ${gate}`)
}

solve(['Departures', 'London', '22:45', 'BR117', '42']);
solve(['Arrivals', 'Paris', '02:22', 'VD17', '3']);