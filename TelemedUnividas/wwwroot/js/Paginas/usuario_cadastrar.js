class EspecialidadeClinica {
    constructor(especialidade, clinica) {
        this.especialidade = especialidade;
        this.clinica = clinica;
    }
}

var espCliVetor = new Array();

$(document).ready(function () {
    /**
     * Exibe e oculta os campos pertinentes a usuário secretário ou especialista
     */
    $('input[name="tipoUsuario"]').on('change', function(){
        $('.areaPaciente').hide();
        $('.areaEspecialista').hide();
        $('.areaSecretario').hide();

        if ($(this).val() == "paciente") {
            $('.areaPaciente').show();
        }

        if ($(this).val() == "especialista") {
            $('.areaEspecialista').show();
        }

        if ($(this).val() == "secretario") {
            $('.areaSecretario').show();
        }    

        let tipo_usuario = $('input[name="tipoUsuario"]:checked').val();

        // Remove todos os required dos campos especificos de cada tipo de usuário
        RequiredCampos(($('.pacienteRequired')), false);
        RequiredCampos(($('.especialidadeRequired')), false);
        RequiredCampos(($('.secretarioRequired')), false);

        // Adiciona a propriedade requerido aos campos pertinentes ao tipo do usuario
        if (tipo_usuario == "paciente") {
            RequiredCampos(($('.pacienteRequired')), true);
        }
        else if (tipo_usuario == "especialista") {
            RequiredCampos(($('.especialidadeRequired')), true);
        }
        else if (tipo_usuario == "secretario") {
            RequiredCampos(($('.secretarioRequired')), true);
        }
    });

    /**
     * Adiciona junções de Especialidade e Clínica
     */
    $('#btnAddEspecialidadeClinica').on('click', function () {
        let especialidade = parseInt($('#selectEspecialidade').val());
        let clinica = parseInt($('#selectClinica').val());
        let espCli = new EspecialidadeClinica(especialidade, clinica);

        try {
            if (!(isNaN(espCli.especialidade) && isNaN(espCli.clinica))) {
                if (isNaN(espCli.especialidade)) {
                    $('#selectEspecialidade').val('').addClass('is-invalid');
                } else {
                    if (isNaN(espCli.clinica)) {
                        $('#selectClinica').val('').addClass('is-invalid');
                    } else {
                        if (espCliVetor.length > 0) {
                            for (var i = 0; i < espCliVetor.length; i++) {
                                console.log((especialidade != espCliVetor[i].especialidade && clinica != espCliVetor[i].clinica));
                                if (especialidade != espCliVetor[i].especialidade && clinica != espCliVetor[i].clinica) {
                                    let id = espCliVetor.length;
                                    espCliVetor[id] = espCli;
                                    $('#especialidadesClinicas').val(JSON.stringify(espCliVetor));
                                    $('#selectEspecialidade').val('');
                                    $('#selectClinica').val('');
                                } else {
                                    console.log('Já existe');
                                }
                            }
                        } else {
                            let id = espCliVetor.length;
                            espCliVetor[id] = espCli;
                            $('#especialidadesClinicas').val(JSON.stringify(espCliVetor));
                            $('#selectEspecialidade').val('');
                            $('#selectClinica').val('');
                        }
                    }
                }
            } else {
                $('#selectEspecialidade').val('').addClass('is-invalid');
                $('#selectClinica').val('').addClass('is-invalid');
            }
        } catch (ex) {
            console.log(ex.message);
        }
    });

    $('#selectClinicaSecretario').on('change', function () {
        let id_clinica = parseInt($(this).val());
        let baseUrl = window.location.origin;

        if (!isNaN(id_clinica)) {
            $.ajax({
                url: baseUrl + '/Especialista/IndexClinica',
                type: 'post',
                data: { 'id_clinica': id_clinica },
                dataType: 'json',
                success: function (response) {
                    if (response.success === true) {
                        if (response.data) {
                            $('#selectEspecialista > option:not(#placeholder)').remove();

                            for (var i = 0; i < response.data.length; i++) {
                                $('#selectEspecialista').append('<option value="' + response.data[i].Codigo + '">' + response.data[i].Nome +'</option>');
                            }


                        }
                    } else {
                        ShowError(response.message);
                    }
                }
            });
        } else {
            // Erro
        }
    });

    /**
     * Valida a entrada dos dados para o cadastro de usuário
     */
    $('form#cadastrarUsuario').on('submit', function (event) {
        $('#especialidadesClinicas').val(JSON.stringify(espCli));
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
     * Remove a marcação de alerta dos campos inválidos quando são alterados
     */
    $('.is-invalid').on('change', function () {
        $(this).removeClass('is-invalid');
    });
});


/**
 * Marca ou desmarca como requerido os campos da lista de campos passado como parâmetro
 * @param {any} campos
 * @param {any} ativo
 */
function RequiredCampos(campos, ativo){
    if (campos.length > 0) {
        campos.each(function (elemento) {
            $(this).prop('required', ativo);
        });
    }
}