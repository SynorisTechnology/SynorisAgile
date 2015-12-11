
var myApp = angular.module('AdminApp', []);
//Defining a Controller 
myApp.controller('CreatePropertyController', function ($scope, $http, $filter) {
    // Get all Property list for dropdownlist
    $scope.Error = "";
    var orderBy = $filter('orderBy');

    $scope.AddTowerInit = function () {
    }

    $scope.AddTowerSave = function () {
        var $checkoutForm = $('#checkout-form').validate({
            // Rules for form validation
            rules: {
                TowerName: {
                    required: true
                },
                TowerNo: {
                    required: true
                },
                PropertyPrefix: {
                    required: true
                },
                Block: {
                    required: true
                },
                PropertyName: {
                    required: true,
                    minlength: 2,
                    maxlength: 100
                },
                CompanyName: {
                    required: true
                },
                Location: {
                    required: true
                },
                AuthoritySign: {
                    required: true
                },
                PropertyAddress: {
                    required: true,
                    minlength: 10,
                    maxlength: 256
                },
                OfficeAddress: {
                    required: true,
                    minlength: 10,
                    maxlength: 256
                },
                Jurisdiction: {
                    required: true
                },
                PossessionDate: {
                    required: true
                },
            },

            // Messages for form validation
            messages: {
                TowerName: {
                    required: "Please enter tower name."
                },
                TowerNo: {
                    required: "Tower no can't blank."
                },
                PropertyPrefix: {
                    required: "Property prefix name is required for naming of property doc"
                },
                Block: {
                    required: "Please enter block name"
                },
                PropertyName: {
                    required: "Enter property name",
                    minlength: "Property can't not less then 2 chars",
                    maxlength: "Property can't not more then 100 chars",
                },
                CompanyName: {
                    required: "Enter Company name of this property"
                },
                Location: {
                    required: "Enter location of property tower"
                },
                AuthoritySign: {
                    required: "Enter name of authorized person of property"
                },
                PropertyAddress: {
                    required: "Enter property full address",
                    minlength: "Property can't not less then 10 chars",
                    maxlength: "Property can't not more then 256 chars",
                },
                OfficeAddress: {
                    required: "Enter Registered Office address of property",
                    minlength: "Property can't not less then 10 chars",
                    maxlength: "Property can't not more then 256 chars",
                },
                Jurisdiction: {
                    required: "Enter Jurisdiction details"
                },
                PossessionDate: {
                    required: "Enter Possession Date of property"
                },
            },

            // Ajax form submition
            submitHandler: function (form) {
                $(form).ajaxSubmit({
                    success: function () {

                        $http({
                            method: 'POST',
                            url: '/Admin/CreateProperty/SaveTower',
                            data: JSON.stringify($scope.tower),
                            headers: { 'Content-Type': 'application/JSON' }
                        }).success(function (data) {
                            $scope.status = "The Property Saved Successfully!!!";
                            alert("Tower has been saved successfully");
                        }).error(function (error) {
                            //Showing error message
                            $scope.status = 'Unable to save property: ' + error.message;
                        });
                    }
                });
            },

            // Do not change code below.
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            }
        });
    }

})