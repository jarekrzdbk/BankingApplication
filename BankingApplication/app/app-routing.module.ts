import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//import { ComposeMessageComponent } from './compose-message.component';
//import { PageNotFoundComponent } from './not-found.component';

//import { CanDeactivateGuard } from './can-deactivate-guard.service';
//import { AuthGuard } from './auth-guard.service';
//import { SelectivePreloadingStrategy } from './selective-preloading-strategy';

import { UserStatusComponent } from './user/user-status.component'
import { DepositMoneyComponent } from './user/deposit-money.component'
import { WithdrawMoneyComponent } from './user/withdraw-money.component'
import { SendMoneyComponent } from './user/send-money.component'

const appRoutes: Routes = [
    {
        path: 'home',
        component: UserStatusComponent,
    },
    {
        path: 'deposit',
        component: DepositMoneyComponent,
    },
    {
        path: 'withdraw',
        component: WithdrawMoneyComponent,
    },
    {
        path: 'sendMoney',
        component: SendMoneyComponent,
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

@NgModule({
    imports: [
        RouterModule.forRoot(
            appRoutes
        )
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }