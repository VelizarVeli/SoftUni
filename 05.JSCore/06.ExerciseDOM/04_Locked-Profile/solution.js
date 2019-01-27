function solve() {
   let buttons = document.getElementsByTagName("button");
   
   function Lock(userLockBtn, userUnlockBtn){
      userLockBtn.addEventListener("click", function(e){
         userUnlockBtn.removeAttribute("checked");
         userLockBtn.setAttribute("checked", "");
      })
   }

   function Unlock(userLockBtn, userUnlockBtn){
      userUnlockBtn.addEventListener("click", function(e){
         userLockBtn.removeAttribute("checked");
         userUnlockBtn.setAttribute("checked", "");
      })
   }

   function ShowOrHide(currentBtn, userHiddenInfo){
      if(currentBtn.textContent == "Show more"){
         userHiddenInfo.style.display = "block";
         currentBtn.textContent = "Hide it";
      }
      else{
         userHiddenInfo.style.display = "none";
         currentBtn.textContent = "Show more";
      }
   }

   for(i=0; i<buttons.length; i++){
      let currentIndex = i;
      let currentBtn = buttons[i];

      let userLockBtn = document.getElementsByName("user" + (+currentIndex + 1) + "Locked")[0];
      let userUnlockBtn = document.getElementsByName("user" + (+currentIndex + 1) + "Locked")[1];

      Lock(userLockBtn, userUnlockBtn);
      Unlock(userLockBtn, userUnlockBtn);
   
      currentBtn.addEventListener("click", function(e){
         let userHiddenInfo = document.getElementById("user" + (+currentIndex + 1) + "HiddenFields");

         if(userLockBtn.hasAttribute("checked") == false && userUnlockBtn.hasAttribute("checked") == true){
           ShowOrHide(currentBtn, userHiddenInfo);
         }
      });
   }

} 