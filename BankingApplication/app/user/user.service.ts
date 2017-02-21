import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import  'rxjs/Rx';
import { User } from './user.model'
import {Transaction} from './transaction.model'

let headers = new Headers({ 'Content-Type': 'application/json' });
let options = new RequestOptions({ headers: headers });

@Injectable()
export class UserService {
    constructor(private http: Http) { }

    getUserStatus(): Observable<User> {
        return this.http.get('/api/BankingAccounts/userStatus')
            .map(this.extractData).catch(this.handleError);
    };

    sendDeposit(amount: number): Observable<any> {
        return this.http.post('/api/BankingAccounts/depositMoney', amount, options)
            .map(this.extractDataPost).catch(this.handleError);
    }

    sendWithdraw(amount: number): Observable<any> {
        return this.http.post('/api/BankingAccounts/withdrawMoney', amount, options)
            .map(this.extractDataPost).catch(this.handleError);
    }

    sendMoney(userToTransfer: string, amount: number, message: string): Observable<any> {
        return this.http.post('/api/BankingAccounts/sendMoney',
            JSON.stringify({ userName: userToTransfer, amount: amount, message: message}), options)
            .map(this.extractDataPost).catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
    private extractDataPost(res: Response) {
        let body = res;
        return body || {};
    }
    private handleError(error: Response | any) {
        // In a real world app, we might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}