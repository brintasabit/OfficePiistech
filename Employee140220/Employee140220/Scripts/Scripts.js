$(document).ready(function() {
	$('#lnkdashboard').click(function() {
		Dashboard();
    });

});

var Dashboard = function() {
    $('#main').load('/Employee/Dashboard');
    //$('#content2').load('/Employee/Dashboard');
    //$('#content3').load('/Employee/Dashboard');
}