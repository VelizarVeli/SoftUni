function VatCalculator(price, rate) {
  let check1 = price / (rate + 100);
  let priceWithout = check1 * 100;
  console.log(priceWithout.toFixed(2));
}

VatCalculator(220, 10);
