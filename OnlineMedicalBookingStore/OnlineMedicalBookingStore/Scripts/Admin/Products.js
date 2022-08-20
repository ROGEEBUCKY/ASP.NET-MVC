
$(document).ready(function () {
    $("#date").datepicker();
    var productsTable = $('#productsTable').DataTable({
        scrollX: true,
        scrollCollapse: false,
        paging: true,
        processing: true,
        autoWidth: false,
        ajax: {
            "url": "/Admin/GetAllProducts",
            "type": "GET",
            "dataSrc": "",
        },
        columns: [
            {},
            { "data": "Image" },
            { "data": "Name" },
            { "data": "Price" },
            { "data": "Manufacturer" },
            { "data": "Stock" },
            { "data": "ExpiryDate" },
            { "data": "Discount" },
            { "data": "Id" }
        ],
        columnDefs: [
            {
                render: function (data, type, row) {
                    debugger;
                    var date = new Date();
                    if (moment(data) <= moment(date, "DD-MM-YYYY").add(30, 'days'))
                        return "<p class='text-danger'>" + moment(data).format("YYYY-MM-DD") + "</p>";
                    else {
                        return moment(data).format("YYYY-MM-DD");
                    }
                },
                targets: 6
            },
            {
                render: $.fn.dataTable.render.number(',', '.', 2, '&#8377; '),
                targets: 3
            },
            {
                render: function (data, type, row) {
                    return data + 0;
                },
                targets: 0
            },
            {
                render: function (data, type, row) {
                    return "<button class='btn btn-secondary Edit' id='" + data + "'>Edit</button><button id='" + data + "' class='btn btn-danger delete'>Delete</button>";

                },
                targets: 8
            },
            {
                render: function (data, type, row) {
                    return "<img src='" + data + "' class='img-thumbnail' width='50' height='50'/>";
                },
                targets: 1
            },
            {
                render: function (data, type, row) {
                    if (data <= 0) {
                        return "<p class='text-danger'>" + data + "</p>";
                    }
                    else {
                        return data;
                    }
                },
                targets: 5
            }
        ],
        order: [[1, 'asc']],
    });
    productsTable.on('order.dt search.dt', function () {
        let i = 1;

        productsTable.cells(null, 0, { search: 'applied', order: 'applied' }).every(function (cell) {
            this.data(i++);
        });
    }).draw();

    $("#productsTable").on("click", ".delete", function () {
        debugger;
        var btn = this;
        $.ajax({
            type: "Post",
            url: "/Admin/DeleteProduct",
            contents: "",
            data: { id: btn.id },
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


    $("#productsTable").on("click", ".Edit", function () {
        var btn = this;
        $.ajax({
            type: "Get", //Method type
            url: "/Admin/EditProduct", //url to load partial view
            contents: "",
            data: { id: btn.id },
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

$("#addProduct").click(function () {
    $.ajax({
        type: "Get", //Method type
        url: "/Admin/AddNewProduct", //url to load partial view
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