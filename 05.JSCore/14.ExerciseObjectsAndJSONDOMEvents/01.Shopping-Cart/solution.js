function solve() {
    let buttonsArr = Array.from(document.querySelectorAll('button'))
    let [goodsObj, totalSum] = [{}, 0]
 
    for (let i = 0; i < buttonsArr.length; i++) {
        if (i == buttonsArr.length - 1) {
            buttonsArr[i].addEventListener('click', event => {
                let printArea = document.querySelectorAll('div textarea')[0];
                let goodsBought = Object.keys(goodsObj).join(', ');
                printArea.textContent += `You bought ${goodsBought} for ${totalSum.toFixed(2)}.\n`;
            });
        } else {
            buttonsArr[i].addEventListener('click', event => {
                let goods = document.querySelectorAll('div [class="product"] p');
                let [good, price] = [goods[i * 2].textContent, goods[i * 2 + 1].textContent.split(' ')[1]];
                let printSeq = `Added ${good} for ${price} to the cart.`;
                goodsObj.hasOwnProperty(good) ? goodsObj[good] += +price : goodsObj[good] = +price;
                let printArea = document.querySelectorAll('div textarea')[0];
                printArea.textContent += printSeq + '\n';
                totalSum += +price;
            });
        }
    }
}