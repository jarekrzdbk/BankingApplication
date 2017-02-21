var app = angular.module('site', ['ngRoute', 'userOperationsModule']);

app.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
        when('/home', {
            templateUrl: 'Scripts/App/userOperationsModule/Views/userStatus.html',
            controller: 'userStatusController'
        }).
        when('/deposit', {
            templateUrl: 'Scripts/App/userOperationsModule/Views/deposit.html',
            controller: 'depositMoneyController'
        }).
        when('/withdrawMoney', {
            templateUrl: 'Scripts/App/userOperationsModule/Views/withdrawMoney.html',
            controller: 'withdrawMoneyController'
        }).
        when('/sendMoney', {
            templateUrl: 'Scripts/App/userOperationsModule/Views/sendMoney.html',
            controller: 'sendMoneyController'
        }).
        otherwise({
            redirectTo: '/home'
        });
    }
]);


//app.config(function ($routeProvider) {

//    $routeProvider.when("/home", {
//        controller: ['$scope', '$http', function ($scope, $http) {
//            $http.get('http://localhost:57355/api/BankingAccounts/getUserStatus').then((data) => {
//                $scope.result = data.data.username + " " + data.data.Amount;
//            }).catch((error) => {
//                $scope.result = error;
//            })
//        }],
//        template: "<div>Testing app {{result}}</div>"
//    });

//    $routeProvider.otherwise({ redirectTo: "/home" });

//})