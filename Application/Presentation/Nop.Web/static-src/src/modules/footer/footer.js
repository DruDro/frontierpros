const stickFooter = () => {
	const fh = $('.footer').outerHeight();
	$('body').css("padding-bottom",fh);
};


// $('.footer .mob-collapse').click(function(){
// 	$('.footer .mob-collapse').not(this).removeClass('expanded').next('ul').slideUp(150);
// 	$(this).toggleClass('expanded');
// 	$(this).next('ul').slideToggle(150);
// 	setTimeout(stickFooter, 150);
// });





if ($(window).width() < 768) {
	$('.footer .mob-collapse').click(function(){
		$('.footer .mob-collapse').not(this).removeClass('expanded').next('ul').slideUp(150);
		$(this).toggleClass('expanded');
		$(this).next('ul').slideToggle(150);
		setTimeout(stickFooter, 150);
	});
} else if ($(window).width() > 768) {
	$('.footer .mob-collapse').click(function(e) {
		e.preventDefault();
		
	})
}