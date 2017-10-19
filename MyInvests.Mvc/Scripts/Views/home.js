$(document).ready(function () {

    $("input[name='files']").change(function () {
        $("#mensagem-arquivo-1").html(this.value.split("\\").pop());
        $("button[type='submit']").removeAttr('disabled');
        $("button[type='submit']").removeClass('disabled');
    })

});