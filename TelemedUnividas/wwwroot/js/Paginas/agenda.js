var data, horario;

$(document).ready(function () {
    $('.dia-semana').on('click', function () {
        $('#calendario .ativo, #detalhes .hora.ativo, #detalhes .meia-hora.ativo').removeClass('ativo');

        $('#detalhes .meia-hora.ativo').removeClass('ativo').html('');
        $('#detalhes .hora.ativo').removeClass('ativo');

        horario = '';
        $(this).addClass('ativo');
        data = $(this).data('data');
    });

    $('.meia-hora').on('click', function () {
        if (!$(this).hasClass('ativo')) {
            $('#detalhes .meia-hora.ativo').removeClass('ativo').html('');
            $('#detalhes .hora.ativo').removeClass('ativo');

            $(this).addClass('ativo').html($('#modelo-agendar').html());
            $(this).parents('.hora').addClass('ativo');


            horario = $(this).data('horario');
        }
    });

    $(document).on('click', '.fechar-agendamento', function () {
        $('#detalhes .meia-hora.ativo').removeClass('ativo').html('');
        $('#detalhes .hora.ativo').removeClass('ativo');
    });

    $(document).on('click', '#btnAgendar', function (event) {
        event.preventDefault();

        $('#formRealAgendar').submit();
    });

    $('#formRealAgendar').on('click', function (event) {
        event.preventDefault();

        $(this).find('#data').val(data + ' ' + horario);

        $('#cpf').val($('#cpfForm').val());

        $.ajax({
            url: $(this).attr('action'),
            type: 'post',
            data: $(this).serialize(),
            dataType: 'json',
            success: function (response) {
                console.log(response);
                if (response.success === true) {

                } else {

                }
            },
            error: function () {
                alert('Ocorreu um erro ao agendar.');
            }
        });
    });
});