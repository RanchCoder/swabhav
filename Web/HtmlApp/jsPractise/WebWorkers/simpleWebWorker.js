self.addEventListener('message',(requestData)=>{
    console.log("request at server : "+ requestData.data);
    self.postMessage({response : "got your request!!!"});
});