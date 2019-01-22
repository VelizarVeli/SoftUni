function solve(weekDay, amenity, hour) {
    let price = 0;
    if (weekDay === 'Saturday' || weekDay === 'Sunday') {

        switch (amenity) {
            case 'Fitness': price = 8; break;
            case 'Sauna': price = 7; break;
            case 'Instructor': price = 15; break;
        }
    }
    else {
        switch (amenity) {
            case 'Fitness':
                if (hour >= 8 && hour <= 15) {
                    price = 5;
                }
                else {
                    price = 7.5;
                }; break;
            case 'Sauna':
                if (hour >= 8 && hour <= 15) {
                    price = 4;
                }
                else {
                    price = 6.5;
                }; break;
            case 'Instructor':
                if (hour >= 8 && hour <= 15) {
                    price = 10;
                }
                else {
                    price = 12.5;
                }; break;
        }
    }
    console.log(price);
}
solve('Monday', 'Sauna', 15.30);