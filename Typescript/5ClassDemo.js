var Person = /** @class */ (function () {
    function Person() {
    }
    Object.defineProperty(Person.prototype, "Id", {
        get: function () {
            return this.id;
        },
        set: function (id) {
            this.id = id;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Person.prototype, "Name", {
        get: function () {
            return this.personName;
        },
        set: function (personName) {
            this.personName = personName;
        },
        enumerable: false,
        configurable: true
    });
    Person.prototype.getCompleteInfo = function () {
        return "Id : " + this.Id + " , Name : " + this.Name;
    };
    return Person;
}());
var personObj = new Person();
personObj.Id = 1;
personObj.Name = "Vishal";
console.log(personObj.getCompleteInfo());
