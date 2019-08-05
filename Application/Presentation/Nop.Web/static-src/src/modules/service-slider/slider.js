

	$('.slider.categories').each(function () {
		$(this).slick({
			dots: true,
			infinite: false,
			speed: 300,
			swipeToSlide:true,
			prevArrow: '<span class="prev"><i class="icon fas fa-chevron-left"></i></span>',
			nextArrow: '<span class="next"><i class="icon fas fa-chevron-right"></i></span>',
			appendArrows: $(this).closest('.service-slider').find('.slider__nav'),
			appendDots: $(this).closest('.service-slider').find('.slider__nav'),
			slidesPerRow: 3,
			rows: 2,
			responsive: [{
				breakpoint: 1280,
				settings: {
					slidesPerRow: 2
				}
			},{
				breakpoint: 960,
				settings: {
					slidesPerRow: 1
				}
			}]
		});
	});



	$('#techiciansSlider').each(function () {
		$(this).slick({
			dots: true,
			infinite: false,
			speed: 300,
			swipeToSlide:true,
			prevArrow: '<span class="prev"><i class="icon fas fa-chevron-left"></i></span>',
			nextArrow: '<span class="next"><i class="icon fas fa-chevron-right"></i></span>',
			appendArrows: $(this).closest('.service-slider').find('.slider__nav'),
			appendDots: $(this).closest('.service-slider').find('.slider__nav'),
			slidesPerRow: 3,
			rows: 2,
			responsive: [{
				breakpoint: 1280,
				settings: {
					slidesPerRow: 2
				}
			},{
				breakpoint: 960,
				settings: {
					slidesPerRow: 1
				}
			}]
		});
	});

