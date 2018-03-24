function ajaxSubmit(action, form, type, bodyReplace) {
    var content = encodeURI($(form).find('textarea[name="content"]').val())
    encodeURI($(form).find('textarea[name="content"]').val(content))
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

$(function () {
    $.trumbowyg.svgPath = false;
    $('#trumbowyg').trumbowyg({
        btns: [
            ['viewHTML'],
            ['undo', 'redo'], // Only supported in Blink browsers
            ['formatting'],
            ['strong', 'em'],
            ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
            ['unorderedList', 'orderedList'],
            ['horizontalRule'],
        ]
    });
});


$(function () {
    $.each($(".content-as-html"), function (key, value) {
        var text = $(value).text();
        $(value).html(text);
    });

})