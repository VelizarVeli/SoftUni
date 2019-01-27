function solve() {
    let searchBtn = document.getElementById("searchBtn");
    
    let neededRows = document.getElementsByTagName("tr");

    searchBtn.addEventListener("click", function(){
        let inputField = document.getElementById("searchField");


        for(i=2; i<neededRows.length; i++){
            
            neededRows[i].classList.remove("select");
 
        }

        for(i=2; i<neededRows.length; i++){
            for(ch=0; ch<neededRows[i].childElementCount; ch++){
                if(neededRows[i].children[ch].textContent.toLowerCase() == inputField.textContent.toLowerCase()
                 || neededRows[i].children[ch].textContent.toLowerCase().includes(inputField.value.toLowerCase()))
                {
                    neededRows[i].classList.add("select");
                }
            }
        }

        inputField.value = "";
    });
}