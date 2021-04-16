export class Customer{

    constructor(private _firstname:string,private _lastname:string){

    }

    public get firstname():string{
        return this._firstname;
    }

    public set firstname(firstname:string){
        this._firstname = firstname;
    }

    public get lastname():string{
        return this._lastname;
    }

    public set lastname(lastname:string){
        this._lastname = lastname;
    }
}