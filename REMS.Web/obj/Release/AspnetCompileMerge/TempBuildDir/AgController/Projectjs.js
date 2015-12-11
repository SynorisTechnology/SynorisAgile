var myApp = angular.module('AgileApp', []);
myApp.controller('AgileController', function ($http, $scope) {

    $("#loading").show();

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

    // Full Text Search.
    $scope.ShowProjectBySearch = function () {
        $("#loading").show();

        var searchText = $('#txtSearchBox').val();
        $http({
            method: 'Get',
            url: basePath + '/Agile/Project/ShowProjectBySearch',
            params: { searchText: searchText }
        }).success(function (result) {
            $scope.ProjectList = result;
            $("#loading").hide();

        })
        .error(function (err) {
            console.log(err);
            $("#loading").hide();

        })
    }

    $scope.AddResource = function () {
        $("#loading").show();

        var RName = $("#txtRName").val();
        var RContact = $("#txtRContact").val();
        var REmail = $("#txtREmail").val();
        var REmpCode = $("#txtEmpCode").val();
        $http({
            method: 'Post',
            url: basePath + '/Agile/Resource/SaveResource',
            params: { name: RName, contact: RContact, email: REmail, empCode: REmpCode }
        })
        .success(function (res) {
            $scope.result = res;
            console.log(res);
            alert("Resource is added successfully");
            $("#txtRName").val('');
            $("#txtRContact").val('');
            $("#txtREmail").val('');
            $("#txtEmpCode").val('');
            $("#loading").hide();

        })
        .error(function (err) {
            $scope.result = err;
            $("#loading").hide();

            console.log(err);
        })
    }
    $scope.GetResource = function () {
        $("#loading").show();

        //alert(basePath);
        $http({
            method: 'Get',
            url: basePath + '/Agile/Resource/GetResourceList'
        })
       .success(function (result) {
           $scope.resources = result;
           if (result.CrDate != null) {
               var ddate = new Date(parseInt(result.CrDate.substr(6)));// value.DueDate;
               var mth = ddate.getMonth() + 1;
               if (mth < 10) mth = "0" + mth;
               $scope.CrDate = ddate.getDate() + "/" + mth + "/" + ddate.getFullYear();
           }
           $("#loading").hide();

           console.log(result);
       })
       .error(function (err) {
           console.log(err);
           $("#loading").hide();

       })
    }
    $scope.EditProject = function (pid) {

        $("#loading").show();

        $http({
            method: 'Get',
            url: basePath + '/Agile/Project/EditProject?pid=' + pid
        })
        .success(function (result) {
            $scope.prodData = result;
            console.log(result);
            $("#loading").hide();

        })
        .error(function (err) {
            console.log(err);
            $("#loading").hide();

        })
    }

    $scope.AddProject = function () {
        $("#loading").show();

        var $projectForm = $("#project-form").validate({
            rules: {
                ProjectTitle: { required: true }

            },
            message: {
                ProjectTitle: { required: "Please enter project title." }
            },
            submitHandler: function (form) {
                $(form).ajaxSubmit({
                    success: function () {

                        $scope.project.StartDateSt = $("#datepicker").val();
                        $scope.project.EndDateSt = $("#datepickerEnd").val();
                        $scope.project.DeadLineSt = $("#datepickerDeadLine").val();
                        $http({
                            method: 'Post',
                            url: basePath + '/Agile/Project/SaveProject',
                            // params:{PName:PName,startDt:StartDate,endDt:EndDate,PDesc:PDesc,status:status,tracker:tracker,deadline:Deadline,biturl:BitUrl,svn:Svn,clientInfo:ClientInfo,pwd:Pwd,targeted:Targeted,budget:Budget}
                            data: JSON.stringify($scope.project)
                        })
                        .success(function (result) {
                            $("#loading").hide();

                            if (result == "1") {
                                $("#MessageArea").show();
                                $scope.MessageTitle = "Success";
                                $scope.MessageClass = "alert-success";
                                $scope.Message = "Project Record inserted successfully.";

                                $("#datepicker").val('');
                                $("#datepickerEnd").val('');
                                $("#datepickerDeadLine").val('');
                                $("#txtPName").val('');
                                $("#txtPDesc").val('');
                                $("#txtBitUrl").val('');
                                $("#txtDemoUrl").val('');
                                $("#txtProdUrl").val('');
                                $("#txtSvn").val('');
                                $("#txtClntInfo").val('');
                                $("#txtPwd").val('');
                                $("#txtTargeted").val('');
                                $("#txtBudget").val('');
                                $("#txtSvn").val('');
                                $("#txtTechnicalDetail").val('');
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

    $scope.ShowProjectById = function () {
        $("#loading").show();

        var id = $('#hdnfilename').val();
        $http({
            method: 'Get',
            url: basePath + '/Agile/Project/ShowProjectById',
            params: { id: id }
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

    $scope.UpdateProject = function () {
        $("#loading").show();
        var pid = $('#hdnfilename').val();
        var $projectForm = $("#project-form").validate({
            rules: {
                ProjectTitle: { required: true }
            },
            message: {
                ProjectTitle: { required: "Please enter project title." }
            },

            submitHandler: function (form) {
                $(form).ajaxSubmit({
                    success: function () {

                        $scope.project.StartDateSt = $("#datepicker").val();
                        $scope.project.EndDateSt = $("#datepickerEnd").val();
                        $scope.project.DeadLineSt = $("#datepickerDeadLine").val();
                        $http({
                            method: 'Post',
                            url: basePath + '/Agile/Project/UpdateProjectById',
                            data: JSON.stringify($scope.project, pid)
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

});