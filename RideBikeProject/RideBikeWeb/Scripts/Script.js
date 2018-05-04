$(document).ready(function () {
    $("#dialog").dialog({
        autoOpen: false,
        modal: true,
        height: '634',
        width: '855',
        open: function (ev, ui) {
            $('#popup-youtube-player').attr('height', '580');
            $('#popup-youtube-player').attr('width', '854');
        }
    });

    $('#dialogBtn').click(function () {
        $('#dialog').dialog('open');
    });

    //video will stop then popup is closed
    $('.ui-dialog-titlebar-close').on('click', function () {
        $('#popup-youtube-player')[0].contentWindow.postMessage('{"event":"command","func":"' + 'stopVideo' + '","args":""}', '*');
    });


    $("#logo").mouseenter(function () {
        $('#logo').attr('src', '../../Content/Img/logo/logosm.png');
    });

    $("#logo").mouseleave(function () {
        $('#logo').attr('src', '../../Content/Img/logo/logo.png');
    });


    //$(function () {
    //    //Keep track of last scroll
    //    var lastScroll = 0;
    //    $(window).scroll(function (event) {
    //        //Sets the current scroll position
    //        var st = $(this).scrollTop();
    //        //Determines up-or-down scrolling
    //        if (st > lastScroll) {
    //            //Replace this with your function call for downward-scrolling
    //            alert("DOWN");
    //        }
    //        else {
    //            //Replace this with your function call for upward-scrolling
    //            alert("UP");
    //        }
    //        //Updates scroll position
    //        lastScroll = st;
    //    });
    //});




}); 








