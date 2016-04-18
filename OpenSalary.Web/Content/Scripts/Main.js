import JudgmentCards from "./Modules/JudgmentCards";

document.addEventListener("DOMContentLoaded", function(event) {
    var username = document.getElementById("user-hide").textContent;    
    var challengeCards = new JudgmentCards(username);    
});