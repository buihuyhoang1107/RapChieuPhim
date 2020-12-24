// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//OnClick hiện modal truyền vào đường dẫn và tiêu đề chức năng
showModalAcount = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            //hiện form create edit
            $('#form-modal .modal-body').html(res);
            //hiện tiêu đề
            $('#form-modal .modal-title').html(title);
            //hiện modal
            $('#form-modal').modal('show');
        }
    })
};

//Them tài khoản
$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })

    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {
            PlaceHolderElement.find('.modal').modal('hide');
        })
    })
})
