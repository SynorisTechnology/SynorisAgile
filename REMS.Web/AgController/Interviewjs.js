var myApp = angular.module('AgileApp', []);
myApp.controller('InterviewController', function ($http, $scope) {

    $("#loading").show();

    $scope.AddInterviewInfo = function () {
        $("#loading").show();
        $scope.Interview.InterviewDate = $("#datepicker").val();
        $http({
            method: 'Post',
            url: basePath + '/Agile/Interview/AddInterviewInfo',
            data: JSON.stringify($scope.Interview)
        })
        .success(function (result) {
            $scope.Interview = result;
            $("#loading").hide();
            console.log(result);
        })
        .error(function (err) {
            $("#loading").hide();

            console.log(err);
        })
    }

    $scope.ShowInterviewById = function () {
        $("#loading").show();
        var id = $('#hdnfilename').val();
        $http({
            method: 'Get',
            url: basePath + '/Agile/Interview/ShowInterviewById',
            params: { id: id }
        })
        .success(function (result) {
            $scope.Interview = result;
            $("#loading").hide();
            console.log(result);          
        })
        .error(function (err) {
            $("#loading").hide();
            console.log(err);
        })
    }

    $scope.GetInterview = function () {       
        $http({
            method: 'Get',
            url: basePath + '/Agile/Interview/GetInterviewList'
        })
        .success(function (result) {
            $scope.InterviewList = result;
            console.log(result);
            $("#loading").hide();
        })
        .error(function (err) {
            $("#loading").hide();
            console.log(err);
        })
    }

    $scope.UpdateInterviewInfo = function () {
        $("#loading").show();
        var pid = $('#hdnfilename').val();
        var $projectForm = $("#Interview-form").validate({
            rules: {
                txtCandidateName: { required: true }
            },
            message: {
                txtCandidateName: { required: "Please enter project title." }
            },

            submitHandler: function (form) {
                $(form).ajaxSubmit({
                    success: function () {
                        $http({
                            method: 'Post',
                            url: basePath + '/Agile/Interview/UpdateInterviewById',
                            data: JSON.stringify($scope.Interview, pid)
                        })
                        .success(function (result) {
                            if (result == "1") {
                                $("#loading").hide();
                                $("#MessageArea").show();
                                $scope.MessageTitle = "Success";
                                $scope.MessageClass = "alert-success";
                                $scope.Message = "Project Record updated successfully.";
                            }
                            else {
                                $("#loading").hide();
                                $("#MessageArea").show();
                                $scope.MessageTitle = "Error";
                                $scope.MessageClass = "alert-danger";
                                $scope.Message = "Project Record can't updated.";
                            }
                            console.log(result);
                        })
                        .error(function (err) {
                            $("#loading").hide();
                            $("#MessageArea").show();
                            $scope.MessageTitle = "Error";
                            $scope.MessageClass = "alert-danger";
                            $scope.Message = "Project Record can't updated.";
                            $("#loading").hide();
                            console.log(err);
                        })
                    }
                })
            },
            // Do not change code below.
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
                $("#MessageArea").show();
                $scope.MessageTitle = "Error";
                $scope.MessageClass = "alert-danger";
                $scope.Message = "Project Record can't updated.";
                $("#loading").hide();

            }

        })
    }

    $("#loading").hide();

})