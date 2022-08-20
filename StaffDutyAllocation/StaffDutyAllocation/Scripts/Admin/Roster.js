
    var rostertable = $('#rostertable').DataTable({
        scrollX: true,
        scrollCollapse: false,
        paging: true,
        processing: true,
        autoWidth: false,
        ajax: {
            "url": "/Admin/GetRosters",
            "type": "Get",
            "dataSrc": ""
        },
        columns: [
            {},
            { "data": "Name" },
            { "data": "CreatedDate" },
            { "data": "NumberOfDuties" },
            { "data": "Id" }
        ],
        columnDefs: [
            {
                render: function (data, type, row) {
                    return moment(data).format("YYYY-MM-DD");
                },
                targets: 2
            },
            {
                render: function (data, type, row) {
                    return data + 0;
                },
                targets: 0
            },
            {
                render: function (data, type, row) {

                    return "<div class='btn-group'>" +
                        "<button id='" + data + "'   class='btn btn-info adddutiesbtn'>Add/Update Duties</button>";

                },
                targets: 4
            }
        ],
        order: [[1, 'asc']],
    });
    rostertable.on('order.dt search.dt', function () {
        let i = 1;

        rostertable.cells(null, 0, { search: 'applied', order: 'applied' }).every(function (cell) {
            this.data(i++);
        });
    }).draw();



    $("#rostertable").on("click", ".adddutiesbtn", function () {
        var btn = this;
        $.ajax({
            type: "POST", //Method type
            url: "/Admin/AddDuties", //url to load partial view
            contents: "",
            data: { id: btn.id }, //send student id
            success: function (response) {
                $("#adminmodalbody").html(response);
                var b = "<button id='openmodal' hidden data-bs-toggle='modal' data-bs-target='#adminmodal'>a</button>";
                $("#adminmodal").append(b);
                $("#openmodal").click();
                $("#openmodal").remove();
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
                $("#openmodal").remove();

            },
            failure: function (response) {
                alert(response.responseText)
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    })
