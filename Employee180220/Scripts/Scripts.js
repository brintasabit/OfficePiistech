$(document).ready(function () {
    $('#lnkdashboard').unbind().click(function () {
		Dashboard();
    });
    $('#employee').click(function() {
        Employee();
    });
    $('#edit').unbind().click(function () {
		EditEmployee();
	});
    $('#delete').unbind().click(function () {
		DeleteEmployee();
	});
    //$('#button1').click(function () {
    //    //AddEmployee();
    //    alert('fire!');
    //});
    $('#saveEmp').click(function () {
        AddOrEditEmployee();
        $(this).unbind();
    });

});

var AddOrEditEmployee = function () {
	var requestData = {
		EmployeeId: $('#EmployeeId').val(),
		Name: $('#Name').val(),
		Age: $('#Age').val(),
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
var Dashboard = function () {
	$('#main').load('/Employee/Dashboard');
}
var Employee = function() {
	$('#main').load('/Employee/Employee');
}
var EditEmployee = function () {
	$('#main').load('/Employee/EditEmployee');
}
var DeleteEmployee = function () {
	$('#main').load('/Employee/DeleteEmployee');
}
var AddEmployee = function () {
	$('#main').load('/Employee/AddOrEdit');
}

function Delete(url) {
	if (confirm('Are you sure to delete this record ?') == true) {
		$.ajax({
			type: 'POST',
			url: url,
			success: function (result) {
                alert('Deleted!');
                $('#main').load('/employee/deleteemployee');
			},
			async: true,
			processData: false

		});

	}
}

function Edit(url) {
	$.ajax({
		type: 'GET',
		url: url,
		success: function (response) {
		alert('Updated');
		},
		async: true,
		processData: false

	});
}

function refreshTab(resetUrl) {
	$.ajax({
		type: "GET",
		url: resetUrl,
		success: function (result) {
			alert('Refreshed!!');
		},
		async: true,
		processData: false

	});
}