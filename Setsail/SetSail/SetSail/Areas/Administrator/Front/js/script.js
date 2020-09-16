$(document).ready(function () {
    $(".tmpick").timepicker({
        //ampmText: { AM: "AM", PM: "PM" },
        hourHeaderText: "Hour",
        minHeaderText: "Min",
        okButtonText: "&#10004;",
        cancelButtonText: "&#10005;"
    });
    $('.datepicker').datepicker({
        format: 'dd.mm.yyyy',
        changeMonth: true,
        changeYear: true,
        autoclose: true,
        yearRange: "-100:+0",
        daysOfWeekHighlighted: ['0', '6']
    });
});