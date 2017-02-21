import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { UserStatusComponent } from './user-status.component'
import { DepositMoneyComponent } from './deposit-money.component'
import { WithdrawMoneyComponent } from './withdraw-money.component'
import { SendMoneyComponent } from './send-money.component'
import { UserService } from './user.service'

@NgModule({
    imports: [
        CommonModule, HttpModule, FormsModule
    ],
    declarations: [
        UserStatusComponent, DepositMoneyComponent, WithdrawMoneyComponent, SendMoneyComponent
    ],
    providers: [
        UserService
    ]
})
export class UserModule { }