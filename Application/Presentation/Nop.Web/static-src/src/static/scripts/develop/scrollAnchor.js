$(function(){
	function scrollAnhor() {
		var $links = $('.js-anchor');

		$links.on('click', function(e) {
			e.preventDefault();
			if($(this.hash).length){

				$('html,body').animate({scrollTop:$(this.hash).offset().top}, 1000);
			}

		})
	}
	scrollAnhor();
});