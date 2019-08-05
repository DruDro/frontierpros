"use strict";var _this=void 0;//---------------------------------------//
// свг спрайт
//---------------------------------------//
//---------------------------------------//
// Подключаем набор плагинов ( require/plugins.js )
//---------------------------------------//
//  bower
//---------------------------------------//
//---------------------------------------//
//  npm
//---------------------------------------//
//---------------------------------------//
// ( plugins )
//---------------------------------------//
//---------------------------------------//
// Подключаем набор написаных скриптов (require/developRequire.js)
//---------------------------------------//
//---------------------------------------//
// Подключаем скрипты компонентов страниц ( modules )
//---------------------------------------//
//---------------------------------------//
// Подключаем основные скрипты ( develop )
//---------------------------------------//
$(function(){var tabContainers=$('.js-tab-cont'),links='.js-tab-link',active='tab__link--active',initialTab='';if($('.'+active).length){if($('.'+active)[0].hash){initialTab=$('.'+active)[0].hash;}else{initialTab="[data-id=\""+$('.'+active).data('tab')+"\"]";}}else{initialTab=':first';}tabContainers.not(initialTab).hide();$(links).click(function(e){var tab=this.hash?{hash:this.hash}:{hash:$(this).data('tab'),dataAttr:true};e.preventDefault();if(tabContainers.is(':animated')){return false;}tabContainers.hide();if(!$(this).hasClass(active)){$(links).removeClass(active);if(tab.dataAttr){tabContainers.filter('[data-id="'+tab.hash+'"]').show();$('[data-tab="'+tab.hash+'"]').addClass(active);}else{tabContainers.filter(tab.hash).show();$('[href="'+tab.hash).addClass(active);}}else{if(tab.dataAttr){tabContainers.filter('[data-id="'+tab.hash+'"]').hide();}else{tabContainers.filter(tab.hash).hide();}$(links).removeClass(active);}return false;});});$(function(){var $dropdownLinks=$('.js-dropdown'),$dropdownConts=$('.js-dropdown-cont');$dropdownConts.hide();$('.js-dropdown').click(function(e){e.preventDefault();var $dropdownLink=$(this),$dropdownCont=this.has?$(this.hash):$(this).next('.js-dropdown-cont');if(!$dropdownCont.hasClass('dropped')){$dropdownCont.fadeIn(300).addClass('dropped');$dropdownLink.addClass('dropped');}else{$dropdownCont.fadeOut(300).removeClass('dropped');$dropdownLink.removeClass('dropped');}$dropdownConts.not($dropdownCont).fadeOut(300).removeClass('dropped');$dropdownLinks.not($dropdownLink).removeClass('dropped');$(window).resize();return false;});$(document).on('mouseup touchend',function(e){if(!$(e.target).closest('.dropdown, .dropdown *, js-dropdown').length){$dropdownConts.fadeOut(300).removeClass('dropped');$dropdownLinks.removeClass('dropped');}});// $('select').select2();
});$(function(){var $popups=$('.popup'),$wrapper=$('<div class="popup-wrapper"></div>'),$closeBtn=$('<a href="#" class="btn--close js-popup-close icon"><svg><use xlink:href="#close"/></svg></a>');$popups.hide();$(document).on("mouseup touchend",'.js-popup',function(e){e.preventDefault();var $popup=$(this.hash||$(this).data('popup')),$closePos=$popup.data('close');if($popup.parent('.popup-wrapper').length==0){$popup.wrap($wrapper);if($closePos=='wrapper'){$('.popup-wrapper').append($closeBtn);}else if($closePos=='popup'){$popup.prepend($closeBtn);}$('body, html').addClass('noscroll');$popup.closest('.popup-wrapper').hide().fadeIn(300);$popup.fadeIn(300);$(window).resize();}});$(document).on("mouseup touchend",".js-popup-close",function(e){e.preventDefault();var $poplink=$(this);$poplink.closest('.popup-wrapper').fadeOut(300);$('body, html').removeClass('noscroll');setTimeout(function(){$poplink.closest('.popup').hide().unwrap('.popup-wrapper');$poplink.closest('.popup-wrapper').find('.btn--close').remove();},300);});$(document).on('mouseup touchend',function(e){if(!$(e.target).closest('.popup, .popup *, js-popup-close, .js-popup, label').length){$('.popup-wrapper').fadeOut(300);$('body, html').removeClass("noscroll");setTimeout(function(){$('.popup-wrapper').find('.btn--close').remove();$('.popup-wrapper').find('.popup').hide().unwrap('.popup-wrapper');},300);}});window.addEventListener('touchmove',function(e){if($(e.target).hasClass('noscroll')){e.preventDefault();}});});$(function(){function scrollAnhor(){var $links=$('.js-anchor');$links.on('click',function(e){e.preventDefault();if($(this.hash).length){$('html,body').animate({scrollTop:$(this.hash).offset().top},1000);}});}scrollAnhor();});$(window).resize(function(){});$(window).resize(function(){stickFooter();$('.slider').each(function(i,item){if($(item).hasClass('slick-initialized')){var curSlide=$(item).slick('slickCurrentSlide');$(item).slick('slickGoTo',curSlide);}});});$(window).on("load",function(){stickFooter();$('select').select2({minimumResultsForSearch:Infinity});});var stickFooter=function stickFooter(){var fh=$('.footer').outerHeight();$('body').css("padding-bottom",fh);console.log(fh);};$('.footer .mob-collapse').click(function(){$('.footer .mob-collapse').not(this).removeClass('expanded').next('ul').slideUp(150);$(this).toggleClass('expanded');$(this).next('ul').slideToggle(150);setTimeout(stickFooter,150);});$(document).on("click touchend",function(e){if(!$(e.target).closest('#menuToggle').length&&!$(e.target).closest('#menuClose').length&&!$(e.target).closest('.mobile-menu').length){$('.mobile-menu').removeClass('active');$('#mobMenuOverlay').removeClass('active');}else if($(e.target).closest('#menuToggle').length){e.preventDefault();$('.mobile-menu').toggleClass('active');$('#mobMenuOverlay').toggleClass('active');}else if($(e.target).closest('#menuClose').length){e.preventDefault();$('.mobile-menu').removeClass('active');$('#mobMenuOverlay').removeClass('active');}});$(function(){var howSliderIsRunning=false;var initHowSlider=function initHowSlider(){$('.how__tabs ol').slick({dots:true,infinite:false,speed:300,swipeToSlide:true,mobileFirst:true,prevArrow:'<span class="prev"><i class="icon fas fa-chevron-left"></i></span>',nextArrow:'<span class="next"><i class="icon fas fa-chevron-right"></i></span>',slide:'.tablet-slide',slidesToShow:1,slidesToScroll:1,appendArrows:$('.how__tabs .slider__nav'),appendDots:$('.how__tabs .slider__nav'),responsive:[{breakpoint:1024,settings:"unslick"}]});};initHowSlider();$(window).resize($.debounce(750,function(){if($(window).width()<1024&&howSliderIsRunning==false){initHowSlider();$('.how__tabs ol').slick('slickGoTo',0);howSliderIsRunning=true;}else{howSliderIsRunning=false;}}));});// const hasMap = document.getElementById('map');
// 		let map;
// 		let popupTripMap;
// 		let popupVehicleMap;
// 		if (hasMap) {
// 			// 'app_id': 'r4f2w5bhgQh9ElQMM3Y5',
// 			// 'app_code': '5DVJiDzmc1JVq3eMZXoXEw'
// 			const moveMapTo = map => { // Berlin
// 				map.setCenter({
// 					lat: 52.5159,
// 					lng: 13.3777
// 				});
// 				map.setZoom(14);
// 			}
// 			//Step 1: initialize communication with the platform
// 			const platform = new H.service.Platform({
// 				app_id: 'DemoAppId01082013GAL',
// 				app_code: 'AJKnXv84fjrb0KIHawS0Tg',
// 				useCIT: true,
// 				useHTTPS: true
// 			});
// 			const pixelRatio = window.devicePixelRatio || 1;
// 			const defaultLayers = platform.createDefaultLayers({
// 				tileSize: pixelRatio === 1 ? 256 : 512,
// 				ppi: pixelRatio === 1 ? undefined : 320
// 			});
// 			//Step 2: initialize a map  - not specificing a location will give a whole world view.
// 			map = new H.Map(document.getElementById('map'), defaultLayers.normal.map, {
// 				pixelRatio
// 			});
// 			popupTripMap = new H.Map(document.getElementById('popupTripMap'), defaultLayers.normal.map, {
// 				pixelRatio
// 			});
// 			popupVehicleMap = new H.Map(document.getElementById('popupVehicleMap'), defaultLayers.normal.map, {
// 				pixelRatio
// 			});
// 			//Step 3: make the map interactive
// 			// MapEvents enables the event system
// 			// Behavior implements default interactions for pan/zoom (also on mobile touch environments)
// 			const mapBehavior = new H.mapevents.Behavior(new H.mapevents.MapEvents(map));
// 			mapBehavior.disable(H.mapevents.Behavior.WHEELZOOM);
// 			const popupTripMapBehavior = new H.mapevents.Behavior(new H.mapevents.MapEvents(popupTripMap));
// 			popupTripMapBehavior.disable(H.mapevents.Behavior.WHEELZOOM);
// 			const popupVehicleMapBehavior = new H.mapevents.Behavior(new H.mapevents.MapEvents(popupVehicleMap));
// 			popupVehicleMapBehavior.disable(H.mapevents.Behavior.WHEELZOOM);
// 			// Create the default UI components
// 			const mapUi = H.ui.UI.createDefault(map, defaultLayers);
// 			const popupTripMapBehaviorUi = H.ui.UI.createDefault(popupTripMap, defaultLayers);
// 			const popupVehicleMapBehaviorUi = H.ui.UI.createDefault(popupVehicleMap, defaultLayers);
// 			// Now use the map as required...
// 			moveMapTo(map);
// 			moveMapTo(popupTripMap);
// 			moveMapTo(popupVehicleMap);
// 			$(window).resize(function () {
// 				map.getViewPort().resize();
// 				popupTripMap.getViewPort().resize();
// 				popupVehicleMap.getViewPort().resize();
// 			}).resize();
// 		}
var setLocation=function setLocation(el){$('#searchLocation').val(el.value);};$('#locationInputPopup').change(function(){var val=_this.value;console.log(val);});$('#radius').slider({value:20,min:1,max:120,create:function create(){var $slider=$(this);$slider.prepend('<span class="ui-slider-amount"></span>');$(this).find('.ui-slider-amount').css({"width":$(this).find('.ui-slider-handle').get(0).style.left});},slide:function slide(){$('#radiusVal').text($(this).slider('value')+' km from you');$(this).find('.ui-slider-amount').css({"width":$(this).find('.ui-slider-handle').get(0).style.left});},stop:function stop(){$('#radiusVal').text($(this).slider('value')+' km from you');$(this).find('.ui-slider-amount').css({"width":$(this).find('.ui-slider-handle').get(0).style.left});}});function showSearch(e){e.preventDefault();var $target=window.innerWidth>768?$('#searchResults'):$('#searchResultsMob');$target.slideDown(150);$('.slider.technicians').each(function(){$(this).slick({dots:true,infinite:true,speed:300,prevArrow:'<span class="prev"><i class="icon fas fa-chevron-left"></i></span>',nextArrow:'<span class="next"><i class="icon fas fa-chevron-right"></i></span>',slide:'.slide',focusOnSelect:true,centerMode:true,centerPadding:'0',slidesToShow:3,slidesToScroll:1,appendArrows:$('#searchResultsSlider .slider__nav'),appendDots:$('#searchResultsSlider .slider__nav'),responsive:[{breakpoint:1280,settings:{slidesToShow:2,centerMode:false}},{breakpoint:960,settings:{slidesToShow:1}}]});});$('html,body').animate({scrollTop:$target.offset().top},1000);}$('.slider.services').each(function(){$(this).slick({dots:true,infinite:false,speed:300,swipeToSlide:true,prevArrow:'<span class="prev"><i class="icon fas fa-chevron-left"></i></span>',nextArrow:'<span class="next"><i class="icon fas fa-chevron-right"></i></span>',slide:'.slide',slidesToShow:6,slidesToScroll:6,appendArrows:$(this).closest('.service-slider').find('.slider__nav'),appendDots:$(this).closest('.service-slider').find('.slider__nav'),responsive:[{breakpoint:1840,settings:{slidesToShow:4,slidesToScroll:4}},{breakpoint:1280,settings:{slidesToShow:3,slidesToScroll:3}},{breakpoint:960,settings:{slidesToShow:2,slidesToScroll:2}},{breakpoint:768,settings:{slidesToShow:1,slidesToScroll:1}}]});});$('#categories').slick({dots:true,infinite:false,speed:300,swipeToSlide:true,prevArrow:'<span class="prev"><i class="icon fas fa-chevron-left"></i></span>',nextArrow:'<span class="next"><i class="icon fas fa-chevron-right"></i></span>',appendArrows:$('#categoriesSlider .slider__nav'),appendDots:$('#categoriesSlider .slider__nav'),slidesPerRow:3,rows:2,responsive:[{breakpoint:1280,settings:{slidesPerRow:2}},{breakpoint:960,settings:{slidesPerRow:1}}]});