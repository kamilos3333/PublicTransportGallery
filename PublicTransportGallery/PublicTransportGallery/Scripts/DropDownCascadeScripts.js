$(document).ready(function () {
    $("#ProducentId").change(function () {
        $.get("/Image/getModel", { id: $("#ProducentId").val() }, function (data) {
            $("#ModelId").empty();
            $.each(data, function (index, row) {
                $("#ModelId").append("<option value='" + row.ModelId + "'>" + row.NameModel + "</option>")
            });
        });
    })
});
$(document).ready(function () {
    $("#ProducentId").val('');
});
