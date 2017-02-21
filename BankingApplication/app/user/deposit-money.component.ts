import { Component, OnInit } from '@angular/core';
import { User } from './user.model'
import { UserService } from './user.service'

@Component({
    templateUrl: '../../app/user/deposit-money.component.html'
})
export class DepositMoneyComponent {
    Amount: number = 0;
    Status: string = '';
    constructor(private userService: UserService) {
    }

    sendDeposit() {
        this.userService.sendDeposit(this.Amount).subscribe((response) => {
            this.Status = 'Succesfully sent';
        });
    }
}
