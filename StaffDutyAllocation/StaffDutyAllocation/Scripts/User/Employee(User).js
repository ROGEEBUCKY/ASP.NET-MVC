
$(document).ready(function () {

    var employeetable = $('#employeetable').DataTable({
        scrollX: true,
        scrollCollapse: false,
        paging: true,
        processing: true,
        autoWidth: false,
        ajax: {
            "url": "/User/GetEmployees",
            "type": "GET",
            "dataSrc": "",
        },
        columns: [
            {},
            { "data": "FirstName" },
            { "data": "Email" },
            { "data": "MobileNumber" },
            { "data": "Gender" },
            { "data": "DateOfBirth" },
            { "data": "Id" }
        ],
        columnDefs: [
            {
                render: function (data, type, row) {
                    return "" + row.FirstName + " " + row.LastName + "";
                },
                targets: 1

            },
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

                    if (row.IsBlocked == "true")
                        return "<button id='" + data + "' class='btn btn-secondary'>Blocked</button>"

                    return "<button id='" + data + "' class='btn btn-danger block'>Block</button>"
                },
                targets: 6
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

    $("#employeetable").on("click", ".block", function () {
        var btn = this;
        $.ajax({
            type: "POST", //Method type
            url: "/User/BlockUser", //url to load partial view
            contents: "",
            data: { id: btn.id }, //send student id
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

    $("#print").click(function () {
        $("#payrolltable").print();
    });

    var payrollTable = $('#payrolltable').DataTable({
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
            "url": "/User/GetEmployees",
            "type": "GET",
            "dataSrc": "",
        },
        columns: [
            {},
            { "data": "Id" },
            { "data": "FirstName" },
            { "data": "Email" },
            { "data": "BasicSalary" },
            { "data": "BasicSalary" }
        ],
        columnDefs: [
            {
                render: function (data, type, row) {
                    return data + 0;
                },
                targets: 0
            },
            {
                render: $.fn.dataTable.render.number(',', '.', 2, '&#8377; '),

                targets: [4, 5]
            }
        ],
        order: [[1, 'asc']],
    });
    payrollTable.on('order.dt search.dt', function () {
        let i = 1;

        payrollTable.cells(null, 0, { search: 'applied', order: 'applied' }).every(function (cell) {
            this.data(i++);
        });
    }).draw();
    $($.fn.dataTable.tables(true)).DataTable()
        .columns.adjust();
});
