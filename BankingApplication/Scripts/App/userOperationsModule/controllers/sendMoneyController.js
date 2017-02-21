angular.module('userOperationsModule.controllers')
    .controller('sendMoneyController', ['$scope', '$http', function ($scope, $http) {
        var ctrl = this;

        ctrl.Amount = 0;
        ctrl.UserToTransfer = '';
        ctrl.Status = '';
        ctrl.Message = '';

        ctrl.sendMoney = function sendMoney() {
            $http.post('api/BankingAccounts/sendMoney', JSON.stringify({ userName: ctrl.UserToTransfer, amount: ctrl.Amount, message: ctrl.Message })).then(() => {
                ctrl.Status = 'Succesfully sent';
            }).catch((error) => {
                ctrl.Status = error;
            })
        }
    }
])