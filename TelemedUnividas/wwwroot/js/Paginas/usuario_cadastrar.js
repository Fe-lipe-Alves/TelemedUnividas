$(document).ready(function () {
    /**
     * Exibe e oculta os campos pertinentes a usu�rio secret�rio ou especialista
     */
    $('input[name="tipoUsuario"]').on('change', function(){
        $('.areaEspecialista').hide();
        $('.areaSecretario').hide();

        if ($(this).val() == "especialista") {
            $('.areaEspecialista').show();
        }

        if ($(this).val() == "secretario") {
            $('.areaSecretario').show();
        }        
    });

    /**
     * Valida a entrada dos dados para o cadastro de usu�rio
     */
    $('form#cadastrarUsuario').on('submit', function (event) {

    });

    /**
     * Valida a entrada dos dados para login
     */
    $('form#loginUsuario').on('submit', function (event) {
        if ($('#email').val() === "") {
            $('#email').addClass('is_invalid');
            event.preventDefault();
        }
        if ($('#senha').val() === "") {
            $('#senha').addClass('is_invalid');
            event.preventDefault();
        }
    });

    /**
     * Remove a marca��o de alerta dos campos inv�lidos quando s�o alterados
     */
    $('.is_invalid').on('change', function () {
        $(this).removeClass('is_invalid');
    });
});