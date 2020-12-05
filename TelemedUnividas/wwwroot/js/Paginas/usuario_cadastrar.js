/**
 * Estrutura para armazenar a combinação de especialidade-clinica
 */
class EspecialidadeClinica {
    constructor(especialidade, clinica) {
        this.especialidade = especialidade;
        this.clinica = clinica;
    }
}

/**
 * Estrutura para armazenar a combinação de especialista-clinica
 */
class EspecialistaClinica {
    constructor(especialista, clinica) {
        this.especialista = especialista;
        this.clinica = clinica;
    }
}

// Variável global que armazena as combinações de especialidade-clinica
var espCliVetor = new Array();
// Variável global que armazena as combinações de especialista-clinica
var secEspClinicaVetor = new Array();

/**
 * Insere uma nova linha na tabela de clinica-especialidade
 * 
 * @param {string} clinica
 * @param {string} especialidade
 * @param {EspecialidadeClinica} espCli
 */
function inserirTabelaEspecialista(clinica, especialidade, espCli) {
    $('#tabelaVinculosEspecialista tbody').append('<tr>'+
        '<td data-clinica="' + espCli.clinica + '">' + clinica + '</td>' +
        '<td data-especialidade="' + espCli.especialista + '">' + especialidade + '</td></tr>');

    $('#feedback_especialista_nulo').hide();
    $('#tabelaVinculosEspecialista').show();
}

/**
 * Valida e insere uma nova combinação de clinica-especialidade
 */
function adicionarClinicaEspecialista()
{
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
                        // Verifica se a combinação clinica-especialidade já existe na lista
                        let existe = false;
                        for (var i = 0; i < espCliVetor.length; i++) {
                            if ((especialidade === espCliVetor[i].especialidade) && (clinica === espCliVetor[i].clinica)) {
                                existe = true;
                            }
                        }

                        // Insere na lista se ainda não existe
                        if (!existe) {
                            // Insere na Lista
                            let id = espCliVetor.length;
                            espCliVetor[id] = new EspecialidadeClinica(especialidade, clinica);

                            // Inserir na tabela
                            inserirTabelaEspecialista($('#selectClinica option:selected').text(), $('#selectEspecialidade option:selected').text(), espCliVetor[id]);

                            // Limpar selects
                            $('#especialidadesClinicas').val(JSON.stringify(espCliVetor));
                            $('#selectEspecialidade').val('');
                            $('#selectClinica').val('');
                        } else {
                            // alertar valores já existentes na lista
                        }
                    } else {
                        // Insere na lista
                        let id = espCliVetor.length;
                        espCliVetor[id] = new EspecialidadeClinica(especialidade, clinica);

                        // Inserir na tabela
                        inserirTabelaEspecialista($('#selectClinica option:selected').text(), $('#selectEspecialidade option:selected').text(), espCliVetor[id]);

                        // Limpar selects
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
}

/**
 * Remove uma linha da tabela de clinica-especialidade
 * 
 * @param {EspecialidadeClinica} espCli
 */
function removerTabelaEspecialista(espCli) {
    let x = $('#tabelaVinculosEspecialista tr[data-clinica="' + espCli.clinica + '"] ~ tr[data-especialidade="' + espCli.especialista + '"]');
    console.log(x);

    if (espCliVetor.length <= 0) {
        $('#feedback_especialista_nulo').show();
        $('#tabelaVinculosEspecialista').hide();
    }
}

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
        adicionarClinicaEspecialista();
    });

    /**
     * Obtem lista de especialistas de acordo com a clínica selecionada
     */

    /*$('#selectClinicaSecretario').on('change', function () {
        let id_clinica = parseInt($(this).val());

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
    */

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

    /**
     * Carrega a lista de cidades por ajax conforme ocorrer mudança no estado 
     */
    $('select#estado').on('change', function () {
        let estado_codigo = $(this).val();

        $('select#cidade option').each(function () {
            $(this).remove();
        });

        $.ajax({
            url: '../Cidade/ObterCidadesPorEstado',
            data: { estado_codigo: estado_codigo },
            type: 'get',
            dataType: 'json',
            success: function (cidades) {
                if (cidades.length > 0) {
                    cidades.forEach(function (item) {
                        $('select#cidade').append('<option value="' + item.codigo + '">' + item.nome +'</option>');
                    });
                }
            }
        });
    });

    /**
     * Carrega a lista de Especialistas por ajax conforme ocorrer mudança de clínica 
     */
    $('select#selectClinicaSecretario').on('change', function () {
        let clinica_codigo = $(this).val();

        $('select#selectEspecialista option').each(function () {
            $(this).remove();
        });

        $.ajax({
            url: '../Especialista/ObterPorClinica',
            data: { clinica_codigo: clinica_codigo },
            type: 'get',
            dataType: 'json',
            success: function (especialista) {
                if (especialista.length > 0) {
                    especialista.forEach(function (item) {
                        $('select#selectEspecialista').append('<option value="' + item.codigo + '">' + item.nome + '</option>');
                    });
                }
            }
        });
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