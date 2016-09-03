app.controller("CricketerController", function($scope, $uibModal, CricketerService, $window) {
    var serv = CricketerService.GetCricketers();
    serv.success(function(cricketers) {
        $scope.heading = "Cricketers List";
        $scope.displayMessage = false;
        $scope.cricketers = cricketers;
    }).error(function(data, status, headers, config) {
        $scope.message = "Oops... something went wrong";
    });
    $scope.addCricketer = function() {
        var cricketer = {
            ID: 0,
            Name: "",
            ODI: "",
            Test: "",
            Update: false
        };
        $scope.editCricketer(cricketer);
    };
    $scope.editCricketer = function(cricketer) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: "cricketerModal.html",
            controller: "CricController",
            resolve: {
                cricketer: function() {
                    return cricketer;
                }
            }
        });
        modalInstance.result.then(function(cricketer) {
            //alert(cricketer.Update);    
            //If it was deleted    
            if (!cricketer.Update) {
                $scope.cricketers.push(cricketer);
            }
        }, function() {
            //$log.info('Modal dismissed at: ' + new Date());    
        });
    };
    $scope.deleteCricketer = function(Id, index) {
        if ($window.confirm("Are you sure you want to Delete this player?")) {
            var serv = CricketerService.DeleteCricketer(Id);
            serv.success(function() {
                $scope.cricketers.splice(index, 1);
            }).error(function(data, status, headers, config) {
                $scope.displayMessage = true;
                $scope.message = "Oops... something went wrong";
            });
        } else {
        }
    };
});
app.controller("CricController", function($scope, $uibModalInstance, $filter, CricketerService, cricketer) {
    //alert(cricketer.Update);    
    $scope.displayMessage = false;
    $scope.cricketer = cricketer;
    // debugger;    
    if (cricketer.Update) {
        $scope.updateButtonText = "Update";
        $scope.headingtext = "Edit";
    } else {
        $scope.updateButtonText = "Add";
        $scope.headingtext = "Add";
    }
    $scope.update = function() {
        if ($scope.validate()) {
            $scope.cricketer.Name = $scope.cricketer.Name;
            $scope.cricketer.ODI = $scope.cricketer.ODI;
            $scope.cricketer.Test = $scope.cricketer.Test;
            var serv = CricketerService.UpdateCricketer($scope.cricketer);
            serv.success(function(ID) {
                $scope.cricketer.Id = ID;
                //$scope.$parent.assessments.push($scope.assessment);    
                $uibModalInstance.close($scope.cricketer);
            }).error(function(data, status, headers, config) {
                $scope.displayMessage = true;
                $scope.message = "Oops... something went wrong";
            });
        }
    };
    $scope.validate = function() {
        var valid = true;
        var errorMessage = "";
        if ($scope.cricketer.Name == "") {
            errorMessage += "-Name\n";
        }
        if ($scope.cricketer.ODI == "") {
            errorMessage += "-ODI\n";
        }
        if ($scope.cricketer.Test == "") {
            errorMessage += "-Test\n";
        }
        if (errorMessage != "") {
            errorMessage = "Please enter the following.\n" + errorMessage; //alert(errorMessage);    
            $scope.displayMessage = true;
            $scope.message = errorMessage;
            valid = false;
        }
        return valid;
    };
    $scope.cancel = function() {
        $uibModalInstance.dismiss("cancel");
    };
});
app.controller("DetailController", function($scope, CricketerService, $routeParams) {
    var serv = CricketerService.CricketerDetail($routeParams.id);
    serv.success(function(details) {
        $scope.displayMessage = false;
        $scope.detail = details;
    }).error(function(data, status, headers, config) {
        $scope.displayMessage = true;
        $scope.message = "Oops... something went wrong";
    });
    var odistats = CricketerService.CricketerODIStats($routeParams.id);
    odistats.success(function(stats) {
        $scope.displayMessage = false;
        $scope.ODIStats = stats;
    }).error(function(data, status, headers, config) {
        $scope.displayMessage = true;
        $scope.message = "Oops... something went wrong";
    });
    var teststats = CricketerService.CricketerTestStats($routeParams.id);
    teststats.success(function(stats) {
        $scope.displayMessage = false;
        $scope.TestStats = stats;
    }).error(function(data, status, headers, config) {
        $scope.displayMessage = true;
        $scope.message = "Oops... something went wrong";
    });
});
Angular;
App;
var app = angular.module("cricketerapp", ["ngRoute", "ngAnimate", "ui.bootstrap"]); //// configure routes    
app.config(function($routeProvider) {
    debugger;
    $routeProvider.when("/", {
        templateUrl: "Angular/Controllers/CricketerView.html",
        controller: "CricketerController"
    }).when("/detail/:id", {
        templateUrl: "Angular/Controller/DetailView.html",
        controller: "DetailController"
    }).otherwise({
        redirectTo: "/"
    });
});