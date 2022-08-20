$(document).ready(function () {
    $("#editbtn").on("click", function () {
        debugger;   
            $.ajax({
                type: "Get", //Method type
                url: "/User/EditUser", //url to load partial view
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
    });
});