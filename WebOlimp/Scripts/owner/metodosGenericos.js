function validIsNullOrEmpty(valor) {
    if (valor == null) {
        return true;
    }
    if (valor == "") {
        return true;
    }
    return false;
}
function validIsNullOrEmptyOrZero(valor) {
    if (valor == null) {
        return true;
    }
    if (valor == "") {
        return true;
    }
    if (valor == 0 || valor == "0") {
        return true;
    }
    return false;
}
function validIsNullOrEmptOrMinusOne(valor) {
    if (valor == null) {
        return true;
    }
    if (valor == "") {
        return true;
    }
    if (valor == -1 || valor == "-1") {
        return true;
    }
    return false;
}
function loadSelect(idSelects) {//id1, id2, id3, .... -> [id1, id2, id3, ...]
    var idsArray = idSelects.split(',');
    $.each(idsArray, function (index, element) {
        $("#" + element.trim()).html('<option>Cargando...</option>');
    });
}
function resetSelect(idSelects, text) {
    var idsArray = idSelects.split(',');
    if (text == "undefined" || text == null) {
        text = 'Seleccione...';
    }
    $.each(idsArray, function (index, element) {
        $("#" + element.trim()).html('<option value="-1">' + text + '</option>');
    });
}
function fillSelect(idSelectPicker, data, nameCodigo, nameDescripcion, text) {
    resetSelect(idSelectPicker, text);
    if (data != null && data.length > 0) {
        $.each(data, function (index, element) {
            var selected = "";
            $("#" + idSelectPicker.trim()).append('<option value="' + element[nameCodigo] + '" ' + selected + '>' + element[nameDescripcion] + '</option>');
        });
    }
}
function fillSelectSinReset(idSelectPicker, data, nameCodigo, nameDescripcion, text) {
    $("#" + idSelectPicker).html('');
    if (data != null && data.length > 0) {
        $.each(data, function (index, element) {
            var selected = "";
            $("#" + idSelectPicker.trim()).append('<option value="' + element[nameCodigo] + '" ' + selected + '>' + element[nameDescripcion] + '</option>');
        });
    }
}
function restartSelectpicker(idSelectPicker, valueDefect) {
    $(`#${idSelectPicker}`).selectpicker('destroy');
    $(`#${idSelectPicker}`).val(valueDefect);
    $(`#${idSelectPicker}`).selectpicker();
}
function showMessage(title, content, type, textBtntryAgain, callbackTryAgain, callbackClose, textClose) {
    $.confirm({
        title: title,
        content: content,
        type: type,
        typeAnimated: true,
        buttons: {
            tryAgain: {
                text: textBtntryAgain,
                btnClass: 'btn-' + type,
                action: function () {
                    callbackTryAgain();
                }
            },
            close: {
                text: (textClose == null || textClose == "undefined") ? "Cerrar" : textClose,
                action: function () {
                    callbackClose();
                }
            }
        }
    });
}

function showMessageautoClose(title, content, type, textBtntryAgain, callbackTryAgain, callbackClose, textClose, timeOutInput) {
    var timeOut = 1000;
    if (timeOutInput > 0) {
        timeOut = timeOutInput;
    }
    return $.confirm({
        title: title,
        content: content,
        type: type,
        typeAnimated: true,
        buttons: {
            tryAgain: {
                text: textBtntryAgain,
                btnClass: 'btn-' + type,
                action: function () {
                    callbackTryAgain();
                }
            },
            close: {
                text: (textClose == null || textClose == "undefined") ? "Cerrar" : textClose,
                action: function () {
                    callbackClose();
                }
            }
        }
    });
}

function CloseSession() {
    showMessage('Sistema', 'Su sesión a expirado', 'red', 'Ok', function () { Logout(); }, function () { Logout(); });
    //Logout();
}
function Logout() {
    location.href = '/Account/Logout';
}

function onlyNumbers(valor) {
    var regex = new RegExp("^[0-9]+$");
    if (!regex.test(valor)) {
        return false;
    }
    return true;
}
/**
 * completar a la izquierda, por defecto la variable length tiene valor 6
 * @param {any} value
 * @param {any} length
 */
function PadLeft(value, length) {
    if (length == null) {
        length = 6;
    }
    return (value.toString().length < length) ? PadLeft("0" + value, length) :
        value;
}