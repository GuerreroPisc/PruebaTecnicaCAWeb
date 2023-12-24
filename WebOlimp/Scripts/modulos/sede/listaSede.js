var TablaDatosSede;
var cant_registros = 20;

$(document).ready(function () {
    $('#btnLoading').hide();
    _tblUsuario = $("#TablaDatosSede").DataTable({
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
});

function Crear() {
    location.href = rutaPrincipal + "Sede/CrearSede"
}

function Buscar(btnElement) {
    let content_button2 = `<i class="fa fa-search" aria-hidden="true"></i> Buscando`;
    let content_button = `<i class="fa fa-search" aria-hidden="true"></i> Buscar`;
    var nombre_sede = $('#txtNombreSede').val();
    resetLoadingButton("btnBuscar", content_button2);
    if (typeof nombre_sede == "undefined" || nombre_sede == null || nombre_sede == "") {
        nombre_sede = "";
    }

    if ($.fn.DataTable.isDataTable('#TablaDatosSede')) {
        _tblUsuario.destroy();
    }
    _tblUsuario = $("#TablaDatosSede").DataTable({
        language: _languageDataTables,
        //"processing": true,
        //"serverSide": true,
        ordering: false,
        responsive: true,
        searching: false,
        /*paging: true,*/
        fixedColumns: true,
        "ajax": {
            "url": rutaPrincipal + `Sede/GetListadoSede?nombre_sede=${nombre_sede}&draw=0`,
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
                if ($.fn.DataTable.isDataTable('#TablaDatosSede')) {
                    _tblUsuario.destroy();
                    console.log(3);
                }
                _tblUsuario = $("#TablaDatosSede").DataTable({
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
            { "data": "cod_sede" },
            { "data": "nombre_sede" },
            { "data": "numero_complejos" },
            { "data": "presupuesto" },
            {
                "data": "estado",
                "render": function (data, type, full, meta) {

                    return full.estado === true ? 'Activo' : 'Inactivo';

                }
            },
            { "data": "fecha_actualizacion" },
            {
                "data": "id_sede",
                "render": function (data, type, full, meta) {

                    return '<button class="tabledit-edit-button btn btn-sm btn-info active"  onclick="editarSede(\'' + full.id_sede + '\')"><snap class="fa fa-pencil-square-o" style="float: none; margin: -16px;"></snap></button>  ' +
                        '<button class="tabledit-trash-button btn btn-sm btn-danger"  onclick="eliminarSede(\'' + full.id_sede + '\')"><snap class="fa fa-trash" style="float: none; margin: -16px;"></snap></button>  ';

                }
            },
        ],
        initComplete: function () {           
            resetLoadingButton("btnBuscar", content_button);
        }
    });
}


function editarSede(id_sede) {
    location.href = `${rutaPrincipal}Sede/EditarSede/${id_sede}`;

}

function eliminarSede(id_sede) {
    verMensaje('', "¿Está seguro de eliminar la sede?", 'warning',
        'Sí', function () { eliminar_sede(id_sede) }, function () { }, 'No');
}
function eliminar_sede(id_sede) {
    showLoader();
    $.ajax({
        url: rutaPrincipal + `Sede/DeleteEliminarSede/${id_sede}`,
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