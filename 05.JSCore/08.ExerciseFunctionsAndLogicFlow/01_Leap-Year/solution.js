function leapYear() {
    let btn = document.querySelector("#exercise button").addEventListener('click', checkTheYear);

    function checkTheYear() {
        let inputYear = document.querySelector("#exercise input").value;

        let year = "";
        let leapOrNot = ((inputYear % 4 == 0) && (inputYear % 100 != 0)) || (inputYear % 400 == 0);
        if (leapOrNot) {
            year = 'Leap Year';
        } else {
            year = 'Not Leap Year';
        }
        document.querySelector("#year div").innerHTML = inputYear;
        document.querySelector("#year h2").innerHTML = year;
        document.querySelector("#exercise input").value = "";
    }
}