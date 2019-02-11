function solve(examPoints, homeworkCompleted, totalHomework) {
    let totalPoints = (examPoints * 100 / 400) * 0.9;
    let percentHomework = (homeworkCompleted / totalHomework) * 10;
    totalPoints += percentHomework;

    if (examPoints === 400) {
        return '6.00';
    }
    let grade = 3 + 2 * (totalPoints - 100 / 5) / (100 / 2);

    if (grade < 3) {
        return '2.00';
    }
    return grade.toFixed(2);
}

solve(300, 10, 10);