function solve() {
    let buttons = Array.from(document.getElementsByTagName('button'));
 
    let submitButton = buttons[0];
 
    submitButton.addEventListener('click', (e) => {
        e.preventDefault();
 
        let userInfoTokens = document.getElementsByClassName('user-info')[0].children;
 
        let userName = userInfoTokens[1].value;
        let password = userInfoTokens[3].value;
        let email = userInfoTokens[5].value;
 
        let topics = Array.from(document.getElementsByClassName('topics')[0].children);
 
        let selectedTopics = [];
 
        for (let i = 0; i < topics.length; i++) {
            let topic = topics[i];
 
            if(!topic.checked){
                continue;
            }
 
            selectedTopics.push(topic.value);
        }
 
        let user = {
            userName : userName,
            password : password,
            email : email,
            topics : selectedTopics
        };
 
        let usernameTd = createTd(user.userName);
        let emailTd = createTd(user.email);
        let topicsTd = createTd(selectedTopics.join(' '));
 
        let tableRow = document.createElement('tr');
 
        tableRow.appendChild(usernameTd);
        tableRow.appendChild(emailTd);
        tableRow.appendChild(topicsTd);
 
        let tableBody = document.getElementsByTagName('tbody')[0];
        tableBody.appendChild(tableRow);
    });
 
    let searchButton = buttons[1];
 
    searchButton.addEventListener('click', () => {
        let input = document.getElementById('exercise').children[1].value;
 
        let tds = Array.from(document.querySelectorAll('table tbody tr td'));
 
        for(let td of tds){
            td.parentNode.style.visibility = 'hidden';
 
            if(td.textContent.includes(input)){
                td.parentNode.style.visibility = 'visible';
            }
        }
    });
 
    function createTd(textContent) {
        let td = document.createElement('td');
        td.textContent = textContent;
 
        return td;
    }
}