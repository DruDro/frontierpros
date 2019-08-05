
		$('#radius').slider({
			value: 20,
			min: 1,
			max: 120,
			create: function () {
				var $slider = $(this);
				$slider.prepend('<span class="ui-slider-amount"></span>');
				$(this).find('.ui-slider-amount').css({
					"width": $(this).find('.ui-slider-handle').get(0).style.left
				});
			},
			slide: function () {
				$('#radiusVal').text($(this).slider('value') + ' km from you');
				$(this).find('.ui-slider-amount').css({
					"width": $(this).find('.ui-slider-handle').get(0).style.left
				})
			},
			stop: function () {
				$('#radiusVal').text($(this).slider('value') + ' km from you');
				$(this).find('.ui-slider-amount').css({
					"width": $(this).find('.ui-slider-handle').get(0).style.left
				});
			}
		});


function showSearch(e){
	e.preventDefault();
	$('#searchResultsSlider').each(function(){
		$(this).slick({
			dots: true,
			infinite: true,
			speed: 300,
			prevArrow:'<span class="prev"><i class="icon fas fa-chevron-left"></i></span>',
			nextArrow:'<span class="next"><i class="icon fas fa-chevron-right"></i></span>',
			slide:'.slide',
			focusOnSelect:true,
			centerMode:true,
			centerPadding: '0',
			slidesToShow: 3,
			slidesToScroll: 1,	
			appendArrows:$(this).find('.slider__nav'),
			appendDots:$(this).find('.slider__nav'),
			responsive: [
				{
				  breakpoint: 1280,
				  settings: {
					slidesToShow: 2,
					centerMode:false
				  }
				},
				{
				  breakpoint: 960,
				  settings: {
					slidesToShow: 1
				  }
				}
			]  
		});
	});
	let $target = $('#searchResults');
	$target.slideDown(150);
	$('html,body').animate({scrollTop:$target.offset().top}, 1000);
}