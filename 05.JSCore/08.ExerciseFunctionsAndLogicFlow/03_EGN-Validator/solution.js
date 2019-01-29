(function () {
    
    function validate(){
    let weightPosition = [2, 4, 8, 5, 10, 9, 7, 3, 6];

    let result = document.getElementById("egn");

    let getEgnBtn = document.querySelector("button");
    getEgnBtn.addEventListener("click", function(){
        generateEGN();
    });

    function generateEGN(){
        
    let year = document.getElementById("year");
    let month = document.getElementById("month");
    let date = document.getElementById("date");
    
    let maleOption = document.getElementById("male");
    let femaleOption = document.getElementById("female");

    let gender = maleOption.checked === true ? 2 : 1;

    function getFirstTwoDigits(yearDigits){
        let firstTwoDigits = yearDigits[yearDigits.length - 2].toString() + yearDigits[yearDigits.length - 1].toString(); 
        return firstTwoDigits;
    }

    function appendZeroBeforeLowerNumbers(number){
        let result = "0" + (number).toString();
        return result;
    }

    function getMonthDigitValue(monthName){

        let months =[   "January", 
                        "February", 
                        "March", 
                        "April", 
                        "May",
                        "June",
                        "July", 
                        "August", 
                        "September", 
                        "October", 
                        "November",
                        "December"      ];
        
        for (let index in months) {
            if(months[index] === monthName){
                let monthNumber = +index + 1;
                if((monthNumber) < 10){
                  return appendZeroBeforeLowerNumbers(monthNumber);
                }
                return monthNumber;
            }
        }
    }

    function getDateDigits(date){
        if(date < 10){
            return appendZeroBeforeLowerNumbers(date);
        }
        else{
            return date;
        }
    }

    function getWeightSum(positions, digits){
        let sum = 0;
        let egnSoFar = digits.split("");

        for (let index = 0; index < positions.length; index++) {
            sum += (+egnSoFar[index] * +positions[index]);
        }

        return sum;
    }

    function getRemainder(sum){
        let remainder = sum % 11;
        
        if(((remainder) % 10) === 0){
            remainder = 0;
        }
        return remainder;
    }

        let regionalCode = document.getElementById("region");

        let yearDigits = year.value.split("");
        let firstTwoDigits = getFirstTwoDigits(yearDigits).toString();

        let secondTwoDigits = getMonthDigitValue(month.value).toString();

        let thirdSecondDigits = getDateDigits(date.value).toString();

        let nextThreeDigits = regionalCode.value[0].toString() + regionalCode.value[1].toString() + gender.toString();

        let firstNineDigits = (firstTwoDigits + secondTwoDigits + thirdSecondDigits + nextThreeDigits).toString();
        
        let sum = getWeightSum(weightPosition, firstNineDigits);

        let remainder = getRemainder(sum).toString();

        let egn = firstNineDigits + remainder;
        
        result.textContent = "Your EGN is: " + egn.toString();
        
        year.value = "";
        month.value = "";
        date.value = "";
        regionalCode.value = "";
        maleOption.checked = false;
        femaleOption.checked = false;
    }
}

    return function() {
        validate();
    }
})()