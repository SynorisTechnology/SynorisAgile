
var myApp = angular.module('PropertyApp', []);
//Defining a Controller 
myApp.controller('PropertyController', function ($scope, $http, $filter) {
    // Get all Property list for dropdownlist
    $scope.Error = "";
    var orderBy = $filter('orderBy');

    // Admin/CreateProperty/AddFlat
    $scope.AddFlatInit = function () {
        $http({
            method: 'Get',
            url: '/Admin/CreateProperty/getAllTower'
        }).success(function (data) {
            $scope.TowerList = data;
        })
    }
    $scope.GenerateFaltHtml = function () {
        $http({
            method: 'POST',
            url: '/Admin/CreateProperty/FlatHmtl',
            data: { TotalFlat: $("#FlatTotal").val() }
            //headers: { 'Content-Type': 'application/JSON' }
        }).success(function (data) {
            $("#FlatHtml").html(data);
        }).error(function (error) {
            //Showing error message
            $scope.status = 'Unable to Generate Flat: ' + error.message;
        });
    }
    $scope.GenerateTower = function () {
        var TotalFlat = $("#FlatTotal").val();
        var TotalFloor = $("#FloorNo").val();
        var TowerID = $("#TowerID").val();
        $http({
            method: 'POST',
            url: '/Admin/CreateProperty/GenerateTowerAddFloor',
            data: { TotalFloor: TotalFloor, TowerID: TowerID }
            //headers: { 'Content-Type': 'application/JSON' }
        }).success(function (data) {
            for (var j = 1; j <= TotalFlat; j++) {
                    // add flat
                    var FlatNo = $("#FlatNo" + j).val();
                    var PreIncrement = $("#PreIncrement" + j).is(":checked");
                    var div = "#panel" + j.toString();
                    var pclids = "";
                    $(div).find('input:checkbox')
                    .each(function () {
                        if ($(this).is(":checked")) {
                            pclids+=  $(this).val()+",";
                        }
                    }).promise().done(function () {
                        alert(pclids)
                        $http({
                            method: 'POST',
                            url: '/Admin/CreateProperty/GenerateTowerAddFlat',
                            data: { TotalFloor: TotalFloor, Flat: j, FlatNo: FlatNo, PreIncrement: PreIncrement, PLCIDs: pclids }
                            //headers: { 'Content-Type': 'application/JSON' }
                        }).success(function (data) {
                            // $("#FlatHtml").html(data);
                        }).error(function (error) {
                            //Showing error message
                            $scope.status = 'Unable to Generate Flat: ' + error.message;
                        });
                    });
                 
                }
        }).error(function (error) {
            //Showing error message
            $scope.status = 'Unable to Generate Flat: ' + error.message;
        });
      
      
    }
})