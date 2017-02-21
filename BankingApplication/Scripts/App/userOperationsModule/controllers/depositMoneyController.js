angular.module('userOperationsModule.controllers')
    .controller('depositMoneyController', ['$scope', '$http', function ($scope, $http) {
        var ctrl = this;

        ctrl.Amount = 0;
        ctrl.Status = '';
        ctrl.sendDeposit = function sendDeposit() {
            $http.post('api/BankingAccounts/depositMoney', ctrl.Amount).then(() => {
                ctrl.Status = 'Succesfully sent';
            }).catch((error) => {
                ctrl.Status = error;
            })
        }
    }
    ])