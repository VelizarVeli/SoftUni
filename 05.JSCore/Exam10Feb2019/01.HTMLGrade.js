function solve(examPoints, homeworkCompleted, totalHomework) {
  if (examPoints >= 400) {
    return "6.00";
  }
  if (examPoints > 400) {
    examPoints = 400;
  }
  let totalPoints = ((examPoints * 100) / 400) * 0.9;
  let percentHomework = (homeworkCompleted / totalHomework) * 10;
  totalPoints += percentHomework;
  let maxPoints = 100;
  let grade = 3 + (2 * (totalPoints - maxPoints / 5)) / (maxPoints / 2);
  if (grade > 6) {
    return "6.00";
  }
  if (grade < 3) {
    return "2.00";
  }
  console.log(grade.toFixed(2));
}

solve(300, 10, 10);

solve(200, 5, 5);
