$(document).ready(function () {
    $(function () {
        $("#datepicker").datepicker({
            showAnim: 'drop',
            dateFormat: "yy-mm-dd",
            minDate: "-40y",
            maxDate: "-14y",
            changeMonth: true,
            changeYear: true
        });
    });



}); 