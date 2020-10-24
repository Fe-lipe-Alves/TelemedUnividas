class EspecialidadeClinica {
    constructor(especialidade, clinica) {
        this.especialidade = especialidade;
        this.clinica = clinica;
    }
}

class EspecialistaClinica {
    constructor(especialista, clinica) {
        this.especialista = especialista;
        this.clinica = clinica;
    }
}

var espCliVetor = new Array();
var secEspClinicaVetor = new Array();

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

        try {
            if (!(isNaN(especialidade) && isNaN(clinica))) {
                if (isNaN(especialidade)) {
                    $('#selectEspecialidade').val('').addClass('is-invalid');
                } else {
                    if (isNaN(clinica)) {
                        $('#selectClinica').val('').addClass('is-invalid');
                    } else {
                        if (espCliVetor.length > 0) {
                            let existe = false; 
                            for (var i = 0; i < espCliVetor.length; i++) {
                                if ((especialidade === espCliVetor[i].especialidade) && (clinica === espCliVetor[i].clinica)) {
                                    existe = true;
                                }
                            }

                            if (!existe) {
                                let id = espCliVetor.length;
                                espCliVetor[id] = new EspecialidadeClinica(especialidade, clinica);
                                $('#especialidadesClinicas').val(JSON.stringify(espCliVetor));
                                $('#selectEspecialidade').val('');
                                $('#selectClinica').val('');
                            } else {
                                // alertar valores já existentes na lista
                            }
                        } else {
                            let id = espCliVetor.length;
                            espCliVetor[id] = new EspecialidadeClinica(especialidade, clinica);
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

    /**
     * Obtem lista de especialistas de acordo com a clínica selecionada
     */
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

    $('#btnAddEspecialistaSecretario').on('click', function () {
        let especialista = parseInt($('#selectEspecialista').val());
        let clinica = parseInt($('#selectClinicaSecretario').val());

        try {
            if (!(isNaN(especialista) && isNaN(clinica))) {
                if (isNaN(especialista)) {
                    $('#selectEspecialista').val('').addClass('is-invalid');
                } else {
                    if (isNaN(clinica)) {
                        $('#selectClinicaSecretario').val('').addClass('is-invalid');
                    } else {
                        if (secEspClinicaVetor.length > 0) {
                            let existe = false;
                            for (var i = 0; i < secEspClinicaVetor.length; i++) {
                                console.log((especialista !== secEspClinicaVetor[i].especialista) && (clinica !== secEspClinicaVetor[i].clinica));
                                console.log(especialista + ' = ' + secEspClinicaVetor[i].especialista + ' | ' + clinica + ' = ' + secEspClinicaVetor[i].clinica);
                                if ((especialista === secEspClinicaVetor[i].especialista) && (clinica === secEspClinicaVetor[i].clinica)) {
                                    existe = true;
                                }
                            }

                            if (!existe) {
                                let id = secEspClinicaVetor.length;
                                secEspClinicaVetor[id] = new EspecialistaClinica(especialista, clinica);
                                $('#clinicaEspecialistaSecretario').val(JSON.stringify(secEspClinicaVetor));
                                $('#selectEspecialista').val('');
                                $('#selectClinicaSecretario').val('');
                            } else {
                                // alertar valores já existentes na lista
                            }
                        } else {
                            let id = secEspClinicaVetor.length;
                            secEspClinicaVetor[id] = new EspecialistaClinica(especialista, clinica);
                            $('#clinicaEspecialistaSecretario').val(JSON.stringify(secEspClinicaVetor));
                            $('#selectEspecialista').val('');
                            $('#selectClinicaSecretario').val('');
                        }
                    }
                }
            } else {
                $('#selectEspecialista').val('').addClass('is-invalid');
                $('#selectClinicaSecretario').val('').addClass('is-invalid');
            }
        } catch (ex) {
            console.log(ex.message);
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