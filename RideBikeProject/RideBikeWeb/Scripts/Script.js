$(document).ready(function () {
    $("#dialog").dialog({
        autoOpen: false,
        modal: true,
        height: '645',
        width: '888',
        open: function (ev, ui) {
            $('#popup-youtube-player').attr('height', '580');
            $('#popup-youtube-player').attr('width', '854');
        }
    });

    $('#dialogBtn').click(function () {
        $('#dialog').dialog('open');
    });

    // Video will stop then popup is closed
    $('.ui-dialog-titlebar-close').on('click', function () {
        $('#popup-youtube-player')[0].contentWindow.postMessage('{"event":"command","func":"' + 'stopVideo' + '","args":""}', '*');
    });



    $("#logo").mouseenter(function () {
        $('#logo').attr('src', '../../Content/Img/logo/logosm.png');
    });

    $("#logo").mouseleave(function () {
        $('#logo').attr('src', '../../Content/Img/logo/logo.png');
    });







}); 








