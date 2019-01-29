(function () {
    function Test() {

        let weightPosition = [2, 4, 8, 5, 10, 9, 7, 3, 6];
        let responseSpan = document.getElementById("response");


        let checkBtn = document.querySelector("button");
        checkBtn.addEventListener("click", function () {
            let numbers = document.querySelector("input").value.toString();

            let validationCounter = 0;

            let sum = 0;

            function SumWeight() {
                let numsArr = numbers.split("");
                for (i = 0; i < numsArr.length; i++) {
                    if (+numbers[i] < 0 || +numbers[i] > 9) {
                        validationCounter++;
                    }

                    if (i + 1 == 10) {
                        break;
                    } else {
                        sum += (+numbers[i] * +weightPosition[i]);
                    }
                }
            }

            SumWeight();

            let remainder = (sum % 11);
            if (((remainder) % 10) === 0) {
                remainder = 0;
            }

            if ((+remainder === +numbers[9]) && (validationCounter === 0)) {
                responseSpan.innerHTML = "This number is Valid!";
            } else {
                responseSpan.innerHTML = "This number is NOT Valid!";
            }
        })
    }

    return function () {
        Test();
    }
})();