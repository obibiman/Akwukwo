app.service("StudentService", function ($http) {
    //**********----Get All Records----***************  
    var urlGet = "";
    this.getAll = function (apiRoute) {
        urlGet = apiRoute;
        return $http.get(urlGet);
    }
});