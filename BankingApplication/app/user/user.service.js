"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var http_1 = require('@angular/http');
var Observable_1 = require('rxjs/Observable');
require('rxjs/Rx');
var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
var options = new http_1.RequestOptions({ headers: headers });
var UserService = (function () {
    function UserService(http) {
        this.http = http;
    }
    UserService.prototype.getUserStatus = function () {
        return this.http.get('/api/BankingAccounts/userStatus')
            .map(this.extractData).catch(this.handleError);
    };
    ;
    UserService.prototype.sendDeposit = function (amount) {
        return this.http.post('/api/BankingAccounts/depositMoney', amount, options)
            .map(this.extractDataPost).catch(this.handleError);
    };
    UserService.prototype.sendWithdraw = function (amount) {
        return this.http.post('/api/BankingAccounts/withdrawMoney', amount, options)
            .map(this.extractDataPost).catch(this.handleError);
    };
    UserService.prototype.sendMoney = function (userToTransfer, amount, message) {
        return this.http.post('/api/BankingAccounts/sendMoney', JSON.stringify({ userName: userToTransfer, amount: amount, message: message }), options)
            .map(this.extractDataPost).catch(this.handleError);
    };
    UserService.prototype.extractData = function (res) {
        var body = res.json();
        return body || {};
    };
    UserService.prototype.extractDataPost = function (res) {
        var body = res;
        return body || {};
    };
    UserService.prototype.handleError = function (error) {
        // In a real world app, we might use a remote logging infrastructure
        var errMsg;
        if (error instanceof http_1.Response) {
            var body = error.json() || '';
            var err = body.error || JSON.stringify(body);
            errMsg = error.status + " - " + (error.statusText || '') + " " + err;
        }
        else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable_1.Observable.throw(errMsg);
    };
    UserService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], UserService);
    return UserService;
}());
exports.UserService = UserService;
//# sourceMappingURL=user.service.js.map