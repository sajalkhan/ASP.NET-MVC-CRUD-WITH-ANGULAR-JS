
app.service('employeeService',
    function($http, $q) {
        this.getAllemployee = function() {
            var deferred = $q.defer();
            $http.get('/Test/GetUserInfo').then(function(data) {
                deferred.resolve(data);
            }), (function(msg) {
                deferred.reject(msg);
            });
            return deferred.promise;
        }

    });


app.controller('myCtrl',
    function($scope, $http, employeeService) {

        var promise = employeeService.getAllemployee();
        promise.then(function(d) {
                $scope.contact = d.data;
            },
            function(err) {
                alert(err);
            },
            function(notify) {

            });

        $scope.SelectedEmployee = function(ind) {
            $scope.employeeInfo = $scope.contact[ind];
        }

        $scope.Employee = {};

        $scope.AddNew = function() {
            $http.post('/Test/AddNewUser', $scope.Employee).then(function(d) {

                $scope.contact.push(d.data);
                $scope.Employee = {};

            }), (function(err) {
                alert(err);
            });
        }

        $scope.UpdateInfo = function() {
            $http.post('/Test/EditUserInfo', $scope.employeeInfo).then(function(d) {
                $scope.contact.update(d.data);

            }), (function(err) {
                alert(err);
            });
        }

        $scope.DeleteUser = function() {
            $http.post('/Test/DeleteUserInfo', $scope.employeeInfo).then(function(d) {
                $scope.contact.splice($scope.contact.indexOf($scope.employeeInfo), 1);

            }), (function(err) {
                alert(err);
            });
        }

    });

    //app.controller('AboutController',
    //    function($scope) {
    //        $scope.message = "This is about controller";
    //    })
    //.controller('startController',
    //    function($scope) {
    //        $scope.message = "Hello User! Welcome To our Page";
    //    })

    //.config(function ($routeProvider, $locationProvider) {

    //    $routeProvider.when('/startController',
    //        {
    //            templateUrl: 'Test/Start',
    //            controller: 'startController'
    //        }).when('/firstPage',
    //        {
    //            templateUrl: 'Test/Index',
    //            controller: 'startController'
    //        }).when('/secondPage',
    //        {
    //            templateUrl: 'Test/About',
    //            controller: 'startController'
    //        });
    //    $routeProvider.otherwise({ redirectTo: '/' });

    //    $locationProvider.html5Mode(false).hashPrefix('!');
    //});

