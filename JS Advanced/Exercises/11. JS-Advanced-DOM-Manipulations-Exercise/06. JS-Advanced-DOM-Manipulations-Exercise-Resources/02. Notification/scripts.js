function notify(message) {
    let notificationElement = document.getElementById('notification');
    let notificationElementChild = document.createElement('span');
    notificationElementChild.innerText = message;
    notificationElement.appendChild(notificationElementChild);
    notificationElement.style.display = 'block';
}