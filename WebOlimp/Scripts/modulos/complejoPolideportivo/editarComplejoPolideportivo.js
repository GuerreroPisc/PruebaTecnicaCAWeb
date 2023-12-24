
$(document).ready(function () {
    $('#selSedes').selectpicker();
    ListarMaestro();
    $("#btnRegistrar").click(function () {
        loadingButton("btnRegistrar", "Guardando...");
        Registrar();
    });

    $("#btnCancelar").click(function () {
        Cancelar();
    });


    Detalle();
});

function ListarMaestro() {
    cargandoSelect('selSedes');
    $.ajax({
        url: rutaPrincipal + 'Maestro/GetListadoMaestro',
        type: 'GET',
        success: function (data, textStatus, xhr) {
            console.log(data)
            if (xhr.status == 200) {
                if (data.data != null) {
                    fillSelectPickerWithoutDefault('selSedes', data.data, 'id_sede',
                        'nombre_sede', 'Seleccione sede');

                    if (data.data.length === 1) {
                        $(`#selSedes`).attr('disabled', 'disabled');
                        restartSelectpicker('selSedes', data.data[0].nombre_sede, { liveSearch: true, size: 7 });
                    } else {
                        $(`#selSedes`).removeAttr('disabled', 'disabled');
                        restartSelectpicker('selSedes', '0', { liveSearch: true, size: 7 });
                    }

                }
            }
        },
        error: function (xhr, textStatus) {
            var mensajeError = "Error al obtener los datos del combo ComplejoPolideportivos.";
            if (xhr.responseJSON != "undefined" && xhr.responseJSON != null) {
                mensajeError = xhr.responseJSON.Message;
            }
            var colormensaje = 'red';
            if (xhr.status == 404) {
                colormensaje = 'orange';
            }
            verMensaje('', mensajeError, colormensaje,
                'Ok', function () { }, function () { });
        }

    });
}

function Registrar() {
    let content_button = `<i class="mdi mdi-content-save" aria-hidden="true"></i> Guardar`;
    try {
        showLoader();
        let nombre_CP = $("#txtNombreComplejoPolideportivo").val();
        let sede = $("#selSedes").val();
        let estado = $("#selEstado").val();

        if (nombre_CP == null || nombre_CP.trim() == '') {
            resetLoadingButton("btnRegistrar", content_button);
            hideLoader();
            verMensaje('', "El nombre del complejo polideportivo es obligatorio", 'orange',
                'Ok', function () { }, function () { });
            return false;
        }

        if (sede == null || sede <= 0) {
            resetLoadingButton("btnRegistrar", content_button);
            hideLoader();
            verMensaje('', "Debe ingresar una sede", 'orange',
                'Ok', function () { }, function () { });
            return false;
        }

        if (estado == null || estado <= -1) {
            resetLoadingButton("btnRegistrar", content_button);
            hideLoader();
            verMensaje('', "Selecciona un estado", 'orange',
                'Ok', function () { }, function () { });
            return false;
        } else {
            if (!(estado == 1 || estado == 0)) {
                resetLoadingButton("btnRegistrar", content_button);
                hideLoader();
                verMensaje('', "Selecciona un estado válido", 'orange',
                    'Ok', function () { }, function () { });
                return false;
            }
        }

        var datos = {
            estado: estado == 1 ? true : false,
            nombre_complejo_poli: nombre_CP,
            id_sede: sede
        };

        $.ajax({
            url: rutaPrincipal + `ComplejoPolideportivo/PutEditarComplejoPolideportivo/${_id}`,
            method: 'PUT',
            data: datos,
            success: function (data, textStatus, xhr) {
                hideLoader();
                if (xhr.status == 200) {
                    verMensaje('', "Se ha editado correctamente la sede", 'green',
                        'Ok', function () { location.href = `${rutaPrincipal}ComplejoPolideportivo/ListaComplejoPolideportivo` });

                } else {
                    var mensajeSuccessError = "No se pudo editar la sede.";

                    if (xhr.responseJSON != "undefined" && xhr.responseJSON != null) {
                        mensajeError = xhr.responseJSON.Message.replaceAll("||", " ");
                    } else {
                        if (xhr.status == 400) {
                            mensajeError = "Debe agregar los datos obligatorios.";
                        }
                    }
                    verMensaje('', mensajeSuccessError, 'orange',
                        'Ok', function () { }, function () { });
                }
                resetLoadingButton("btnRegistrar", content_button);
            },
            error: function (xhr, textStatus) {
                hideLoader();
                var mensajeError = "Error al editar la sede.";
                if (xhr.responseJSON != "undefined" && xhr.responseJSON != null) {
                    mensajeError = xhr.responseJSON.Message.replaceAll("||", " ");
                } else {
                    if (xhr.status == 400) {
                        mensajeError = "Debe agregar los datos obligatorios.";
                    }
                }
                verMensaje('', mensajeError, 'red',
                    'Ok', function () { }, function () { });
                resetLoadingButton("btnRegistrar", content_button);
            }

        });
    } catch (e) {
        hideLoader();
        resetLoadingButton("btnRegistrar", content_button);
        verMensaje('', "Error de la página al guardar los datos de la sede", 'red',
            'Ok', function () { }, function () { });
        console.error('Error registrar la sede', e);
    }
}


function Cancelar() {
    verMensaje('', "¿Deseas cancelar la edición de la sede?", 'orange',
        'Si', function () { location.href = `${rutaPrincipal}ComplejoPolideportivo/ListaComplejoPolideportivo` }, function () { }, 'No');
}


function Detalle() {
    try {
        showLoader();
        $.ajax({
            url: rutaPrincipal + `ComplejoPolideportivo/GetDetalleComplejoPolideportivo/${_id}`,
            method: 'GET',
            success: function (data, textStatus, xhr) {
                hideLoader();
                console.log(data);
                $("#txtNombreComplejoPolideportivo").val(data.data.data.nombre_complejo_poli);
                $("#selSedes").val(data.data.data.id_sede).trigger('change');
                $("#selEstado").val(data.data.data.estado === true ? 1 : 0);
            },
            error: function (xhr, textStatus) {
                hideLoader();

                verMensaje('', "No se pudo recuperar los datos de la sede", 'orange',
                    'Ok', function () { location.href = `${rutaPrincipal}ComplejoPolideportivo/ListaComplejoPolideportivo` }, function () { location.href = `${rutaPrincipal}ComplejoPolideportivo/ListaComplejoPolideportivo` });
            }

        });
    } catch (e) {
        hideLoader();

        verMensaje('', "No se pudo recuperar los datos de la sede", 'orange',
            'Ok', function () { location.href = `${rutaPrincipal}ComplejoPolideportivo/ListaComplejoPolideportivo` }, function () { location.href = `${rutaPrincipal}ComplejoPolideportivo/ListaComplejoPolideportivo` });
    }
}

