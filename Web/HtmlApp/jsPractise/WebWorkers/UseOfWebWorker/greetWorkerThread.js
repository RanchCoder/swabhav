self.addEventListener('message',(requestMessage)=>{
    console.log(requestMessage.data);
    self.postMessage({response : "Hello user how are you"});
})