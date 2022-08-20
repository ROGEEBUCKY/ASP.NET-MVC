$(document).ready(function () {
    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            return this.optional(element) || regexp.test(value);
        },
        "please check your format"
    );

    $(".submit").click(function (e) {
        var form = $(this).parent("form");
        form.validate({
            rules: {
                upi: {
                    regex:/^[a-zA-Z0-9.\-_]{2,256}@[a-zA-Z]{2,64}$/,
                }
            }
        });
        e.preventDefault();
        if (form.valid()) {
            $.ajax({
                type: "Get", //Method type
                url: "/User/PlaceOrder", //url to load partial view
                contents: "",
                success: function (response) {
                    $("#usermodalbody").html(response);
                    var b = "<button id='openmodal' hidden data-bs-toggle='modal' data-bs-target='#usermodal'>a</button>";
                    $("#usermodal").append(b);
                    $("#openmodal").click();
                },
                failure: function (response) {
                    alert(response.responseText)
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });
        }
    });

    $("#usermodal").on("hide.bs.modal", function () {
        $.ajax({
            type: "Get", 
            url: "/User/Home",
            contents: "",
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