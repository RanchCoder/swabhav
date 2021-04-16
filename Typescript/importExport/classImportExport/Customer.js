"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Customer = void 0;
var Customer = /** @class */ (function () {
    function Customer(_firstname, _lastname) {
        this._firstname = _firstname;
        this._lastname = _lastname;
    }
    Object.defineProperty(Customer.prototype, "firstname", {
        get: function () {
            return this._firstname;
        },
        set: function (firstname) {
            this._firstname = firstname;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(Customer.prototype, "lastname", {
        get: function () {
            return this._lastname;
        },
        set: function (lastname) {
            this._lastname = lastname;
        },
        enumerable: false,
        configurable: true
    });
    return Customer;
}());
exports.Customer = Customer;
