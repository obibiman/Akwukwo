app.controller("StudentCtrl", ["$scope", "StudentService",
    // we inject StudentService  inject becuse we call getAll method for get all student  
function ($scope, studentService) {
    // this is base url   
    var baseUrl = "http://localhost:62850/v1/Student/";
    // get all student from databse  
    $scope.getStudents = function () {
        var apiRoute = baseUrl + "GetStudents";
        var students = studentService.getAll(apiRoute);
        students.then(function (response) {
            $scope.students = response.data;
        },
        function (error) {
            console.log("Error: " + error);
        });
    }
    $scope.getStudents();
}]);