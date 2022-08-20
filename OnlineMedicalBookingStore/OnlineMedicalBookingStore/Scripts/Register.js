$(document).ready(function () {
    var message = "@ViewBag.message";
    if (message != '') {
        swal.fire({
            title: "Registered Successfully!!",
            text: "please Login to continue",
            icon: 'success',
            showConfirmButton: false,
            timer: 2000
        }).then(function () {
            window.location = "/Login";
        });
    }
    $("#regbtn").click(function () {
        if ($("#regForm").valid() == false) {
            $.toast({
                heading: 'Error',
                text: 'Invaid Inputs',
                showHideTransition: 'slide',
                icon: 'error',
                position: 'top-center',
            })
        }
    });
});