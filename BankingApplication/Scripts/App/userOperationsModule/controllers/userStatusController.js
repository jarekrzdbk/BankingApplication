angular.module('userOperationsModule.controllers')
    .controller('userStatusController', ['$scope', '$http', function ($scope, $http) {
        $http.get('/api/BankingAccounts/userStatus').then((data) => {
            $scope.result = data.data;
        }).catch((error) => {
            $scope.Status = error;
        })

        $scope.Status = '';
    }
  ])