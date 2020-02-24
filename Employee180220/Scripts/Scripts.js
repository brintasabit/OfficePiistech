$(document).ready(function () {

	console.log('document ready main');
    $('#lnkdashboard').unbind().click(function () {
        console.log('%c dashboard fired', 'background: #222; color: #FF0000');
        Dashboard();
        //$(this).unbind();
    });
    $('#employee').unbind().click(function () {
        console.log('%c Employee fired', 'background: #222; color: #FF0000');
        Employee();
        //$(this).unbind();
    });
    $('#edit').unbind().click(function () {
        console.log('%c edit fired', 'background: #222; color: #FF0000');
        EditEmployee();
        //$(this).unbind();
	});
    $('#delete').unbind().click(function () {
        console.log('%c delete fired', 'background: #222; color: #FF0000');
        DeleteEmployee();
        //$(this).unbind();
	});
    //$('#button2').unbind().click(function () {
    //    alert('button2 clicked');
    //    AddEmployee();
    //    $(this).unbind();
    //});
    //$('#saveEmp').click(function () {
    //    alert('saveEmp clicked');
    //    AddOrEditEmployee();
    //    $(this).unbind();
    //});

});

//var AddOrEditEmployee = function () {
//	var requestData = {
//		EmployeeId: $('#EmployeeId').val(),
//		Name: $('#Name').val(),
//		Age: $('#Age').val(),
//		Office: $('#Office').val(),
//		Position: $('#Position').val(),
//		Salary: $('#Salary').val(),
//		IsCurrentEmployee: $('#IsCurrentEmployee').val(),
//		ImagePath: $('#ImagePath').val()
//	};
//	$.ajax({
//		url: '/Employee/AddOrEdit',
//		type: 'POST',
//		data: JSON.stringify(requestData),
//		dataType: 'json',
//		contentType: 'application/json; charset=utf-8',
//		error: function (xhr) {
//			alert('Error: ' + xhr.statusText);
//		},
//		success: function (result) {
//			alert('Success');
//		},
//		async: true,
//		processData: false
//	});
//}
var Dashboard = function () {
    
	$('#main').load('/Employee/Dashboard');
}
var Employee = function () {
    
	$('#main').load('/Employee/Employee');
}
var EditEmployee = function () {
    
	$('#main').load('/Employee/EditEmployee');
}
var DeleteEmployee = function () {
    
	$('#main').load('/Employee/DeleteEmployee');
}
//var AddEmployee = function () {
	
//	$('#main').load('/Employee/AddOrEdit');
//}

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
		//success: function (response) {
		//alert('Updated');
		//},
		//async: true,
		//processData: false
		success: function (response) {
            $("#addOrEdit").html(response);
			//$('ul.nav.nav-tabs a:eq(1)').html('Edit');
			//$('ul.nav.nav-tabs a:eq(1)').tab('show');
		}

	});
}

//function refreshTab(resetUrl) {
//	$.ajax({
//		type: "GET",
//		url: resetUrl,
//		success: function (result) {
//			alert('Refreshed!!');
//		},
//		async: true,
//		processData: false

//	});
//}