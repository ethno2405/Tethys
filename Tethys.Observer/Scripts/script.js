function showPopup(title, message, confirmUrl) {
    $.ajax({
        url: '/modal/popup',
        method: 'GET',
        data: {
            title: title,
            message: message,
            confirmUrl: confirmUrl
        },
        success: function (html) {
            $('#popup').html(html);
            $('#modal').modal();
        }
    });
}

function showAlert(title, message) {
    $.ajax({
        url: '/modal/alert',
        method: 'GET',
        data: {
            title: title,
            message: message,
        },
        success: function (html) {
            $('#popup').html(html);
            $('#alert').modal();

            if (document.getElementById('call-list')) {
                refreshCallList();
            }
        }
    });
}

function refreshCallList() {
    $.ajax({
        url: '/call/getcalls',
        method: 'GET',
        success: function (html) {
            $('#call-list').html(html);
        }
    });
}