$(function () {
    $('#calendar').fullCalendar({
        locale: 'ru',
        lang : 'ru',
        height: 800,
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        dayClick: function () {
            $('#event-modal').modal('show');
        },
        events: [
            {
                title: 'Выходной',
                start: '2018-10-31',
                allDay : false

            }]
    });
});