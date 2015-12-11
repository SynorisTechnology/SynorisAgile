var myApp = angular.module('AgileApp', []);
myApp.controller('ContactController', function ($http, $scope) {

    $("#loading").show();

    $scope.AddConact1 = function () {
        $("#loading").show();
        var $projectForm = $("#Contact-form").validate({
            rules: {
                CompanyName: { required: true }
            },
            message: {
                CompanyName: { required: "Please enter Company name." }
            },
            submitHandler: function (form) {
                $(form).ajaxSubmit({
                    success: function () {
                        $http({
                            method: 'Post',
                            url: basePath + '/Agile/Contact/SaveContact',
                            data: JSON.stringify($scope.Contact)
                        })
                        .success(function (result) {
                            $("#loading").hide();

                            if (result == "1") {
                                $("#MessageArea").show();
                                $scope.MessageTitle = "Success";
                                $scope.MessageClass = "alert-success";
                                $scope.Message = "Project Record inserted successfully.";

                                //$("#datepicker").val('');
                                //$("#datepickerEnd").val('');
                                //$("#datepickerDeadLine").val('');
                                //$("#txtPName").val('');
                                //$("#txtPDesc").val('');
                                //$("#txtBitUrl").val('');
                                //$("#txtDemoUrl").val('');
                                //$("#txtProdUrl").val('');
                                //$("#txtSvn").val('');
                                //$("#txtClntInfo").val('');
                                //$("#txtPwd").val('');
                                //$("#txtTargeted").val('');
                                //$("#txtBudget").val('');
                                //$("#txtSvn").val('');
                                //$("#txtTechnicalDetail").val('');
                            }
                            else {
                                $("#loading").hide();
                                $("#MessageArea").show();
                                $scope.MessageTitle = "Error";
                                $scope.MessageClass = "alert-danger";
                                $scope.Message = "Project Record can't inserted.";
                            }


                            console.log(result);
                        })
                        .error(function (err) {
                            $("#loading").hide();
                            $("#MessageArea").show();
                            $scope.MessageTitle = "Error";
                            $scope.MessageClass = "alert-danger";
                            $scope.Message = "Project Record can't loaded.";
                            console.log(err);
                        })
                    }
                })
            },
            // Do not change code below.
            errorPlacement: function (error, element) {
                $("#loading").hide();

                error.insertAfter(element.parent());
            }

        })
    }


    $scope.AddConact = function () {
        $("#loading").show();
        $http({
            method: 'Post',
            url: basePath + '/Agile/Contact/SaveContact',
            data: JSON.stringify($scope.Contact)
        })
        .success(function (result) {
            $scope.project = result;
            $("#loading").hide();
            console.log(result);
        })
        .error(function (err) {
            $("#loading").hide();

            console.log(err);
        })
    }

    $scope.ShowContactById = function () {
        $("#loading").show();
        var id = $('#hdnfilename').val();
        $http({
            method: 'Get',
            url: basePath + '/Agile/Contact/ShowContactById',
            params: { id: id }
        })
        .success(function (result) {
            $scope.Contact = result;
            $("#loading").hide();
            console.log(result);

            $http({
                method: 'Get',
                url: basePath + '/Agile/Project/GetAllProjectList',
                params: { }
            }).success(function (result) {
                $scope.ProjectList = result;

            })
        })
        .error(function (err) {
            $("#loading").hide();
            console.log(err);
        })
    }


    $scope.GetContact = function () {
        $http({
            method: 'Get',
            url: basePath + '/Agile/Contact/GetContactList'
        })
        .success(function (result) {
            $scope.ContactList = result;
            console.log(result);
            $("#loading").hide();
        })
        .error(function (err) {
            $("#loading").hide();
            console.log(err);
        })
    }
    $scope.GetProjectDashboard = function () {
        $http({
            method: 'Get',
            url: basePath + '/Agile/Project/GetProjectList'
        })
        .success(function (result) {
            $scope.ProjectList = result;
            console.log(result);
            if (result.StartDate != null) {
                var ddate = new Date(parseInt(result.StartDate.substr(6)));// value.DueDate;
                var mth = ddate.getMonth() + 1;
                if (mth < 10) mth = "0" + mth;
                $scope.StartDate = ddate.getDate() + "/" + mth + "/" + ddate.getFullYear();
            }
            if (result.EndDate != null) {
                var ddate = new Date(parseInt(result.EndDate.substr(6)));// value.DueDate;
                var mth = ddate.getMonth() + 1;
                if (mth < 10) mth = "0" + mth;
                $scope.EndDate = ddate.getDate() + "/" + mth + "/" + ddate.getFullYear();
            }
            $("#loading").hide();
        })
        .error(function (err) {
            $("#loading").hide();
            console.log(err);
        })
    }
    $scope.UpdateContact = function () {
        $("#loading").show();       
        var pid = $('#hdnfilename').val();       
        var $projectForm = $("#contact-form").validate({
            rules: {
                txtCompanyName: { required: true }
            },
            message: {
                txtCompanyName: { required: "Please enter project title." }
            },

            submitHandler: function (form) {
                $(form).ajaxSubmit({
                    success: function () {
                        $http({
                            method: 'Post',
                            url: basePath + '/Agile/Contact/UpdateContactById',
                            data: JSON.stringify($scope.Contact, pid)
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