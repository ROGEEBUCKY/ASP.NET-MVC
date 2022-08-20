$(document).ready(function () {
});

function OnSuccess(data) {
    Swal.fire({
        icon: 'success',
        title: 'Completed Successful',
        showConfirmButton: false,
        timer: 1500
    }).
   then(function () {
        var b = "<button id='close' hidden data-bs-dismiss='modal'>a</button>";
        $("#adminmodal").append(b);
        $("#close").click();
    });
}
function OnFailure() {
    swal.fire({
        title: "Problem",
        text: data.message,
        icon: "error",
        allowoutsideclick: false,
        allowescapekey: false
    });
}


