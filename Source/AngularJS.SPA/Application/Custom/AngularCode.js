var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {
    debugger;
    $scope.InsertData = function () {
        var action = document.getElementById("btnSave").getAttribute("value");
        if (action === "Submit") {
            $scope.Employee = {};
            $scope.Employee.EmployeeName = $scope.EmployeeName;
            $scope.Employee.EmployeeCity = $scope.EmployeeCity;
            $scope.Employee.EmployeeAge = $scope.EmployeeAge;
            $http({
                method: "post",
                url: "http://localhost:62850/v1/Employee/PostEmployee",
                datatype: "json",
                data: JSON.stringify($scope.Employee)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.EmployeeName = "";
                $scope.EmployeeCity = "";
                $scope.EmployeeAge = "";
            });
        } else {
            $scope.Employe = {};
            $scope.Employe.Emp_Name = $scope.EmpName;
            $scope.Employe.Emp_City = $scope.EmpCity;
            $scope.Employe.Emp_Age = $scope.EmpAge;
            $scope.Employe.Emp_Id = document.getElementById("EmployeeId").value;
            $http({
                method: "post",
                url: "http://localhost:62850/v1/Employee/PutEmployee/45345345345",
                datatype: "json",
                data: JSON.stringify($scope.Employe)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.EmpName = "";
                $scope.EmpCity = "";
                $scope.EmpAge = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Employee";
            });
        }
    };
    $scope.GetAllData = function () {
        $http({
            method: "get",
            url: "http://localhost:62850/v1/Employee/GetEmployees"
        }).then(function (response) {
            $scope.employees = response.data;
        }, function () {
            alert("Error Occur");
        });
    };
    $scope.DeleteEmployee = function (Employee) {
        $http({
            method: "post",
            url: "http://localhost:62850/v1/Employee/DeleteEmployee/4353453453",
            datatype: "json",
            data: JSON.stringify(Emp)
        }).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
        });
    };
    $scope.UpdateEmp = function (Emp) {
        document.getElementById("EmpID_").value = Emp.Emp_Id;
        $scope.EmpName = Emp.Emp_Name;
        $scope.EmpCity = Emp.Emp_City;
        $scope.EmpAge = Emp.Emp_Age;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "Yellow";
        document.getElementById("spn").innerHTML = "Update Employee Information";
    };
});