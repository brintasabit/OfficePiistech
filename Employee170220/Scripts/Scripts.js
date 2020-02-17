$(document).ready(function () {
    $('#addEmployee').click(function () {
		AddEmployee();
	});
	$('#home').click(function () {
		Home();
	});
	$('#lnkdashboard').click(function () {
		Dashboard();
    });
	$('#employee').click(function () {
		Employee();
	});


});


var AddEmployee = function () {
    alert('fire');
	$('#main').load('/Employee/AddOrEdit');
}
var Home = function () {
	$('#main').load('/Employee/Dashboard');
}
var Dashboard = function () {
	$('#main').load('/Employee/Dashboard');
}
var Employee = function () {
	$('#main').load('/Employee/Employee');
}


