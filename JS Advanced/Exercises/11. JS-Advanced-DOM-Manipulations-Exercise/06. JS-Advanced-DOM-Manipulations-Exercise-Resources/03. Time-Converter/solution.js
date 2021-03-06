function attachEventsListeners() {
    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');

    let event = document.getElementById('secondsBtn');
    event.addEventListener('click', () => { convert(+seconds.value) });

    function convert(sec) {
        days.value = sec / (24 * 60 * 60);
        hours.value = sec / (60 * 60);
        minutes.value = sec / 60;
    }
}