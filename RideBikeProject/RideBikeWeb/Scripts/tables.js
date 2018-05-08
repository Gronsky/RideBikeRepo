$(document).ready(function () {
    $('#TeamsTable').jtable({
        title: 'Teams',
        paging: true,
        pageSize: 10,
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
        pageSize: 10,
        sorting: false,
        actions: {
            listAction: '/Event/GetEvents',
            createAction: '/Event/CreateEvent',
            updateAction: '/Event/EditEvent',
            deleteAction: '/Event/DeleteEvent'
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
                width: '15%'
            },
            DateTime: {
                title: 'Date',
                type: 'date',
                displayFormat: 'yy-mm-dd',
                width: '15%'
            },
            Location: {
                title: 'Location',
                width: '30%'
            },
            Description: {
                title: 'Description',
                width: '30%',
                list: false
            },
            TypeId: {
                title: 'Type',
                edit: false,
                list: false
            },
            CreatedBy: {
                title: 'CreatedBy',
                edit: true,
                list: false
            }
        }
    });
    $('#EventsTable').jtable('load');



}); 
