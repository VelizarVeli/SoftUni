function solve(input) {
    let perfectNumbers = [];
    for (let i = 0; i < input.length; i++) {
        if(is_perfect(input[i])){
            perfectNumbers.push(input[i]);
        }

        function is_perfect(number) {
            var temp = 0;
            for (var i = 1; i <= number / 2; i++) {
                if (number % i === 0) {
                    temp += i;
                }
            }

            if (temp === number && temp !== 0) {
                return number;
            }
        }
    }
    if(perfectNumbers.length != 0){
    console.log(`${perfectNumbers.join(', ')}`);
    }
    else{
        console.log("No perfect number");
    }
}

solve([5, 6, 28]);
solve([5, 32, 82]);