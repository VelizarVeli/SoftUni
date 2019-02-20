function solve(steps, footprintLength, speedInKmPerH) {
    let distanceInMeters = steps * footprintLength;

    let speedForMeterInSecond = speedInKmPerH / 3.6;

    let timeSecond = Math.round(distanceInMeters / speedForMeterInSecond);

    let rests = Math.floor(distanceInMeters / 500);
    timeSecond += rests * 60;

    let seconds = timeSecond % 60;
    let minutes = (timeSecond - seconds) / 60;
    let hour = Math.floor((timeSecond - seconds) / 3600);

    formatTheOutput(hour, minutes, seconds);

    function formatTheOutput(hour, minutes, seconds) {
        if (hour < 10) {
            hour = '0' + hour;
        }

        if (minutes < 10) {
            minutes = '0' + minutes;
        }

        if (seconds < 10) {
            seconds = '0' + seconds;
        }
        console.log(`${hour}:${minutes}:${seconds}`);
    }

}

solve(4000, 0.60, 5);
solve(2564, 0.70, 5.5);