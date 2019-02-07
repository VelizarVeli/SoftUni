function solve() {
    // let str = 'ahah Second-Testov )*))&&ba SOF/VAR ela** FB973 - Bulgaria*Air -opFB900 pa-SOF/VAr//_- T12G12 STD08:45  STA09:35 , all';
    let str = document.getElementById('str').value;
    let divRes = document.getElementById('result');
    let chunks = str.split(',');
    let input = chunks[0];
    let type = chunks[1].trim();

    let namePattern = / ([A-Z]+([A-Za-z]*)?)(-[A-Z][A-Za-z]*\.)?-([A-Z][A-Za-z]*)? /g;
    let airportPattern = /( ([A-Z]{3})\/([A-Z]{3}) )/gm;
    let flightPattern = /( [A-Z]{1,3}[0-9]{1,5} )/gm;
    let companyPattern = /(- [A-Z]([A-Za-z]+)*\*[A-Z]([A-Za-z]*) )/gm;

    let name = namePattern.exec(input)[0].trim().replace(/-/g, ' ');
    let flight = flightPattern.exec(input)[0].trim();
    let company = companyPattern.exec(input)[0].replace(/[ \-]/g, '').replace(/[*]/g, ' ');
    let airport = airportPattern.exec(input);

    switch (type) {
        case 'name':
            divRes.textContent = (`Mr/Ms, ${name}, have a nice flight!`);
            break;
        case 'flight':
            divRes.textContent = (`Your flight number ${flight} is from ${airport[2]} to ${airport[3]}.`);
            break;
        case 'company':
            divRes.textContent = (`Have a nice flight with ${company}.`);
            break;
        case 'all':
            divRes.textContent = (`Mr/Ms, ${name}, your flight number ${flight} is from ${airport[2]} to ${airport[3]}. Have a nice flight with ${company}.`);
            break;
    }
}