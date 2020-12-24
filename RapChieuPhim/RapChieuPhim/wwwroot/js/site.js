// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//Them tài khoản
$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');
    var HienThiModalNDElement = $('#HienThiModalND');
    

    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })

    $('button[data-toggle="ajax-modal-nd"]').click(function (event) {
        console.log("aaaa");
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            HienThiModalNDElement.html(data);
            HienThiModalNDElement.find('.modal').modal('show');
        })
    })

    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        console.log(sendData);
        console.log(actionUrl);
        $.post('TaiKhoan/' + actionUrl, sendData).done(function (data) {
            PlaceHolderElement.find('.modal').modal('hide');
        })
    })
})
