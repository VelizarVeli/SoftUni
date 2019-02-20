function solve(arr, workouts) {
    let sex = arr[0];
    let weight = arr[1];
    let height = arr[2];
    let age = arr[3];

    caloriesMan = 66 + 13.8 * weight + 5 * height - 6.8 * age;
    caloriesWoman = 655 + 9.7 * weight + 1.85 * height - 4.7 * age;

    let basicMethabolism = 0;
    let result = 0;

    if (sex === 'm') {
        basicMethabolism = caloriesMan;
    } else if (sex === 'f') {
        basicMethabolism = caloriesWoman;
    }
    switch (workouts) {

        case 0:
        result = basicMethabolism *= 1.2;
            break;
        case 1:
        result = basicMethabolism *= 1.375;
            break;
        case 2:
        result = basicMethabolism *= 1.375;
            break;
        case 3:
        result = basicMethabolism * 1.55;
            break;
        case 4:
        result = basicMethabolism * 1.55;
            break;
        case 5:
        result = basicMethabolism * 1.55;
            break;
        case 6:
        result = basicMethabolism *= 1.725;
            break;
        case 7:
        result = basicMethabolism *= 1.725;
            break;
        case workouts > 7:
        result = basicMethabolism *= 1.9;
            break;
    }

    console.log(Math.round(result));
}

solve(['f', 46, 157, 32], 5);
solve(['m', 86, 185, 25], 3);