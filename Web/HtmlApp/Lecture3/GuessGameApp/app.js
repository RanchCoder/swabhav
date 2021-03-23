const BALL_LIMIT = 48;
const TARGET_NUMBER = generateRandomNumber();
let moves = 0;
var root = getComputedStyle(document.documentElement);
var alertBox = document.getElementById("alertBox");
var messageBox = document.getElementById("messageBox");
var message = document.getElementById("message");
var gameDescriptionBox = document.getElementById("game-description");
var gameSection = document.getElementById("game-section");
var startButton = document.getElementById("startSectionButton");
var cancelIcon = document.getElementById("cancel-icon");
let mainArea = document.getElementById("main-area");


 startButton.addEventListener('click',()=>{
      
      gameDescriptionBox.style.opacity = "0";
      gameDescriptionBox.style.height = "0"; 
 });


initializeGameBoard();
playGame();

  

function initializeGameBoard(){
    mainArea.innerHTML = '';
    for (var i = 0; i < BALL_LIMIT; i++) {
        var ball = document.createElement("div");
        ball.classList.add("game-ball");
        ball.id = `ball-${i + 1}`;
        ball.style.backgroundColor = "grey";
        mainArea.append(ball);
      }
      
}

function playGame(){
    mainArea.addEventListener("click", (e) => {     
         moves++;
         checkTheGuessNumber(e);
        
      });
}

function checkTheGuessNumber(element){
    let id = fetchId(element.target.id);
    if (id < TARGET_NUMBER) {
        element.target.style.backgroundColor = root.getPropertyValue(
          "--red-ball-color"
        );
      } else if (id > TARGET_NUMBER) {
        element.target.style.backgroundColor = root.getPropertyValue(
          "--green-ball-color"
        );
      } else if (id == TARGET_NUMBER) {
        element.target.style.backgroundColor = root.getPropertyValue(
          "--blue-ball-color"
        );
        showMessageBox();
      }else{
          
      }
}

cancelIcon.addEventListener('click',()=>{
    removeMessageBox();
});

function showMessageBox(){    
    alertBox.style.display = "block";
    message.innerHTML = `Bingo!!! Target Reached in ${moves} moves.`;
    messageBox.classList.add("messageBox-animate");
    gameDescriptionBox.classList.add("blurEffect");
    gameSection.classList.add("blurEffect");
         
    messageBox.addEventListener('click',(e)=>{
        if(e.target.id === "yes"){
            gameReset();
        }else{
            removeMessageBox();
        }
    });
}


function removeMessageBox(){  
    alertBox.style.display = "none";
    messageBox.classList.remove("messageBox-animate");
    gameDescriptionBox.classList.remove("blurEffect");
    gameSection.classList.remove("blurEffect");

}



function fetchId(id) {
  return id.split("-")[1];
}

function generateRandomNumber() {
    return Math.floor(Math.random() * (BALL_LIMIT - 1 + 1));
  }
  

function gameReset(){
    location.reload();      
}


