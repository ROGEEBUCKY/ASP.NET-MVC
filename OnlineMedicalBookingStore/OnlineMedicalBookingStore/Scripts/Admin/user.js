
$(document).ready(function () {

    var userTable = $('#usertable').DataTable({
        scrollX: true,
        scrollCollapse: false,
        paging: true,
        processing: true,
        autoWidth: false,
        ajax: {
            "url": "/Admin/GetAllUsers",
            "type": "GET",
            "dataSrc": "",
        },
        columns: [
            {},
            { "data": "Name" },
            { "data": "Email" },
            { "data": "PhoneNumber" },
            { "data": "Address" },
            { "data": "CreatedDate" },
            { "data": "Id" }
        ],
        columnDefs: [
          {
                render: function (data, type, row) {
                    return moment(data).format("YYYY-MM-DD");
                },
                targets: 5
            },
            {
                render: function (data, type, row) {
                    return data + 0;
                },
                targets: 0
            },
            {
                render: function (data, type, row) {
                    return "<button id='" + data + "' class='btn btn-danger delete'>Delete</button>";
                },
                targets: 6
            }
        ],
        order: [[1, 'asc']],
    });
    userTable.on('order.dt search.dt', function () {
        let i = 1;

        userTable.cells(null, 0, { search: 'applied', order: 'applied' }).every(function (cell) {
            this.data(i++);
        });
    }).draw();

    $("#usertable").on("click", ".delete", function () {
        var btn = this;
        $.ajax({
            method: "POST", //Method type
            url: "/Admin/DeleteUser", //url to load partial view
            contents: "",
            data: { id: btn.id }, //send student id
            success: function (response) {
                if (response) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Deleted Successful',
                        showConfirmButton: false,
                        timer: 1500
                    });
                }
                else {
                    Swal.fire({
                        icon: 'erroe',
                        title: 'Some error Occured',
                        showConfirmButton: false,
                        timer: 1500
                    });
                }
                userTable.ajax.reload();
            },
            failure: function (response) {
                alert(response.responseText)
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });

    //$("#usertable").on("click", ".unblock", function () {
    //    var btn = this;
    //    $.ajax({
    //        type: "POST", //Method type
    //        url: "/Admin/UnBlockUser", //url to load partial view
    //        contents: "",
    //        data: { id: btn.id }, //send student id
    //        success: function (response) {
    //            $("#renderpage").html(response);
    //        },
    //        failure: function (response) {
    //            alert(response.responseText)
    //        },
    //        error: function (response) {
    //            alert(response.responseText);
    //        }
    //    });
    //});

    //$("#addEmployeebtn").click(function () {
    //    $.ajax({
    //        type: "Get", //Method type
    //        url: "/Admin/AddNewEmployee", //url to load partial view
    //        contents: "",
    //        success: function (response) {
    //            debugger;
    //            $("#adminmodalbody").html(response);
    //            var b = "<button id='openmodal' hidden data-bs-toggle='modal' data-bs-target='#adminmodal'>a</button>";
    //            $("#adminmodal").append(b);
    //            $("#openmodal").click();
    //        },
    //        failure: function (response) {
    //            alert(response.responseText)
    //        },
    //        error: function (response) {
    //            alert(response.responseText);
    //        }
    //    });
    //});
});