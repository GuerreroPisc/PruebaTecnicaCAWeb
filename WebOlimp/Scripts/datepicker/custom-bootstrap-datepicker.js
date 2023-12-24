function initializedatepicker(language, format) {   
    if (language == null || language == "") {
        language = 'es';
    }
    if (format == null || format == "") {
        format = 'dd/mm/yyyy';
    }
    $('.datepicker').datepicker({
        language: language,
        format: format
    });
}
