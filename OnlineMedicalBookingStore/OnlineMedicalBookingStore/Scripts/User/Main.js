function OnSuccess() {
    Swal.fire({
        icon: 'success',
        title: 'Completed Successful',
        showConfirmButton: false,
        timer: 1500
    }).then(function () {
        var b = "<button id='close' hidden data-bs-dismiss='modal'>a</button>";
        $("#usermodal").append(b);
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
        $("#usermodal").append(b);
        $("#close").click();
    });
}
$(document).ready(function () {
    $("#cart").prepend('<i class="fa-solid fa-cart-shopping me-1"></i>');



    $("#searchProducts").on("keyup", function () {
        var search = $(this).val();
        $.ajax({
            url: "/User/SearchProducts",
            data: { val: search },
            type: "post",
            success: function (response) {
                $("#renderarea").html(response);
            }
        });
    });
});