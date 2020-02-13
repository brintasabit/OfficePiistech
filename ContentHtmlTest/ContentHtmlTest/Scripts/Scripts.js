$(document).ready(function () {
		$('#lnkdashboard').click(function () {
			Dashboard();
        });
		$('#employee').click(function () {
			Employee();
        });
		$('#mainsection').click(function () {
			Mainsection();
		});
});
	var Dashboard= function() {
        $('#content').load('Home/Dashboard');
        $('#saveProfile').click(function () {
	        AddOrEditEmployee();
        });
}
	var Employee = function () {
		$('#content').load('Home/ViewAll');
}
var Mainsection = function () {
	$('#content').load('Home/ViewAll');
}
function ShowImagePreview(imageUploader, previewImage) {
	if (imageUploader.files && imageUploader.files[0]) {
		var reader = new FileReader();
		reader.onload = function (e) {
			$(previewImage).attr('src', e.target.result);
		}
		reader.readAsDataURL(imageUploader.files[0]);

	}
}
var AddOrEditEmployee = function () {
	var requestData = {
		EmployeeId: $('#EmployeeId').val(),
        First_Name: $('#First_Name').val(),
        Last_Name: $('#Last_Name').val(),
        Age: $('#Age').val(),
        Company: $('#Company').val(),
        Position: $('#Position').val(),
        Salary: $('#Salary').val(),
        Created_Date: $('#Created_Date').val(),
		ImagePath: $('#ImagePath').val()
	};
	$.ajax({
		url: '/Home/AddOrEdit',
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
//function refreshAddNewTab(resetUrl, showViewTab) {
//	$.ajax({
//		type: "GET",
//		url: resetUrl,
//		success: function (response) {
//            $("#fourthTab").html(response);
//			$('ul.nav.nav-tabs a:eq(1)').html("Add New");
//			if (showViewTab)
//				$('ul.nav.nav-tabs a:eq(0)').tab("show");
//		}

//	});
//}
	