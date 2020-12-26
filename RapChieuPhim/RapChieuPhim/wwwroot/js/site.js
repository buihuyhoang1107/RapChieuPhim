// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//Them tài khoản
$(function () {
    //Khai báo biến để lấy dữ liệu vào div
    var PlaceHolderElement = $('#PlaceHolderHere');
    var HienThiModalNDElement = $('#HienThiModalND');

    //Xuất hiện màn hình modal để thêm tài khoản
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })

    })
    //Thông báo thêm mới thành công
    $('button[data-toggle="ajax-modal"]').ready(function () {
        $('button[data-toggle="ajax-modal"]').ajaxSuccess(function () {
            alert("Thêm mới thành công");
        });

    });

    //Xuất hiện màn hình modal để thêm người dùng----------------------------------------------------------------
    $('button[data-toggle="ajax-modal-nd"]').click(function (event) {

        //console.log("aaaa");

        var url = $(this).data('url');
        var decodeURL = decodeURIComponent(url);
        $.get(decodeURL).done(function (data) {
            HienThiModalNDElement.html(data);
            HienThiModalNDElement.find('.modal').modal('show');
           
        })
    })

    //Thêm người dùng bằng modal
    HienThiModalNDElement.on('click', '[data-save="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        console.log(sendData);
        console.log(actionUrl);
        $.post(actionUrl, sendData).done(function (data) {
            HienThiModalNDElement.find('.modal').modal('hide');
        })
        HienThiModalNDElement.ajaxSuccess(function () {
            alert("Thêm mới thành công");
        });
    })
})
