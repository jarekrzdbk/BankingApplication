import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: `
    <h1 class="title">Banking Account</h1>
    <nav>
        <ul>
            <li><a routerLink="/home" routerLinkActive="active">home</a></li>
            <li><a routerLink="/deposit">deposit</a></li>
            <li><a routerLink="/withdraw">withdraw</a></li>
            <li><a routerLink="/sendMoney">sendMoney</a></li>
        </ul>
    </nav>
    <router-outlet></router-outlet>
    <router-outlet name="popup"></router-outlet>
  `,
})
export class AppComponent  { name = 'Angular'; }
