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