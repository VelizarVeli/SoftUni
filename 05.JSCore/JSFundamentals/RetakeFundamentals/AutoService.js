function AutoService(input) {
  let allInstructions = [];

  for (let i = 0; i < input.length; i++) {
    let strings = input[i].split(",").toString();
    let command = strings.split(" ")[0];

    if (command === "instructions") {
      PutInstructions(strings);
    } else if (command === "addPart") {
      AddPart(strings);
    } else if (command === "repair") {
      Repair(strings);
    }
  }

  function PutInstructions(input) {
    let brand = input.split(" ")[1];
    let checkInstructions = allInstructions.find(obj => obj.brand == brand);
    if (!checkInstructions) {
      let car = {
        brand: brand,
        instructions: true
      };
      allInstructions.push(car);
    }
  }
  function AddPart(input) {
    let brand = input.split(" ")[1];
    let part = input.split(" ")[2];
    let serialNumber = input.split(" ")[3];
    let findBrand = allInstructions.find(obj => obj.brand == brand);
    if (findBrand) {
      findBrand.parts.push({ part: part, serialNumber: serialNumber });
      console.log(brand);
    } else {
      let car = {
        brand: brand,
        parts: [{ part: part, serialNumber: serialNumber }],
        instructions: false
      };
      allInstructions.push(car);
      console.log(`${brand} - {"${part}":["${serialNumber}"]}`);
    }
  }
  function Repair(input) {
    let brand = input.split(" ")[1];
    let check = allInstructions.find(obj => obj.brand == brand);
    if (!check) {
      console.log(`${brand} is not supported`);
    }
  }
}

AutoService([
  "instructions bmw",
  "addPart opel engine GV1399SSS",
  "addPart opel transmission SMF556SRG",
  "addPart bmw engine GV1399SSS",
  "addPart bmw transmission SMF444ORG",
  "addPart opel transmission SMF444ORG",
  "instructions opel",
  'repair opel {"engine":"broken","transmission":"OP8766TRS"}',
  'repair bmw {"engine":"ENG999FPH","transmission":"broken","wheels":"broken"}'
]);
