app.service("CricketerService", function($http) {
    this.GetCricketers = function() {
        var req = $http.get("v1/Cricketer/GetCricketers/");
        return req;
    };
    this.Cricketer = function (cricketerId) {
        var req = $http.get("v1/Cricketer/GetCricketer/" + cricketerId);
        return req;
    };
    this.PostCricketer = function (cricketer) {
        var req = $http.post("v1/Cricketer/PostCricketer", cricketer);
        return req;
    };
    this.PostCricketers = function (cricketers) {
        var req = $http.get("v1/Cricketer/PostCricketers", cricketers);
        return req;
    };
    this.PutCricketer = function (cricketerId, cricketerModel) {
        var req = $http.put("v1/Cricketer/PutCricketer", cricketerId,  cricketerModel);
        return req;
    };
    this.DeleteCricketer = function (cricketerId) {
        var req = $http.delete("v1/cricketer/DeleteCricketer/" + cricketerId );
        return req;
    };
    this.DeleteCricketers = function (cricketers) {
        var req = $http.delete("v1/cricketer/DeleteCricketers", cricketers);
        return req;
    };
    this.CricketerDetail = function(cricketerId) {
        var req = $http.get("v1/CricketerDetail/GetCricketerDetail/" + cricketerId);
        return req;
    };
    this.UpdateCricketer = function(cricketer) {
        var req = $http.put("v1/Cricketer/PutCricketer", cricketer);
        return req;
    };
  
    this.CricketerOdiStatistic = function(cricketerDetailId) {
        var req = $http.get("v1/Cricketer/cricketerdetail/OdiStatistic/" + cricketerDetailId);
        return req;
    };
    this.CricketerTestStattistic = function(cricketerId) {
        var req = $http.get("v1/Cricketer/cricketerdetail/TestStatistics/" + cricketerId);
        return req;
    };
});