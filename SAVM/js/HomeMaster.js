
$("#btnCerrarSesion").click(function () {
    $.ajax({
        type: "POST",
        url: "Login.aspx/CerrarSesion",
        data: {},
        contentType: "application/json",
        success: function (respuesta) {
            if (respuesta.d == true)
            {
                document.location.href = "Login.aspx"
            }
        }


    });
});
