class JudgmentCards {
    constructor(user) {
        this.user = user;
        this.registerClickEvent();
        this.registeredTextEvent();
    }
    registeredTextEvent() {
        var self = this;
        document.querySelector('#text-freemotivation').addEventListener('blur', evt => self.updateFreeMotivationOnServer(evt));
    }
    registerClickEvent() {
        var self = this;
        var cards = document.getElementsByClassName("card");        
        for (var i = 0; i < cards.length; i++) {
            if (cards[i].classList.contains('card--free')) {
                continue;
            }
            (function() {
                cards[i].addEventListener("click", function(e) {
                    e.preventDefault();

                    self.updateJudgmentCard(this);
                    self.updateJudgmentOnServer(this);

                });                                
            }());
        }
    }
    updateJudgmentCard(card) {
        
        var cardIsMarkedAsComplete = card.classList.contains("card--complete");
        var category = card.getAttribute('data-category');
        var level = card.getAttribute('data-level');
        var categoryCards = document.getElementsByClassName(category);
        for (var i = 0; i < categoryCards.length; i++) {
            categoryCards[i].classList.remove("card--complete");
        }

        if (cardIsMarkedAsComplete) {
            card.classList.remove("card--complete"); 
        } else {
            card.classList.add("card--complete");                    
        }        

        var event = new CustomEvent("judgmentCardSaved", { "category": category, "level":level });
        document.dispatchEvent(event);
    }
    
    updateJudgmentOnServer(card) {        
        var xhr = new XMLHttpRequest();
        xhr.open('POST', 'Home/ToggleJudgment');
        xhr.setRequestHeader('Content-Type', 'application/json');
        xhr.onload = function () {
            if (xhr.status !== 200) {
                //Something went wrong message.
                // return to login form
                var username = document.getElementById("user-hide").textContent;
                window.location.href = "/Authentication?name=" + username;
                return;
            }             
        };
        xhr.send(JSON.stringify({ 
            category: card.getAttribute('data-category'),
            level: card.getAttribute('data-level'),
            currentUser: this.user
        }));
    }
    updateFreeMotivationOnServer(evt) {
        var xhr = new XMLHttpRequest();
        xhr.open('POST', 'Home/UpdateFreeMotivation');
        xhr.setRequestHeader('Content-Type', 'application/json');
        xhr.onload = function () {
            if (xhr.status !== 200) {
                //Something went wrong message.
                // return to login form
                var username = document.getElementById("user-hide").textContent;
                window.location.href = "/Authentication?name=" + username;
                return;
            }
        };
        xhr.send(JSON.stringify({
            text: evt.target.value,            
            currentUser: this.user
        }));
    }
}
module.exports = JudgmentCards;