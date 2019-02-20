function solve(input) {
    let delimeter = input.pop();
    input.slice(input.length - 1);

    console.log(input.join(`${delimeter}`));
}

solve(['One', 'Two', 'Three', 'Four', 'Five', '-'])