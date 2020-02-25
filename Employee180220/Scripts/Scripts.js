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
});


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