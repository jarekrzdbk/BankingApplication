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
var forms_1 = require('@angular/forms');
var common_1 = require('@angular/common');
var http_1 = require('@angular/http');
var user_status_component_1 = require('./user-status.component');
var deposit_money_component_1 = require('./deposit-money.component');
var withdraw_money_component_1 = require('./withdraw-money.component');
var send_money_component_1 = require('./send-money.component');
var user_service_1 = require('./user.service');
var UserModule = (function () {
    function UserModule() {
    }
    UserModule = __decorate([
        core_1.NgModule({
            imports: [
                common_1.CommonModule, http_1.HttpModule, forms_1.FormsModule
            ],
            declarations: [
                user_status_component_1.UserStatusComponent, deposit_money_component_1.DepositMoneyComponent, withdraw_money_component_1.WithdrawMoneyComponent, send_money_component_1.SendMoneyComponent
            ],
            providers: [
                user_service_1.UserService
            ]
        }), 
        __metadata('design:paramtypes', [])
    ], UserModule);
    return UserModule;
}());
exports.UserModule = UserModule;
//# sourceMappingURL=user.module.js.map