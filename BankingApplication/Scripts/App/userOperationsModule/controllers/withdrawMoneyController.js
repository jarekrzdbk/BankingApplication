angular.module('userOperationsModule.controllers')
    .controller('withdrawMoneyController', ['$scope', '$http', function ($scope, $http) {
        var ctrl = this;

        ctrl.Amount = 0;
        ctrl.Status = '';
        ctrl.sendWithdrow = function sendWithdrow() {
            $http.post('api/BankingAccounts/withdrawMoney', ctrl.Amount).then(() => {
                ctrl.Status = 'Succesfully sent';
            }).catch((error) => {
                ctrl.Status = error;
            })
        }
    }
    ])