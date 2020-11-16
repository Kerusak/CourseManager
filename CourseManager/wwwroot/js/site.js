$(document).on('mouseenter', '.course-card', function () {
    let table = $("#table-time")[0];
    let timeStart = $(this).attr('data-time-start');
    let timeEnd = $(this).attr('data-time-end');
    let dateStart = $(this).attr('data-date-start');

    for (let i = timeStart; i < timeEnd; i++) {
        let cell = table.rows[i].cells[dateStart];
        $(cell).css('background-color', 'orange');
    }
});

$(document).on('mouseleave', '.course-card', function () {
    let table = $("#table-time")[0];
    let timeStart = $(this).attr('data-time-start');
    let timeEnd = $(this).attr('data-time-end');
    let dateStart = $(this).attr('data-date-start');

    for (let i = timeStart; i < timeEnd; i++) {
        let cell = table.rows[i].cells[dateStart];
        $(cell).css('background-color', '');
    }
});