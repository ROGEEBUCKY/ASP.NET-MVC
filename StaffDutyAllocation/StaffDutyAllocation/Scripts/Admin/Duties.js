
$(document).ready(function () {

    var dutytable = $('#dutytable').DataTable({
        scrollX: true,
        scrollCollapse: false,
        paging: true,
        processing: true,
        autoWidth: false,
        ajax: {
            "url": "/Admin/GetDuties",
            "type": "Get",
            "dataSrc": ""
        },
        columns: [
            {},
            { "data": "Name" },
            { "data": "DutyTypeName" },
            { "data": "CategoryName" },
            { "data": "CreatedDate" },
            { "data": "UserName" },
            { "data": "Id" }
        ],
        columnDefs: [
            {
                render: function (data, type, row) {
                    return moment(data).format("YYYY-MM-DD");
                },
                targets: 4
            },
            {
                render: function (data, type, row) {
                    return data + 0;
                },
                targets: 0
            },
            {
                render: function (data, type, row) {
                    if (row.UserId == null)
                        return "<button id='" + data + "' class='btn btn-secondary'>UnAssigned</button>";

                    return "<button id='" + data + "' class='btn btn-success'>Assigned</button>";

                },
                targets: 6
            }
        ],
        order: [[1, 'asc']],
    });
    dutytable.on('order.dt search.dt', function () {
        let i = 1;

        dutytable.cells(null, 0, { search: 'applied', order: 'applied' }).every(function (cell) {
            this.data(i++);
        });
    }).draw();



    $("#adddutybtn").click(function () {
        $.ajax({
            type: "Get", //Method type
            url: "/Admin/AddNewDuty", //url to load partial view
            contents: "",
            success: function (response) {
                debugger;
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

    //$("#dutytable").on("click", ".unallocatebtn", function () {
    //    debugger;
    //$.ajax({
    //    type: "Post", //Method type
    //    url: "/Admin/AddNewDuty", //url to load partial view
    //    contents: "",
    //    success: function (response) {
    //        debugger;
    //        $("#adminmodalbody").html(response);
    //        var b = "<button id='openmodal' hidden data-bs-toggle='modal' data-bs-target='#adminmodal'>a</button>";
    //        $("#adminmodal").append(b);
    //        $("#openmodal").click();
    //    },
    //    failure: function (response) {
    //        alert(response.responseText)
    //    },
    //    error: function (response) {
    //        alert(response.responseText);
    //    }
    //});

    //});
});