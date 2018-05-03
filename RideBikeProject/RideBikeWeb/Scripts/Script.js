$(document).ready(function () {
    $('#TeamsTable').jtable({
        title: 'Teams',
        paging: false,
        pageSize: 5,
        sorting: false, 
        actions: {
            listAction: '/Team/GetTeams',
            createAction: '/Team/CreateTeam',
            updateAction: '/Team/EditTeam',
            deleteAction: '/Team/DeleteTeam'  
        },
        fields: {
            Id: {
                key: true,
                create: false,
                edit: false,
                list: false
            },
            Name: {
                title: 'Name',
                width: '30%'
            },
            Image: {
                title: 'Image',
                list: false
            },
            Location: {
                title: 'Location',
                width: '30%'
            },
            Description: {
                title: 'Description',
                width: '30%',
            },
            ChiefId: {
                title: 'Chief',
                edit: true,
                list: false
            }
        },
    });
    $('#TeamsTable').jtable('load');

    $('#EventsTable').jtable({
        title: 'Teams',
        paging: true,
        pageSize: 5,
        sorting: true,
        actions: {
            listAction: '/Event/GetEvents',
            createAction: '/Event/CreateEvent',
            updateAction: '/Event/EditEvent',
            deleteAction: '/Event/DeleteEvent'
        },
        fields: {
            ID: {
                key: true,
                create: false,
                edit: false,
                list: false
            },
            Name: {
                title: 'Name',
                width: '15%'
            },
            Location: {
                title: 'Location',
                width: '30%'
            },
            Description: {
                title: 'Description',
                width: '30%',
            },
            CreatedBy: {
                title: 'CreatedBy',
                edit: true,
                list: false
            }
        }
    });
    $('#EventsTable').jtable('load');


    $(function () {
        $("#datepicker").datepicker({
            showAnim: 'drop',
            dateFormat: "yy-mm-dd",
            minDate: "+1",
            maxDate: "+3m",
            changeMonth: true,
            changeYear: true
        });
    });


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





        window.fbAsyncInit = function() {
            FB.init({
                appId: '399912107157444',
                cookie: true,
                xfbml: true,
                version: '3.0'
            });
      
        FB.AppEvents.logPageView();

  };

  (function(d, s, id){
     var js, fjs = d.getElementsByTagName(s)[0];
     if (d.getElementById(id)) {return;}
     js = d.createElement(s); js.id = id;
     js.src = "https://connect.facebook.net/en_US/sdk.js";
     fjs.parentNode.insertBefore(js, fjs);
   }(document, 'script', 'facebook-jssdk'));


}); 








