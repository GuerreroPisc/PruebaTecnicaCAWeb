"use strict";
$(document).ready(function(){

    
    var table = $('#datatable-buttons').DataTable({ //inicializacion de una tabla  id = datatable-buttons
        lengthChange: false,
        buttons: ['copy', 'csv', 'excel', 'pdf', 'print']
    });

    table.buttons().container()
    .appendTo('#datatable-buttons_wrapper .col-md-6:eq(0)');

});