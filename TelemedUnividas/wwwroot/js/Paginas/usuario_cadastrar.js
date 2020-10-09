$(document).ready(function () {
    /**
     * Exibe e oculta os campos pertinentes a usuário secretário ou especialista
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

    $('form#cadastrarUsuario').on('submit', function (event) {
        alert('ola');
    });
});
