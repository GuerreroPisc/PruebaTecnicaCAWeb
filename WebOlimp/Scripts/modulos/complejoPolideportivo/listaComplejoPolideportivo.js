var _tblUsuario;
var cant_registros = 20;
var listadoZonas = [];
$(document).ready(function () {
    $('#btnLoading').hide();
    _tblUsuario = $("#TablaDatosComplejoPolideportivo").DataTable({
        language: _languageDataTables,
        responsive: true,
        /*    dom: "<'pull-left'Bf>rtip",*/
        searching: false,
        ordering: false,
        initComplete: function () {
        }
    });

    $('#btnBuscar').click(function () {
        $(this).hide();
        $('#btnLoading').show();
        Buscar(this);
    });

    $('#btnAgregar').click(function () {
        Crear();
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

function Crear() {
    location.href = rutaPrincipal + "ComplejoPolideportivo/CrearComplejoPolideportivo"
}

function Buscar(btnElement) {
    let content_button2 = `<i class="fa fa-search" aria-hidden="true"></i> Buscando`;
    let content_button = `<i class="fa fa-search" aria-hidden="true"></i> Buscar`;
    var nombre_complejoPoli = $('#txtNombreComplejoPolideportivo').val();
    resetLoadingButton("btnBuscar", content_button2);
    if (typeof nombre_complejoPoli == "undefined" || nombre_complejoPoli == null || nombre_complejoPoli == "") {
        nombre_complejoPoli = "";
    }

    var id_sede = $('#selSedes').val();
    if (typeof id_sede == "undefined" || id_sede == null || id_sede == "" || id_sede == "-1") {
        id_sede = 0;
    }

    if ($.fn.DataTable.isDataTable('#TablaDatosComplejoPolideportivo')) {
        _tblUsuario.destroy();
    }
    _tblUsuario = $("#TablaDatosComplejoPolideportivo").DataTable({
        language: _languageDataTables,
        //"processing": true,
        //"serverSide": true,
        ordering: false,
        responsive: true,
        searching: false,
        /*paging: true,*/
        fixedColumns: true,
        "ajax": {
            "url": rutaPrincipal + `ComplejoPolideportivo/GetListadoComplejoPolideportivo?nombre_complejoPoli=${nombre_complejoPoli}&id_sede=${id_sede}&draw=0`,
            "type": "GET",
            "datatype": "json",
            "data": function (d) {
                //d.num_pagina = (d.length > 0) ? (d.start / d.length) + 1 : 1;
                //d.cant_registro = d.length;
                //pageNumber = d.pagina;
                //d.columns = null;
                //d.order = null;
            },

            "dataSrc": function (data, textStatus, xhr) {
                if (data != null && data.data != null) {
                    $('#btnLoading').hide();
                    $(btnElement).show();
                    return data.data;
                } else {
                    return [];
                }
            },
            "error": function (xhr, textStatus) {
                if ($.fn.DataTable.isDataTable('#TablaDatosComplejoPolideportivo')) {
                    _tblUsuario.destroy();
                    console.log(3);
                }
                _tblUsuario = $("#TablaDatosComplejoPolideportivo").DataTable({
                    language: _languageDataTables,
                    responsive: true,
                    /*     dom: "<'pull-left'Bf>rtip",*/
                    searching: false,
                    ordering: false,
                    initComplete: function () {
                    }
                });


                var mensajeError = "Error al obtener los datos de los mensajes.";
                if (xhr.responseJSON != "undefined" && xhr.responseJSON != null) {
                    mensajeError = xhr.responseJSON.Message;
                }
                var colormensaje = 'red';
                if (xhr.status == 404) {
                    $('#btnLoading').hide();
                    $(btnElement).show();
                    colormensaje = 'orange';
                    mensajeError = "No se encontraron datos.";

                }
                resetLoadingButton("btnBuscar", content_button);
                $('#btnLoading').hide();
                $(btnElement).show();
                verMensaje('', mensajeError, colormensaje,
                    'Ok', function () { }, function () { });

            }
        },
        "columns": [
            { "data": "cod_complejo_poli" },
            { "data": "nombre_complejo_poli" },
            { "data": "nombre_sede" },
            {
                "data": "estado",
                "render": function (data, type, full, meta) {

                    return full.estado === true ? 'Activo' : 'Inactivo';

                }
            },
            { "data": "fecha_actualizacion" },
            {
                "data": "id_complejo_poli",
                "render": function (data, type, full, meta) {

                    return '<button class="tabledit-edit-button btn btn-sm btn-info active"  onclick="editarComplejoPolideportivo(\'' + full.id_complejo_poli + '\')"><snap class="fa fa-pencil-square-o" style="float: none; margin: -16px;"></snap></button>  ' +
                        '<button class="tabledit-trash-button btn btn-sm btn-danger"  onclick="eliminarComplejoPolideportivo(\'' + full.id_complejo_poli + '\')"><snap class="fa fa-trash" style="float: none; margin: -16px;"></snap></button>  ';

                }
            },
        ],
        initComplete: function () {
            resetLoadingButton("btnBuscar", content_button);
        }
    });
}


function editarComplejoPolideportivo(id_complejo_poli) {
    location.href = `${rutaPrincipal}ComplejoPolideportivo/EditarComplejoPolideportivo/${id_complejo_poli}`;

}

function eliminarComplejoPolideportivo(id_complejo_poli) {
    verMensaje('', "¿Está seguro de eliminar la sede?", 'warning',
        'Sí', function () { eliminar_CP(id_complejo_poli) }, function () { }, 'No');
}
function eliminar_CP(id_complejo_poli) {
    showLoader();
    $.ajax({
        url: rutaPrincipal + `ComplejoPolideportivo/DeleteEliminarComplejoPolideportivo/${id_complejo_poli}`,
        method: 'DELETE',

        success: function (data, textStatus, xhr) {
            hideLoader();
            if (xhr.status == 200) {
                $('#btnBuscar').click();
                verMensaje('', "Se ha eliminado correctamente la sede", 'green',
                    'Ok', function () { }, function () { });

            } else {
                verMensaje('', "No se pudo eliminar la sede.", 'orange',
                    'Ok', function () { }, function () { });
            }
        },
        error: function (xhr, textStatus) {
            hideLoader();

            verMensaje('', "Error al eliminar la sede", 'red',
                'Ok', function () { }, function () { });
        }

    });
}