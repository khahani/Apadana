/*jshint jquery:true */
/*global $:true */

/* ---------------------------------------------------------------------- */
/*jquery steps
/* ---------------------------------------------------------------------- */
$(document).ready(function ($) {
    $("#register-wizard").steps({
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: "none",
        autoFocus: true,
        labels: {
            current: "جاری:",
            pagination: "Pagination",
            finish: "پایان",
            next: "بعدی",
            previous: "قبلی",
            loading: "در حال بارگزاری ..."
        }
    });
});
/* ---------------------------------------------------------------------- */
/* end of jquery steps
/* ---------------------------------------------------------------------- */

/* ---------------------------------------------------------------------- */
/*persian date picker
/* ---------------------------------------------------------------------- */
$(document).ready(function ($) {
    /*
    observer
    */
    $(".persian-date").persianDatepicker({
        altField: '#observerAlt',
        altFormat: "YYYY MM DD HH:mm:ss",
        observer: true,
        format: 'YYYY/MM/DD'
    });
});
/* ---------------------------------------------------------------------- */
/* end of persian date picker
/* ---------------------------------------------------------------------- */

var $ = jQuery.noConflict();

$(document).ready(function($) {
	"use strict";
  /* global DevSolutionSkill: false */ 

	/*-------------------------------------------------*/
	/* =  portfolio isotope
	/*-------------------------------------------------*/

	var winDow = $(window);
		// Needed variables
		var $container=$('.portfolio-box');
		var $filter=$('.filter');

		try{
			$container.imagesLoaded( function(){
				$container.show();
				$container.isotope({
					filter:'*',
					layoutMode:'masonry',
					animationOptions:{
						duration:750,
						easing:'linear'
					}
				});

			});
		} catch(err) {
		}

		winDow.bind('resize', function(){
			var selector = $filter.find('a.active').attr('data-filter');

			try {
				$container.isotope({ 
					filter	: selector,
					animationOptions: {
						duration: 750,
						easing	: 'linear',
						queue	: false,
					}
				});
			} catch(err) {
			}
			return false;
		});
		
		// Isotope Filter 
		$filter.find('a').click(function(){
			var selector = $(this).attr('data-filter');

			try {
				$container.isotope({ 
					filter	: selector,
					animationOptions: {
						duration: 750,
						easing	: 'linear',
						queue	: false,
					}
				});
			} catch(err) {

			}
			return false;
		});


	var filterItemA	= $('.filter li a');

		filterItemA.on('click', function(){
			var $this = $(this);
			if ( !$this.hasClass('active')) {
				filterItemA.removeClass('active');
				$this.addClass('active');
			}
		});

	/*-------------------------------------------------*/
	/* =  fullwidth carousell
	/*-------------------------------------------------*/
	try {
		$.browserSelector();
		// Adds window smooth scroll on chrome.
		if($("html").hasClass("chrome")) {
			$.smoothScroll();
		}
	} catch(err) {

	}
	
	/*-------------------------------------------------*/
	/* =  Scroll to TOP
	/*-------------------------------------------------*/

	var animateTopButton = $('.go-top'),
		htmBody = $('html, body');
		
	animateTopButton.click(function(){
	htmBody.animate({scrollTop: 0}, 'slow');
		return false;
	});

	/*-------------------------------------------------*/
	/* =  remove animation in mobile device
	/*-------------------------------------------------*/
	if ( winDow.width() < 992 ) {
		$('div.triggerAnimation').removeClass('animated');
		$('div.triggerAnimation').removeClass('triggerAnimation');
	}

	/*-------------------------------------------------*/
	/* =  flexslider
	/*-------------------------------------------------*/
	try {

		var SliderPost = $('.flexslider');

		SliderPost.flexslider({
			animation: "fade",
			slideshowSpeed: 3000,
			easing: "swing"
		});
	} catch(err) {

	}

	/*-------------------------------------------------*/
	/* =  skills circle
	/*-------------------------------------------------*/
	
	try{
		DevSolutionSkill.init('circle'); 
		DevSolutionSkill.init('circle2'); 
		DevSolutionSkill.init('circle3'); 
		DevSolutionSkill.init('circle4');
	} catch(err) {
	}
	
	/*-------------------------------------------------*/
	/* =  Animated content
	/*-------------------------------------------------*/

	try {
		/* ================ ANIMATED CONTENT ================ */
        if ($(".animated")[0]) {
            $('.animated').css('opacity', '0');
        }

        $('.triggerAnimation').waypoint(function() {
            var animation = $(this).attr('data-animate');
            $(this).css('opacity', '');
            $(this).addClass("animated " + animation);

        },
                {
                    offset: '85%',
                    triggerOnce: true
                }
        );
	} catch(err) {

	}	

	/* ---------------------------------------------------------------------- */
	/*	magnific-popup
	/* ---------------------------------------------------------------------- */

	try {
		// Example with multiple objects
		$('.zoom').magnificPopup({
			type: 'image',
			gallery: {
				enabled: true
			}
		});
	} catch(err) {

	}

	try {
		// Example with multiple objects
		$('.zoom.video').magnificPopup({
			type: 'iframe',
			gallery: {
				enabled: true
			}
		});
	} catch(err) {

	}

	/* ---------------------------------------------------------------------- */
	/*	Accordion
	/* ---------------------------------------------------------------------- */
	var clickElem = $('a.accord-link');

	clickElem.on('click', function(e){
		e.preventDefault();

		var $this = $(this),
			parentCheck = $this.parents('.accord-elem'),
			accordItems = $('.accord-elem'),
			accordContent = $('.accord-content');
			
		if( !parentCheck.hasClass('active')) {

			accordContent.slideUp(400, function(){
				accordItems.removeClass('active');
			});
			parentCheck.find('.accord-content').slideDown(400, function(){
				parentCheck.addClass('active');
			});

		} else {

			accordContent.slideUp(400, function(){
				accordItems.removeClass('active');
			});

		}
	});

	/* ---------------------------------------------------------------------- */
	/*	Tabs
	/* ---------------------------------------------------------------------- */
	var clickTab = $('.tab-links li a');

	clickTab.on('click', function(e){
		e.preventDefault();

		var $this = $(this),
			hisIndex = $this.parent('li').index(),
			tabCont = $('.tab-content'),
			tabContIndex = $(".tab-content:eq(" + hisIndex + ")");

		if( !$this.hasClass('active')) {

			clickTab.removeClass('active');
			$this.addClass('active');

			tabCont.slideUp(400);
			tabCont.removeClass('active');
			tabContIndex.delay(500).slideDown(400);
			tabContIndex.addClass('active');
		}
	});


	/*-------------------------------------------------*/
	/* = skills animate
	/*-------------------------------------------------*/

	try{

		var skillBar = $('.skills-section');
		skillBar.appear(function() {

			var animateElement = $(".meter > span");
			animateElement.each(function() {
				$(this)
					.data("origWidth", $(this).width())
					.width(0)
					.animate({
						width: $(this).data("origWidth")
					}, 1200);
			});

		});
	} catch(err) {
	}

	/*-------------------------------------------------*/
	/* =  count increment
	/*-------------------------------------------------*/
	try {
		$('.statistic-post').appear(function() {
			$('.timer').countTo({
				speed: 4000,
				refreshInterval: 60,
				formatter: function (value, options) {
					return value.toFixed(options.decimals);
				}
			});
		});
	} catch(err) {

	}
	
	/*-------------------------------------------------*/
	/* = slider Testimonial
	/*-------------------------------------------------*/

	var slidertestimonial = $('.bxslider');
	try{		
		slidertestimonial.bxSlider({
			mode: 'vertical'
		});
	} catch(err) {
	}

	/*-------------------------------------------------*/
	/* =  Shop accordion
	/*-------------------------------------------------*/

	var AccordElement = $('a.accordion-link');

	AccordElement.on('click', function(e){
		e.preventDefault();
		var elemSlide = $(this).parent('li').find('.accordion-list-content');

		if( !$(this).hasClass('active') ) {
			$(this).addClass('active');
			elemSlide.slideDown(200);
		} else {
			$(this).removeClass('active');
			elemSlide.slideUp(200);			
		}
	});

	/* ---------------------------------------------------------------------- */
	/*	Contact Form
	/* ---------------------------------------------------------------------- */

	var submitContact = $('#submit_contact'),
		message = $('#msg');

	submitContact.on('click', function(e){
		e.preventDefault();

		var $this = $(this);
		
		$.ajax({
			type: "POST",
			url: 'contact.php',
			dataType: 'json',
			cache: false,
			data: $('#contact-form').serialize(),
			success: function(data) {

				if(data.info !== 'error'){
					$this.parents('form').find('input[type=text],textarea,select').filter(':visible').val('');
					message.hide().removeClass('success').removeClass('error').addClass('success').html(data.msg).fadeIn('slow').delay(5000).fadeOut('slow');
				} else {
					message.hide().removeClass('success').removeClass('error').addClass('error').html(data.msg).fadeIn('slow').delay(5000).fadeOut('slow');
				}
			}
		});
	});

	/* ---------------------------------------------------------------------- */
	/*	menu responsive
	/* ---------------------------------------------------------------------- */
	var menuClick = $('a.elemadded'),
		navbarVertical = $('.navbar-vertical');
		
	menuClick.on('click', function(e){
		e.preventDefault();

		if( navbarVertical.hasClass('active') ){
			navbarVertical.removeClass('active');
		} else {
			navbarVertical.addClass('active');
		}
	});

	winDow.bind('resize', function(){
		navbarVertical.removeClass('active');
	});

});

function initMap() {
    var uluru = { lat: 36.300535, lng: 59.638443 };
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 18,
        center: uluru
    });
    var marker = new google.maps.Marker({
        position: uluru,
        map: map
    });
    google.maps.event.addListener(marker, 'click', function () {
        var infowindow = new google.maps.InfoWindow({
            content: "مشهد سیمتری طلاب نبش مفتح 3 ساختمان پزشکان صاحب الزمان طبقه اول "
        });
        infowindow.open(map, marker);
    });
}


