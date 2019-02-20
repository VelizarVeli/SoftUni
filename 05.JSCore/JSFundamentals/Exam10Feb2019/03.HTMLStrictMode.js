function solve(str) {
    let namePattern = (/(<\w+>)(.+)(<\/\w+>)/gmi);

    let match;

    while (match = namePattern.exec(str)) {
        match = match[2];
        if (namePattern.test(match)) {
        }
        console.log(match);
    }
}

solve(`['<h1><span>Hello World!</span></h1>',
'<p>I am Peter.']`);