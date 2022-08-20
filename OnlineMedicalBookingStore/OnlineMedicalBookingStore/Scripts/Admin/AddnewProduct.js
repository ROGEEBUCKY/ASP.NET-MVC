$(document).ready(function () {
    $("#ExpiryDate").datepicker({ minDate: +30 });


    $("#RemarkName").select2({
        dropdownParent: $('#adminmodal .modal-content'),
        width: '200px',
        tags: true
    });
    $("#RemarkName").on("change", function () {
        var val = $(this).val();
        $.ajax({
            url: "Admin/AddRemark",
            method: "POST",
            data: { val: val }
        });
    });


    $("#Price").on("change", function () {
        var price = $(this).val();
        var discount = $("#Discount").val();
        if (discount <= 0) {
            $("#FinalAmount").val(price);
        }
        else {
            var fdiscount = Number(price) * (Number(discount) / 100);
            var fprice = Number(price) - fdiscount;
            $("#FinalAmount").val(fprice);
        }
    });
    $("#Discount").on("change", function () {

        var price = $("#Price").val();
        var discount = $(this).val();
        if (price <= 0) {
        }
        else {
            var fdiscount = Number(price) * (Number(discount) / 100);
            var fprice = Number(price) - fdiscount;
            $("#FinalAmount").val(fprice);
        }
    });
});
