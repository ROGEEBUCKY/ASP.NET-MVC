$(document).ready(function () {
    $("#fproduct").on("click", ".cart", function () {
        debugger;
        var btn = this;
        $.ajax({
            type: "Post",
            url: "/User/AddToCart",
            contents: "",
            data: { id: btn.id },
            success: function (response) {
                debugger;
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
                productsTable.ajax.reload();
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