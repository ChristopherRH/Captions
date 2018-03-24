function ajaxSubmit(action, form, type, bodyReplace) {
    $.ajax({
        url: action,
        data: $(form).serialize(),
        method: type
    }).done(function (result) {
        if (!result.Success) {
            swal("Error", "Error Occurred");
        }
        else {
            $(bodyReplace).html(result.Data);
        }
    });
}

function removePreviousIntercooler()
{
    $(".intercooler-loader").remove();
}
