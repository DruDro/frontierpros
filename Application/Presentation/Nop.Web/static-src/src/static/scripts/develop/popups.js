$(function(){
    var $popups = $('.popup'),
        $wrapper = $('<div class="popup-wrapper"></div>'),
        $closeBtn = $('<a href="#" class="btn--close js-popup-close icon"><svg><use xlink:href="#close"/></svg></a>');

    $popups.hide();

    $(document).on("mouseup touchend", '.js-popup', function(e) {
        e.preventDefault();

        var $popup = $(this.hash || $(this).data('popup')),
			$closePos = $popup.data('close');
			
        if($popup.parent('.popup-wrapper').length == 0){
            $popup.wrap($wrapper);            

            if ($closePos == 'wrapper') {
                $('.popup-wrapper').append($closeBtn);
            } 
            else if ($closePos == 'popup') {
                $popup.prepend($closeBtn);
            }
            $('body, html').addClass('noscroll');
            $popup.closest('.popup-wrapper').hide().fadeIn(300);
            $popup.fadeIn(300);

            $(window).resize();
        }
    });

    $(document).on("mouseup touchend", ".js-popup-close", function(e) {
        e.preventDefault();
        var $poplink = $(this);
        $poplink.closest('.popup-wrapper').fadeOut(300);
        $('body, html').removeClass('noscroll');
        setTimeout(function() {
            $poplink.closest('.popup').hide().unwrap('.popup-wrapper');
            $poplink.closest('.popup-wrapper').find('.btn--close').remove();
        }, 300);
    });

    $(document).on('mouseup touchend', function(e) {
        if (!$(e.target).closest('.popup, .popup *, js-popup-close, .js-popup, label').length) {
            $('.popup-wrapper').fadeOut(300);
            $('body, html').removeClass("noscroll");
            setTimeout(function() {
                $('.popup-wrapper').find('.btn--close').remove();
                $('.popup-wrapper').find('.popup').hide().unwrap('.popup-wrapper');
            }, 300);            
        }
    });
    
    window.addEventListener( 'touchmove', function(e) {
        if($(e.target).hasClass('noscroll')){
            e.preventDefault();
        }
    })
});