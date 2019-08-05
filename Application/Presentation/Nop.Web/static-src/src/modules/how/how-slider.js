$(function () {
	let howSliderIsRunning = false;
	const initHowSlider = () => {
		$('.how__tabs ol').slick({
			dots: true,
			infinite: false,
			speed: 300,
			swipeToSlide: true,
			mobileFirst: true,
			prevArrow: '<span class="prev"><i class="icon fas fa-chevron-left"></i></span>',
			nextArrow: '<span class="next"><i class="icon fas fa-chevron-right"></i></span>',
			slide: '.tablet-slide',
			slidesToShow: 1,
			slidesToScroll: 1,
			appendArrows: $('.how__tabs .slider__nav'),
			appendDots: $('.how__tabs .slider__nav'),
			responsive: [{
				breakpoint: 1024,
				settings: "unslick"

			}, ]
		})
	};
	initHowSlider();
	$(window).resize($.debounce(750, function () {
		if ($(window).width() < 1024 && howSliderIsRunning == false) {
			initHowSlider();
			$('.how__tabs ol').slick('slickGoTo', 0);
			howSliderIsRunning = true;
		} else {
			howSliderIsRunning = false;
		}
	}))

})