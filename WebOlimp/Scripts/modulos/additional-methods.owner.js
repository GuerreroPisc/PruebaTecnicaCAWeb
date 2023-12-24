$.validator.addMethod("valueNotEquals", function (value, element, arg) {
    return arg !== value;
}, "Value must not equal arg.");
$.validator.addMethod("alphanumericwithspace", function (value, element) {
    return this.optional(element) || /^[A-Za-záéíóúÁÉÍÓÚ\s0-9ñ]+$/i.test(value);
}, "Letras, números, guiones bajos y espacios solo por favore");

$.validator.addMethod("address", function (value, element) {
    return this.optional(element) || /^[A-Za-záéíóúÁÉÍÓÚ\s0-9ñ#.,/\-º°]+$/i.test(value);
}, "Letras, números, guiones bajos y espacios solo por favor");

$.validator.addMethod("nombre", function (value, element) {
    return this.optional(element) || /^[A-Za-záéíóúÁÉÍÓÚ\ñ.]+$/i.test(value);
}, "Letters, numbers, underscores and spaces only please");



$("#myform").validate({
    showErrors: function (errorMap, errorList) {
        $("#summary").html("Your form contains "
            + this.numberOfInvalids()
            + " errors, see details below.");
        this.defaultShowErrors();
    }
});


$.validator.addMethod("decimalsix", function (value, element) {
    return this.optional(element) || /^-?\d+(\.\d{1,6})?$/i.test(value);
}, "Please specify a valid giro account number");

$.validator.addMethod("alphabet", function (value, element) {
    return this.optional(element) || /^[A-Za-záéíóúÁÉÍÓÚ\sñ]+$/i.test(value);
}, "Letters, numbers, underscores and spaces only please");
