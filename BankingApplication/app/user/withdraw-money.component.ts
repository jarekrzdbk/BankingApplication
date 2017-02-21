import { Component, OnInit } from '@angular/core';
import { User } from './user.model'
import { UserService } from './user.service'

@Component({
    templateUrl: '../../app/user/withdraw-money.component.html'
})
export class WithdrawMoneyComponent {
    Amount: number = 0;
    Status: string = '';
    constructor(private userService: UserService) {
    }

    sendWithdraw() {
        this.userService.sendWithdraw(this.Amount).subscribe((response) => {
            this.Status = 'Succesfully sent';
        });
    }
}
