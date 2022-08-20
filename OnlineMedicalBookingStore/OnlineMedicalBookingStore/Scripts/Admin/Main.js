function OnSuccess() {
    Swal.fire({
        icon: 'success',
        title: 'Completed Successful',
        showConfirmButton: false,
        timer: 1500
    }).then(function () {
            var b = "<button id='close' hidden data-bs-dismiss='modal'>a</button>";
            $("#adminmodal").append(b);
            $("#close").click();
        });
}
function OnFailure() {
    swal.fire({
        title: "Problem",
        text: "Error Occured! Try Again",
        icon: "error",
        showConfirmButton: false,
        timer: 1500
    }).then(function () {
        var b = "<button id='close' hidden data-bs-dismiss='modal'>a</button>";
        $("#adminmodal").append(b);
        $("#close").click();
    });
}
