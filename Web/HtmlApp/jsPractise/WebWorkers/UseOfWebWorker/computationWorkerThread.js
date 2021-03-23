self.addEventListener('message',(requestMessage)=>{
    console.log(requestMessage.data);
    let dateTimeToday = new Date();
    while(true){
       self.postMessage({response : `${dateTimeToday.getDate()} \ ${dateTimeToday.getMonth()} \ ${dateTimeToday.getDay()}`});
    }
})