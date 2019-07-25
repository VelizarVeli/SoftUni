function solve(){
   let kingdoms = [];
   function addKingdom(){
       document.querySelector('#kingdom button').addEventListener('click', () =>{
           let kingdomInput = document.querySelectorAll('#kingdom input')[0].value;
           let kingInput = document.querySelectorAll('#kingdom input')[1].value;

           const allowedKingdomNames = ['CASTLE', 'DUNGEON', 'FORTRESS', 'INFERNO', 'NECROPOLIS', 'RAMPART', 'STRONGHOLD', 'TOWER', 'CONFLUX'];
           if (!allowedKingdomNames.includes(kingdomInput.toUpperCase())){
               document.querySelectorAll('#kingdom input')[0].value = '';
               document.querySelectorAll('#kingdom input')[1].value = '';
               return;
           }
           if (kingInput.length < 2){
               document.querySelectorAll('#kingdom input')[1].value = '';
               document.querySelectorAll('#kingdom input')[0].value = '';
               return;
           }

           let kindgomSelector = `#${kingdomInput.toLowerCase()}`;
           let $kingdomElement = $(kindgomSelector);
           $kingdomElement.css('display','inline-block');
           let $h1KingdomName = $('<h1></h1>').text(kingdomInput.toUpperCase());
           let $divClassCastle = $('<div class="castle"></div>');
           let $h2KingName = $('<h2></h2>').text(kingInput.toUpperCase());
           let $fieldSet =$('<fieldset><legend>Army</legend><p>TANKS - 0</p><p>FIGHTERS - 0</p><p>MAGES - 0</p><div class="armyOutput"></div></fieldset>');

           $kingdomElement.append($h1KingdomName).append($divClassCastle).append($h2KingName).append($fieldSet);
           let kingdom = {
               kingdomName : kingdomInput.toUpperCase(),
               kingName : kingInput.toUpperCase(),
               army : {
                   tank : 0,
                   fighter : 0,
                   mage : 0,
                   armyOutput : []
               }
           };
           kingdoms.push(kingdom);
           console.log(kingdoms);
       })
   }
   addKingdom();

   function joinKingdom() {
       document.querySelector('#characters button').addEventListener('click', () =>{
           let type = $("input[name=characterType]:checked").val();
           if (type === undefined){
               return;
           }
           let inputs = document.querySelectorAll('#characters input');
           let characterInput = inputs[3].value;
           let kingdomInput = inputs[4].value;
           if (characterInput.length < 2){
               inputs[3].value = '';
               inputs[4].value = '';
               return;
           }
           if(kingdoms.findIndex(x => x.kingdomName === kingdomInput.toUpperCase()) < 0){
               inputs[4].value = '';
               inputs[3].value = '';
               return;
           }

           let currentKingdom = kingdoms.find(x => x.kingdomName === kingdomInput.toUpperCase());
           currentKingdom.army[type]++;
           currentKingdom.army.armyOutput.push(characterInput);

           let kingdomElementFieldsetSelector = `#${kingdomInput.toLowerCase()} fieldset`;
           let $kingdomElementFieldset = $(kingdomElementFieldsetSelector);
           $kingdomElementFieldset.empty();
           let armyElement = $(`<legend>Army</legend><p>TANKS - ${currentKingdom.army.tank}</p><p>FIGHTERS - ${currentKingdom.army.fighter}</p><p>MAGES - ${currentKingdom.army.mage}</p><div class="armyOutput">${currentKingdom.army.armyOutput.join(' ')} </div>`);
           $kingdomElementFieldset.append(armyElement);
       });

   }
   joinKingdom();


   function fight() {
       document.querySelector('#actions button').addEventListener('click',() => {
           let attackerInput = document.querySelector('input[placeholder="Attacker..."]').value;
           let defenderInput = document.querySelector('input[placeholder="Defender..."]').value;
           let attacker = kingdoms.find(x => x.kingdomName === attackerInput.toUpperCase());
           let defender =  kingdoms.find(x => x.kingdomName === defenderInput.toUpperCase());
           if(attacker === undefined){
               document.querySelector('input[placeholder="Attacker..."]').value = '';
               document.querySelector('input[placeholder="Defender..."]').value = '';
               return;
           }
           if(defender === undefined){
               document.querySelector('input[placeholder="Attacker..."]').value = '';
               document.querySelector('input[placeholder="Defender..."]').value = '';
           }
           function calculateAtackPoints(kingdom) {
               let army = kingdom.army;
               let attackPoints = 0;
               for(let person in army){
                   if (person === 'mage'){
                       attackPoints += 70 * army[person];
                   }else if(person === 'fighter'){
                       attackPoints += 50 * army[person];
                   }else if(person === 'tank'){
                       attackPoints += 20 * army[person];
                   }
               }
               return attackPoints;
           }
           function calculateDefensePoints(kingdom) {
               let army = kingdom.army;
               let defensePoints = 0;
               for(let person in army){
                   if (person === 'mage'){
                       defensePoints += 30 * army[person];
                   }else if(person === 'fighter'){
                       defensePoints += 50 * army[person];
                   }else if(person === 'tank'){
                       defensePoints += 80 * army[person];
                   }
               }
               return defensePoints;
           }

           let attackerPoints = calculateAtackPoints(attacker);
           let defenderPoints = calculateDefensePoints(defender);

           if (attackerPoints > defenderPoints){
               defender.kingName = attacker.kingName;
               let defenderElementKingNameSelector = `#${defenderInput.toLowerCase()} h2`;
               let $defenderElement = $(defenderElementKingNameSelector);
               $defenderElement.text(attacker.kingName);
           }
       });
   }
   fight();
}