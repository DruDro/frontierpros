$(document).on("click touchend", function (e) {
	if (!$(e.target).closest('#menuToggle').length && !$(e.target).closest('#menuClose').length && !$(e.target).closest('.mobile-menu').length) {
		$('.mobile-menu').removeClass('active');
		$('#mobMenuOverlay').removeClass('active');
	} else if ($(e.target).closest('#menuToggle').length) {
		e.preventDefault();
		$('.mobile-menu').toggleClass('active');
		$('#mobMenuOverlay').toggleClass('active');
	} else if ($(e.target).closest('#menuClose').length) {
		e.preventDefault();
		$('.mobile-menu').removeClass('active');
		$('#mobMenuOverlay').removeClass('active');
	}
})