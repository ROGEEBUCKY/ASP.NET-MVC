$(document).ready(function () {
    $("#addEmployeebtn").click(function () {
        $.ajax({
            type: "Get", //Method type
            url: "/Admin/AddNewEmployee", //url to load partial view
            contents: "",
            success: function (response) {
                $("#adminmodalbody").html(response);
                var b = "<button id='openmodal' hidden data-bs-toggle='modal' data-bs-target='#adminmodal'>a</button>";
                $("#adminmodal").append(b);
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
    $("#adddutybtn").click(function () {
        $.ajax({
            type: "Get", //Method type
            url: "/Admin/AddNewDuty", //url to load partial view
            contents: "",
            success: function (response) {
                $("#adminmodalbody").html(response);
                var b = "<button id='openmodal' hidden data-bs-toggle='modal' data-bs-target='#adminmodal'>a</button>";
                $("#adminmodal").append(b);
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
    $("#addrosterbtn").click(function () {
        $.ajax({
            type: "Get", //Method type
            url: "/Admin/AddNewRoster", //url to load partial view
            contents: "",
            success: function (response) {
                $("#adminmodalbody").html(response);
                var b = "<button id='openmodal' hidden data-bs-toggle='modal' data-bs-target='#adminmodal'>a</button>";
                $("#adminmodal").append(b);
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