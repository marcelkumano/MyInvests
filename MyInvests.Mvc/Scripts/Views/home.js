$(document).ready(function () {

    $(".custom-file-input").change(function () {

        $(this).siblings(".custom-file-control").html(this.value.split("\\").pop());
    })

    $("input[type=file]").change(function () {

        var parentForm = $(this).closest('form');
        var button = $(parentForm).find('button');
        var inputNaoPreenchido = 0;

        $(parentForm).find('input[type=file]').each(function (i, obj) {

            var value = $(obj).val();

            if (value == '') {
                inputNaoPreenchido++;
            }
        })

        if (inputNaoPreenchido == 0) {
            $(button).removeAttr('disabled');
            $(button).removeClass('disabled');
        }
        else {
            $(button).attr('disabled', 'disabled');
            $(button).addClass('disabled');
        }


    })


});