import { Component, OnInit } from '@angular/core';
import { User } from './user.model'
import { UserService } from './user.service'

@Component({
    templateUrl: '../../app/user/send-money.component.html'
})
export class SendMoneyComponent {
    Amount: number = 0;
    UserToTransfer: string = '';
    Message: string = '';
    Status: string = '';
    constructor(private userService: UserService) {
    }

    sendMoney() {
        this.userService.sendMoney(this.UserToTransfer, this.Amount, this.Message).subscribe((response) => {
            this.Status = 'Succesfully sent';
        });
    }
}
