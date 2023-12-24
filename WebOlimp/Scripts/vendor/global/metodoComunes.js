var _languageDataTables = {
    "sProcessing": "Procesando...",
    "sLengthMenu": "Mostrar _MENU_ registros",
    "sZeroRecords": "No se encontraron resultados",
    "sEmptyTable": "Ningún dato disponible en esta tabla.",
    //"sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
    "sInfo": "Registros del _START_ al _END_. Total: _TOTAL_",
    //"sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
    "sInfoEmpty": "No hay registros para mostrar",
    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
    "sInfoPostFix": "",
    "sSearch": "Buscar:",
    "sUrl": "",
    "sInfoThousands": ",",
    "sLoadingRecords": "Cargando...",
    "oPaginate": {
        "sFirst": "Primero",
        "sLast": "Último",
        "sNext": "Siguiente",
        "sPrevious": "Anterior"
    },
    "oAria": {
        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
    },
    "buttons": {
        "copy": "Copiar",
        "colvis": "Visibilidad"
    }
};
function showLoader() {
    $('.loader').css("display", "block");
    $('#main-wrapper').css("display", "none");
}
function hideLoader() {
    $('.loader').css("display", "none");
    $('#main-wrapper').css("display", "block");
}