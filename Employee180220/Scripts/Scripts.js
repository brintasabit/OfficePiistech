$(document).ready(function () {
	$('#lnkdashboard').click(function () {
		Dashboard();
    });
	$('#employee').click(function() {
		Employee();
    });
	$('#button').click(function () {
		AddEmployee();
	});
});

var Dashboard = function () {
	$('#main').load('/Employee/Dashboard');
}
var Employee = function() {
	$('#main').load('/employee/employee');
}
var AddEmployee = function () {
	$('#main').load('/employee/addoredit');
}
