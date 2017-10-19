$(document).ready(function () {

    $("#file-renda-fixa").change(function () {
        $("#mensagem-arquivo-1").html(this.value.split("\\").pop());
        $("#botao-renda-fixa").removeAttr('disabled');
        $("#botao-renda-fixa").removeClass('disabled');
    })

    $("#file-fundos").change(function () {
        $("#mensagem-arquivo-2").html(this.value.split("\\").pop());
        $("#botao-fundos").removeAttr('disabled');
        $("#botao-fundos").removeClass('disabled');
    })

});