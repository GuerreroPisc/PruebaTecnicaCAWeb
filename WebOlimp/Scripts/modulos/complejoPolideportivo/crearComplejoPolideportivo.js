

$(document).ready(function () {

    $("#btnRegistrar").click(function () {
        loadingButton("btnRegistrar", "Guardando...");
        Registrar();
    });

    $("#btnCancelar").click(function () {
        Cancelar();
    });

    $('#selSedes').selectpicker();
    ListarMaestro();
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
    let content_button = `<i class="mdi mdi-content-save" aria-hidden="true"></i> Registrar`;
    try {
        showLoader();
        let nombre_poli = $("#txtNombrePoli").val();
        let sede = $("#selSedes").val();
        let estado = $("#selEstado").val();

        if (nombre_poli == null || nombre_poli.trim() == '') {
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
            id_sede: sede,
            nombre_complejo_poli: nombre_poli
        };
        console.log(datos);

        $.ajax({
            url: rutaPrincipal + `ComplejoPolideportivo/PostCrearComplejoPolideportivo`,
            method: 'POST',
            data: datos,
            success: function (data, textStatus, xhr) {
                hideLoader();
                if (xhr.status == 201) {
                    verMensaje('', "Se ha agregado correctamente la sede", 'green',
                        'Ok', function () { location.href = `${rutaPrincipal}ComplejoPolideportivo/ListaComplejoPolideportivo` }, function () { location.href = `${rutaPrincipal}ComplejoPolideportivo/ListaComplejoPolideportivo` });

                } else {
                    var mensajeSuccessError = "No se pudo agregar la sede.";

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
                var mensajeError = "Error al registrar la sede.";
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
    verMensaje('', "¿Deseas cancelar el registro de la sede?", 'orange',
        'Si', function () { location.href = `${rutaPrincipal}ComplejoPolideportivo/ListaComplejoPolideportivo` }, function () { }, 'No');
}

