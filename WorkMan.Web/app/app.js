//Define an angular module for our app
// this is a dummy just to demonstrate the angularjs application concept 
var app = angular.module('empApp', ['ngRoute','ui.bootstrap'])
.constant('_', window._)
  // use in views, ng-repeat="x in _.range(3)"
  .run(function ($rootScope) {
     $rootScope._ = window._;
  });
	
 app.config(function($routeProvider) {
        $routeProvider
            // route for the home page
            .when('/', {
                templateUrl : 'partials/home.html',
                controller  : 'empCtl'
            })
            // route for the create new employee page
            .when('/Employee', {
                templateUrl : 'partials/newEmployee.html',
                controller  : 'empCtl'
            });
    });

app.controller('empCtl', function($scope, $http,$filter,$route,$routeParams) {
  empData = {}; // emplpoyee details object 
  $scope.Employees = {};
  $scope.updateClientDetails=function ()  {  
     $scope.message = "Record Updated successfully  "; // dummy message 
  }; 

  $scope.getEmployee =function (empNumer)  { 
	// dummy function to retreive employee details search by and dummy data 
  $scope.Employees = [{emp_number : "A0123BL", emp_ttle :"Mrkk", emp_surname :"Gangire", emp_firstname :"Yotamu",department : "IT" },
					  { emp_number: "A0198XL", emp_ttle: "Mr", emp_surname: "Jonhs", emp_firstname: "James", department: "IT" },
					  { emp_number: "A0198XL", emp_ttle: "Mr", emp_surname: "Gumbo", emp_firstname: "Kudzai", department: "HR" },
					  { emp_number: "A0198XL", emp_ttle: "Mr", emp_surname: "Gumbo", emp_firstname: "Peter", department: "Finance" },
					  { emp_number: "A0198XL", emp_ttle: "Mr", emp_surname: "Peter", emp_firstname: "Joseph", department: "Marketing" }];
	
	console.log($scope.Employees);
  };
   // insert new employee details into database here ,
  $scope.newEmployee = function() {	 
    	  // if successful, bind success message to message;
		  $scope.message = "Record Saved successfully "; // dummy message 
		  console.log($scope.message);
		
	};
});
