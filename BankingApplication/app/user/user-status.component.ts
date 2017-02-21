import { Component, OnInit } from '@angular/core';
import { User } from './user.model'
import {UserService} from './user.service'

@Component({
    templateUrl:'../../app/user/user-status.component.html'
})
export class UserStatusComponent {
    result: User;
    status: string = '';
    constructor(private userService: UserService) {
        this.result = new User();
        this.userService.getUserStatus().subscribe((res) => {
            this.result = res;
        });
    }
}
