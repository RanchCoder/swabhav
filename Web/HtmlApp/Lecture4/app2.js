function play(param1,param2,param3){
    this.param1 = param1;
    this.param2 = param2;
    this.param3 = param3;
    this.fullName = function(){
        console.log(this.param1 + " "  + this.param2 + " " + this.param3);
    }
};