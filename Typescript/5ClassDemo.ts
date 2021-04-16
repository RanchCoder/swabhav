class Person{

     id : number;
     personName : string;

     public get Id():number{
         return this.id;
     }


     public get Name():string{
         return this.personName;
     }

     public set Id(id:number){
        this.id = id;
    }

    public set Name(personName:string){
        this.personName = personName;
    }

    public getCompleteInfo():string{
        return `Id : ${this.Id} , Name : ${this.Name}`;
    }
}

var personObj = new Person();
personObj.Id = 1;
personObj.Name = "Vishal";
console.log(personObj.getCompleteInfo());