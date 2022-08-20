$(document).ready(function () {


    $("#checkoutbtn").click(function () {
        var amount = 
        $.ajax({
            url: "/User/CheckOut",
            method: "Get",
            success: function (response) {
                $("#renderarea").html(response);
            }
        });
    });


    $("#cartarea").on("change", ".qty", function () {
        var opt = $(this).val();
        var cart = this;
        $.ajax({
            type: "Post",
            url: "/User/ChangeQuantity",
            contents: "",
            data: { id: cart.id,qty:opt },
            success: function (response) {
                $("#renderarea").html(response);
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