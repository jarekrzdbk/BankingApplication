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
var router_1 = require('@angular/router');
//import { ComposeMessageComponent } from './compose-message.component';
//import { PageNotFoundComponent } from './not-found.component';
//import { CanDeactivateGuard } from './can-deactivate-guard.service';
//import { AuthGuard } from './auth-guard.service';
//import { SelectivePreloadingStrategy } from './selective-preloading-strategy';
var user_status_component_1 = require('./user/user-status.component');
var deposit_money_component_1 = require('./user/deposit-money.component');
var withdraw_money_component_1 = require('./user/withdraw-money.component');
var send_money_component_1 = require('./user/send-money.component');
var appRoutes = [
    {
        path: 'home',
        component: user_status_component_1.UserStatusComponent,
    },
    {
        path: 'deposit',
        component: deposit_money_component_1.DepositMoneyComponent,
    },
    {
        path: 'withdraw',
        component: withdraw_money_component_1.WithdrawMoneyComponent,
    },
    {
        path: 'sendMoney',
        component: send_money_component_1.SendMoneyComponent,
    },
    //{
    //    path: 'admin',
    //    loadChildren: 'app/admin/admin.module#AdminModule',
    //    canLoad: [AuthGuard]
    //},
    //{
    //    path: 'crisis-center',
    //    loadChildren: 'app/crisis-center/crisis-center.module#CrisisCenterModule',
    //    data: { preload: true }
    //},
    { path: '', redirectTo: '/home', pathMatch: 'full' }
];
var AppRoutingModule = (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        core_1.NgModule({
            imports: [
                router_1.RouterModule.forRoot(appRoutes)
            ],
            exports: [
                router_1.RouterModule
            ]
        }), 
        __metadata('design:paramtypes', [])
    ], AppRoutingModule);
    return AppRoutingModule;
}());
exports.AppRoutingModule = AppRoutingModule;
//# sourceMappingURL=app-routing.module.js.map