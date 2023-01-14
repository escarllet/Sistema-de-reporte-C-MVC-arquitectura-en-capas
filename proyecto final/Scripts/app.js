function getDepartamentos(myCallback) {
    $.ajax({
        type: "GET",
        url: '/Departamentos/GetDepartamento',
        dataType: "json",
        success: function (result) {
            $.each(result.data, function (key, item) {
                $('#')

            });
        }
    });
}