$(document).ready(function () {
    /**
     * Exibe o formulário para inserção de novo item
     */
    $('#btnAdicionar').on('click', function () {
        $('#adicionar').show();
        $(this).hide();
    });

    /**
     * Exibe a caixa de edição do item
     */
    $('.btnEditar').on('click', function () {
        let id = $(this).parents('.itemLista').data('item');
        $(this).parents('.itemLista').removeClass('d-flex').hide();
        $('tr.editItem[data-item="' + id + '"]').show();
    });

    /**
     * Oculta a caixa de edição do item
     */
    $('.btnCancelarEditar').on('click', function () {
        let id = $(this).parents('.editItem').hide().data('item');
        $('tr.itemLista[data-item="' + id + '"]').show().addClass('d-flex');
    });

    /**
     * Salva o item editado
     */
    $('.formEditItem').on('submit', function (event) {
        event.preventDefault();
        let elemento = $(this);
        let id = elemento.parents('.editItem').data('item');
        let itemLista = $('tr.itemLista[data-item="' + id + '"]');
        let valor = $('#inputDescricao').val();

        elemento.parents('.editItem').find('.load').show();
        elemento.parents('.editItem').find('.noLoad').removeClass('d-flex').hide();

        $.ajax({
            url: elemento.attr('action'),
            type: 'post',
            data: elemento.serialize(),
            dataType: 'json',
            success: function (response) {
                if (response.success === true) {
                    itemLista.find('.dadosItem').html(valor);

                    elemento.parents('.editItem').find('.load').hide();
                    elemento.parents('.editItem').find('.noLoad').show().addClass('d-flex');
                    elemento.parents('.editItem').hide();
                    itemLista.show().addClass('d-flex');
                } else {
                    
                }
            }
        });
    });

    /**
     * Exibe a caixa de remoção do item
     */
    $('.btnRemover').on('click', function () {
        let id = $(this).parents('.itemLista').data('item');
        $(this).parents('.itemLista').removeClass('d-flex').hide();
        $('tr.deleteItem[data-item="' + id + '"]').show();
    });

    /**
     * Oculta a caixa de remoção do item
     */
    $('.btnCancelarRemover').on('click', function () {
        let id = $(this).parents('.deleteItem').hide().data('item');
        $('tr.itemLista[data-item="' + id + '"]').show().addClass('d-flex');
    });

    /**
     * Remove o item
     */
    $('.formDeleteItem').on('submit', function (event) {
        event.preventDefault();
        let elemento = $(this);
        let id = elemento.parents('.deleteItem').data('item');
        let itemLista = $('tr.itemLista[data-item="' + id + '"]');
        let valor = $('#inputDescricao').val();

        elemento.parents('.deleteItem').find('.load').show();
        elemento.parents('.deleteItem').find('.noLoad').removeClass('d-flex').hide();

        $.ajax({
            url: elemento.attr('action'),
            type: 'post',
            data: elemento.serialize(),
            dataType: 'json',
            success: function (response) {
                if (response.success === true) {
                    elemento.find('.feedback').html(response.message);

                    elemento.parents('.deleteItem').find('.load').hide();
                    $('tr.itemLista[data-item="' + id + '"]').remove();
                    $('tr.editItem[data-item="' + id + '"]').remove();

                    setTimeout(function () {
                        $('tr.deleteItem[data-item="' + id + '"]').remove();
                    }, 1000);
                } else {

                }
            }
        });
    });
});