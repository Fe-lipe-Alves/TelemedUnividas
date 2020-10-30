$(document).ready(function () {
    $('.dia-semana').on('click', function () {
        $('#calendario .ativo').removeClass('ativo');
        $(this).addClass('ativo');
    });
});