
$(document).ready(function () {

    var employeetable = $('#usertable').DataTable({
        scrollX: true,
        scrollCollapse: false,
        paging: true,
        processing: true,
        autoWidth: false,
        ajax: {
            "url": "/Admin/GetEmployee",
            "type": "GET",
            "dataSrc": "",
        },
        columns: [
            {},
            { "data": "FirstName" },
            { "data": "LoginId" },
            { "data": "LoginPass" },
            { "data": "Email" },
            { "data": "MobileNumber" },
            { "data": "Gender" },
            { "data": "DateOfBirth" },
            { "data": "CreatedDate" },
            { "data": "Id" }
        ],
        columnDefs: [
            {
                render: function (data, type, row) {
                    return ""+row.FirstName+" "+row.LastName+"";
                },
                targets: 1
            },{
                render: function (data, type, row) {
                    return moment(data).format("YYYY-MM-DD");
                },
                targets: [7, 8]
            },
            {
                render: function (data, type, row) {
                    return data + 0;
                },
                targets: 0
            },
            {
                render: function (data, type, row) {
                    if (row.IsBlocked == "true")
                        return "<button id='"+data+"' class='btn btn-secondary unblock'>UnBlock</button>";

                    return "<button id='" + data +"' class='btn btn-danger block'>Block</button>";
                },
                targets: 9
            }
        ],
        order: [[1, 'asc']],
    });
    employeetable.on('order.dt search.dt', function () {
        let i = 1;

        employeetable.cells(null, 0, { search: 'applied', order: 'applied' }).every(function (cell) {
            this.data(i++);
        });
    }).draw();

    $("#usertable").on("click", ".block", function () {
        var btn = this;
        $.ajax({
            method: "POST", //Method type
            url: "/Admin/BlockEmployee", //url to load partial view
            contents: "",
            data: { id : btn.id }, //send student id
            success: function (response) {
                employeetable.ajax.reload();
            },
            failure: function (response) {
                alert(response.responseText)
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });

    $("#usertable").on("click", ".unblock", function () {
        var btn = this;
        $.ajax({
            type: "POST", //Method type
            url: "/Admin/UnBlockUser", //url to load partial view
            contents: "",
            data: { id: btn.id }, //send student id
            success: function (response) {
                $("#renderpage").html(response);
            },
            failure: function (response) {
                alert(response.responseText)
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });

    $("#addEmployeebtn").click(function () {
        $.ajax({
            type: "Get", //Method type
            url: "/Admin/AddNewEmployee", //url to load partial view
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
});