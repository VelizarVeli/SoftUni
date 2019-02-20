function solve() {
   let num = Number(document.getElementById('num').value);
   let result = [];
   for (let i = 1; i <= num; i++) {
      if (num % i === 0) {
         result.push(i);
      }
   }
   let finalRes = document.getElementById('result');
   finalRes.innerHTML = result.join(' ');
}