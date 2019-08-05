$(window).resize(()=>{
});
$(window).resize(function () {
	stickFooter();
	$('.slider').each(function (i, item) {
	  if ($(item).hasClass('slick-initialized')) {
		var curSlide = $(item).slick('slickCurrentSlide');
		$(item).slick('slickGoTo', curSlide);
	  }
	});
  });
$(window).on("load",function(){
	stickFooter();
    $('select').select2({minimumResultsForSearch: Infinity});
});
