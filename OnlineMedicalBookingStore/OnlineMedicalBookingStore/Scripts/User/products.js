$(document).ready(function () {
    $("#Aproducts").on("click", ".cart", function () {
        var btn = this;
        $.ajax({
            type: "Post",
            url: "/User/AddToCart",
            contents: "",
            data: { id: btn.id },
            success: function (response) {
                if (response == "true") {
                    Swal.fire({
                        icon: 'success',
                        title: 'Added to cart',
                        showConfirmButton: false,
                        timer: 1500
                    });
                }
                else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Already in Cart',
                        showConfirmButton: false,
                        timer: 2000
                    });
                }
            },
            failure: function (response) {
                alert(response.responseText)
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });


});