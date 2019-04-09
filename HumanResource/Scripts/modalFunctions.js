

$('#btnBorrar').click(function () {


    Lobibox.confirm({
        title: 'Atención',
        msg: "¿Esta seguro que desea eliminar?",
        callback: function ($this, type, ev) {
            if (type === 'yes') {
                Delete();
            };
        }

    });
});

//Reinicio los modal
$('.modal').on('hidden.bs.modal', function (e) {
    $(".modal-body input").val(""),
        $(this).removeData('bs.modal');
    $(".form-check-input").prop('checked', false);
    $("form").validate().resetForm();
});

function habilitaBotones(boHabilita) {
    if (boHabilita) {
        $('#btnEditar').removeAttr("disabled");
        $('#btnBorrar').removeAttr("disabled");
    }
    else {
        $('#btnEditar').attr("disabled", true);
        $('#btnBorrar').attr("disabled", true);
    }

}