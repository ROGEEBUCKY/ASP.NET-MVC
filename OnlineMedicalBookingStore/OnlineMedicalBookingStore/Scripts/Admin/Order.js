$(document).ready(function () {
    var ordersTable = $('#ordertable').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'print'
        ],
        scrollX: true,
        scrollCollapse: false,
        paging: true,
        processing: true,
        autoWidth: false,
        ajax: {
            "url": "/Admin/GetAllOrders",
            "type": "GET",
            "dataSrc": "",
        },
        columns: [
            {},
            { "data": "Id" },
            { "data": "UserId" },
            { "data": "Amount" },
            { "data": "Created" },
            { "data": "Address" },
            { "data": "City" },
            { "data": "State" },
            { "data": "ZipCode" },
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
                render: $.fn.dataTable.render.number(',', '.', 2, '&#8377; '),
                targets: 3
            },
            {
                render: function (data, type, row) {
                    return "<button id='" + data + "' class='btn btn-info view'>view</button>";
                },
                targets: 9
            }
        ],
        order: [[4, 'asc']],
    });
    ordersTable.on('order.dt search.dt', function () {
        let i = 1;

        ordersTable.cells(null, 0, { search: 'applied', order: 'applied' }).every(function (cell) {
            this.data(i++);
        });
    }).draw();



    $("#ordertable").on("click", ".view", function () {
        var btn = this;
        $.ajax({
            type: "Get", //Method type
            url: "/Admin/OrderDetails", //url to load partial view
            data: {id : btn.id},
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