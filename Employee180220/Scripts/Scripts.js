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
    $('#saveEmp').click(function () {
        AddOrEditEmployee();
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
var AddOrEditEmployee = function() {
	var requestData = {
		EmployeeId: $('#EmployeeId').val(),
        Name: $('#Name').val(),
        Age:$('#Age').val(),
		Office: $('#Office').val(),
		Position: $('#Position').val(),
        Salary: $('#Salary').val(),
        IsCurrentEmployee: $('#IsCurrentEmployee').val(),
		ImagePath: $('#ImagePath').val()
    };
    $.ajax({
	    url: '/Employee/AddOrEdit',
	    type: 'POST',
	    data: JSON.stringify(requestData),
	    dataType: 'json',
	    contentType: 'application/json; charset=utf-8',
	    error: function (xhr) {
		    alert('Error: ' + xhr.statusText);
	    },
	    success: function (result) {
		    alert('Success');
	    },
	    async: true,
	    processData: false
	});
}