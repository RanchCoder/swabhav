interface IUser{
    id : number;
    username : string;
    showDetail():string;
}

var user1 : IUser = {
  id:1,
  username:"vishal",
  showDetail:():string=>{return "name " + this.username + " id " + this.id}
}

console.log(user1.showDetail());