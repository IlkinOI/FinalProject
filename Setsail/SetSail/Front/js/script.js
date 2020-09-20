$(document).ready(function () {

    // NAVBAR //

    var language = $(".commons .rightCommon .language .nav-item");
    var navdrop = $(".myNavbar .navWrapper .collapse .nav-item");

    language.mouseenter(function () {
        $(this).addClass("show");
        $(this).children().eq(0).attr("aria-expanded", true);
        $(this).children().eq(1).addClass("show");
    })

    language.mouseleave(function () {
        $(this).removeClass("show");
        $(this).children().eq(0).attr("aria-expanded", false);
        $(this).children().eq(1).removeClass("show");
    })


    $(window).scroll(function () {
        if ($(document).scrollTop() > 600) {
            $(".myNavbar").addClass("makeFixed");
        } else {
            $(".myNavbar").removeClass("makeFixed");
        }
    });

    navdrop.mouseenter(function () {
        $(this).addClass("show");
        $(this).children().eq(0).attr("aria-expanded", true);
        $(this).children().eq(1).addClass("show");
        $()
    })

    navdrop.mouseleave(function () {
        $(this).removeClass("show");
        $(this).children().eq(0).attr("aria-expanded", false);
        $(this).children().eq(1).removeClass("show");
    })



    // TOP SCROLL // 


    $(window).scroll(function () {
        if ($(document).scrollTop() > 500) {
            $("#toTop .toTopWrapper").css({
                "transform": "scale(1)"
            })
        } else {
            $("#toTop .toTopWrapper").css({
                "transform": "scale(0)"
            })
        }
    });


    var toTopSetInterval;
    $("#toTop .toTopWrapper").click(function () {
        toTopSetInterval = setInterval(toTop, 1);
    })

    function toTop() {
        var docTop = $(document).scrollTop();
        $(document).scrollTop(docTop - 100);

        if (docTop <= 0) {
            clearInterval(toTopSetInterval)
        }
    }


    // login  //

    $("#Log span i").click(function () {
        $("#Log").fadeOut(400);

    });

    $(".myNavbar .navbar .use .user a i").click(function () {
        $("#Log").css("display", "block").fadeIn(400);
    });

    $("#barRes .use .user a i").click(function () {
        $("#Log").css("display", "block").fadeIn(400);

    });
    $("#barResD .use .user a i").click(function () {
        $("#Log").css("display", "block").fadeIn(400);

    });

    // log reg//

    var logView = $("#Log .wrapper .log");
    var regView = $("#Log .wrapper .reg");
    var log = $("#Log .wrapper .nav .nav-item .login");
    var reg = $("#Log .wrapper .nav .nav-item .register");

    log.click(function () {
        log.addClass("active");
        reg.removeClass("active");
        regView.css({
            "display": "none"
        });
        logView.css({
            "display": "block"
        });
    });
    reg.click(function () {
        reg.addClass("active");
        log.removeClass("active");
        logView.css({
            "display": "none"
        });
        regView.css({
            "display": "block"
        });

    });

    // nav search //

    $("#navSearch span i").click(function () {
        $("#navSearch").fadeOut(400);
    });

    $(".myNavbar .navbar .use .search").click(function () {
        $("#navSearch").css("display", "block").fadeIn(400);
    });

    $("#barRes .use .search").click(function () {
        $("#navSearch").css("display", "block").fadeIn(400);

    });
    $("#barResD .use .search").click(function () {
        $("#navSearch").css("display", "block").fadeIn(400);

    });

    

    // INTRO CAROUSEL //

    var owl1;
    owl1 = $('#intro .introCarousel .owl-carousel').owlCarousel({
        loop: true,
        nav: true,
        autoplay: true,
        dots: false,
        responsive: {
            0: {
                items: 1
            }
        }
    })

    var deact = ("#intro .item .owl-item")
    var act = ("#intro .item .owl-item.active");
    var img1 = $("#intro .item .sliderWrapper .img1");
    var img2 = $("#intro .item .sliderWrapper .img2");
    var UT = $("#intro .item .sliderWrapper .upperTitle");
    var title = $("#intro .item .sliderWrapper .title");
    var text = $("#intro .item .sliderWrapper .text");

    function animStart() {
        img1.animate({
            "width": "105%",
            "height": "105%",
        }, 4900),
            img2.css({
                "animation-name": "animimg2",
                "animation-duration": "10.2s",
                "animation-iteration-count": "infinite"
            })
        UT.animate({
            top: "90px",
            opacity: 1
        }, 500)

        title.animate({
            top: "150px",
            opacity: 1
        }, 700)

        text.animate({
            top: "270px",
            opacity: 1
        }, 900)
    }

    function animCut() {
        img1.animate({
            width: "100%",
            height: "100%",
        }, 0),
            UT.css({
                "top": "130px",
                "opacity": 0
            })

        title.css({
            "top": "190px",
            "opacity": 0
        })

        text.css({
            "top": "310px",
            "opacity": 0
        })
    }

    if (owl1.on('translate.owl.carousel')) {
        img1.animate({
            "width": "105%",
            "height": "105%",
        }, 4900),
            UT.animate({
                top: "90px",
                opacity: 1
            }, 500)

        title.animate({
            top: "150px",
            opacity: 1
        }, 700)

        text.animate({
            top: "270px",
            opacity: 1
        }, 900)
    }
    owl1.on('translate.owl.carousel', function () {
        animCut(deact)
        animStart(act);
    })

    // popup //

    $("#popupHome .videoWrapper .icon i").click(function () {
        $("#popupHome").fadeOut(400);
        var videoSrc = $("#popupHome .popupVideo iframe").attr("src");
        $("#popupHome .popupVideo iframe").attr("src", videoSrc);

    });

    $("#parallaxCities .video .icon").click(function () {
        $("#popupHome").css("display", "flex").fadeIn(400);
    });


    // winter owl carousel//

    var owl2;
    owl2 = $('#winter .winterCarousel .owl-carousel').owlCarousel({
        dots: true,
        loop: true,
        nav: false,
        dotsEach: false,
        margin: 10,
        autoplay: true,
        responsive: {
            0: {
                items: 1,
            },
            720: {
                items: 2,
            },
            992:{
                items: 3,
            },
            1000: {
                items: 4
            }
        },
    })

    // owl testmonial //

    var owl3;
    owl3 = $('#testmonial .review .owl-carousel').owlCarousel({
        loop: true,
        nav: true,
        autoplay: true,
        dots: false,
        responsive: {
            0: {
                items: 1
            }
        }
    })

    // owl reviews //

    var owl4;
    owl4 = $('#parallaxReviews .reviewsCarousel .owl-carousel').owlCarousel({
        dots: true,
        loop: true,
        nav: false,
        dotsEach: false,
        margin: 10,
        autoplay: false,
        responsive: {
            0: {
                items: 1,
            },
            720: {
                items: 2,
            },
            992:{
                items: 3,
            }
        },
    })

    // search//

    var switchDate = $("#searchPage .nav .byDate");
    var switchHigh = $("#searchPage .nav .byHigh");
    var switchLow = $("#searchPage .nav .byLow");
    var switchName = $("#searchPage .nav .byName");

    switchDate.click(function () {
        switchDate.children().addClass("active");
        switchDate.siblings().children().removeClass("active");
    });
    switchHigh.click(function () {
        switchHigh.children().addClass("active");
        switchHigh.siblings().children().removeClass("active");
    });
    switchLow.click(function () {
        switchLow.children().addClass("active");
        switchLow.siblings().children().removeClass("active");
    });
    switchName.click(function () {
        switchName.children().addClass("active");
        switchName.siblings().children().removeClass("active");
    });

    // ABOUT //

    // video //

    $("#popupAbout .videoWrapper .icon i").click(function () {
        $("#popupAbout").fadeOut(400);
        var videoSrc = $("#popupAbout .popupVideo iframe").attr("src");
        $("#popupAbout .popupVideo iframe").attr("src", videoSrc);

    });

    $("#video .icon").click(function () {
        $("#popupAbout").css("display", "flex").fadeIn(400);
    });

    // our team //

    var team = $("#ourTeam .team")
    var info = $("#ourTeam .team .info")

    team.mouseover(function () {
        $(this).children(info).removeClass("disappear");
        $(this).children(info).addClass("appear");
    });
    team.mouseleave(function () {
        $(this).children(info).removeClass("appear");
        $(this).children(info).addClass("disappear");
    });

    //  WINTER //

    // intro winter//

    var owl5;
    owl5 = $('#introWinter .introCarousel .owl-carousel').owlCarousel({
        loop: true,
        nav: true,
        autoplay: true,
        dots: false,
        responsive: {
            0: {
                items: 1
            }
        }
    })

    var deactWinter = ("#introWinter .item .owl-item")
    var actWinter = ("#introWinter .item .owl-item.active");
    var img1Winter = $("#introWinter .item .sliderWrapper .img1");
    var img2Winter = $("#introWinter .item .sliderWrapper .img2");
    var UTWinter = $("#introWinter .item .sliderWrapper .upperTitle");
    var titleWinter = $("#introWinter .item .sliderWrapper .title");
    var textWinter = $("#introWinter .item .sliderWrapper .text");

    function animStartWinter() {
        img1Winter.animate({
            "width": "105%",
            "height": "105%",
        }, 4900),
            img2Winter.css({
                "animation-name": "animimg2Winter",
                "animation-duration": "11s",
                "animation-iteration-count": "infinite"
            })
        UTWinter.animate({
            top: "90px",
            opacity: 1
        }, 500)

        titleWinter.animate({
            top: "150px",
            opacity: 1
        }, 700)

        textWinter.animate({
            top: "270px",
            opacity: 1
        }, 900)
    }

    function animCutWinter() {
        img1Winter.animate({
            width: "100%",
            height: "100%",
        }, 0),
            UTWinter.css({
                "top": "130px",
                "opacity": 0
            })

        titleWinter.css({
            "top": "190px",
            "opacity": 0
        })

        textWinter.css({
            "top": "310px",
            "opacity": 0
        })
    }

    if (owl5.on('translate.owl.carousel')) {
        img1Winter.animate({
            "width": "105%",
            "height": "105%",
        }, 4900),
            UTWinter.animate({
                top: "90px",
                opacity: 1
            }, 500)

        titleWinter.animate({
            top: "150px",
            opacity: 1
        }, 700)

        textWinter.animate({
            top: "270px",
            opacity: 1
        }, 900)
    }
    owl5.on('translate.owl.carousel', function () {
        animCutWinter(deactWinter)
        animStartWinter(actWinter);
    })

    // owl winter // 

    var owl6;
    owl6 = $('#WinterItemsCarousel .winterCarousel .owl-carousel').owlCarousel({
        dots: true,
        loop: true,
        nav: false,
        dotsEach: false,
        margin: 10,
        autoplay: true,
        responsive: {
            0: {
                items: 1,
            },
            720: {
                items: 2,
            },
            992:{
                items: 3,
            },
            1000: {
                items: 4
            }
        },
    })

    // winter video //

    $("#popupWinter .videoWrapper .icon i").click(function () {
        $("#popupWinter").fadeOut(400);
        var videoSrc = $("#popupWinter .popupVideo iframe").attr("src");
        $("#popupWinter .popupVideo iframe").attr("src", videoSrc);

    });

    $("#videoWinter .video .icon").click(function () {
        $("#popupWinter").css("display", "flex").fadeIn(400);
    });

    // owl winter reviews//

    var owl7;
    owl7 = $('#parallaxReviewsWinter .reviewsCarousel .owl-carousel').owlCarousel({
        dots: true,
        loop: true,
        nav: false,
        dotsEach: false,
        margin: 10,
        autoplay: true,
        responsive: {
            0: {
                items: 1,
            },
            720: {
                items: 2,
            },
            992:{
                items: 3,
            }
        },
    })

    // our team winter//

    var teamWinter = $("#ourTeamWinter .team")
    var infoWinter = $("#ourTeamWinter .team .info")

    teamWinter.mouseover(function () {
        $(this).children(infoWinter).removeClass("disappearWinter");
        $(this).children(infoWinter).addClass("appearWinter");
    });
    teamWinter.mouseleave(function () {
        $(this).children(infoWinter).removeClass("appearWinter");
        $(this).children(infoWinter).addClass("disappearWinter");
    });


    //SUMMER//

    $("#parallaxSummer .video .icon").click(function () {
        $("#popupHome").css("display", "flex").fadeIn(400);
    });

    // CITIES // 

    // team //

    var teamCities = $("#ourTeamCities .team")
    var infoCities = $("#ourTeamCities .team .info")

    teamCities.mouseover(function () {
        $(this).children(infoCities).removeClass("disappearCities");
        $(this).children(infoCities).addClass("appearCities");
    });
    teamCities.mouseleave(function () {
        $(this).children(infoCities).removeClass("appearCities");
        $(this).children(infoCities).addClass("disappearCities");
    });

    // WINE //

    var owl8;
    owl8 = $('#introWine .introCarousel .owl-carousel').owlCarousel({
        loop: true,
        nav: true,
        autoplay: true,
        dots: false,
        responsive: {
            0: {
                items: 1
            }
        }
    })

    var deactWine = ("#introWine .item .owl-item")
    var actWine = ("#introWine .item .owl-item.active");
    var titleWine = $("#introWine .item .sliderWrapper .title");

    function animStartWine() {
        titleWine.animate({
            top: "255px",
            opacity: 1
        }, 700)
    }

    function animCutWine() {
        titleWine.css({
            "top": "295px",
            "opacity": 0
        })
    }

    if (owl8.on('translate.owl.carousel')) {

        titleWine.animate({
            top: "255px",
            opacity: 1
        }, 700)
    }
    owl8.on('translate.owl.carousel', function () {
        animCutWine(deactWine)
        animStartWine(actWine);
    })

    // video wine //

    $("#popupWine .videoWrapper .icon i").click(function () {
        $("#popupWine").fadeOut(400);
        var videoSrc = $("#popupWine .popupVideo iframe").attr("src");
        $("#popupWine .popupVideo iframe").attr("src", videoSrc);

    });

    $("#videoWine .video .icon").click(function () {
        $("#popupWine").css("display", "flex").fadeIn(400);
    });

    // wine counter //

    $("#Counter .count").counterUp({
        delay: 10,
        time: 1000,
    });

    // wine counter//

    $(".num").counterUp({
        delay: 10,
        time: 1000,
    });

    // progress bar//

    var delay = 1000;

    $(".progress-bar").each(function (i) {
        $(this).delay(delay * i).animate({
            width: $(this).attr('aria-valuenow') + '%'
        }, delay);

        $(this).prop('Counter', 0).animate({
        }, {
            duration: delay,
            // easing: 'swing',
            step: function (now) {
                $(this).text(Math.ceil(now) + '%');
            }
        });
    });

    

    // destionation navbar //

    $("#barRes .icons i").click(function () {
        $("#barRes").fadeOut(400);

    });

    $("#navBarRes .menu i").click(function () {
        $("#barRes").css("display", "unset").fadeIn(400);
    });

    $("#barResD .icons i").click(function () {
        $("#barResD").fadeOut(400);

    });

    $("#navBarResD .menu i").click(function () {
        $("#barResD").css("display", "unset").fadeIn(400);
    });


    // destination carousel//

    owl6 = $('#DestinationsCarousel .desCarousel .owl-carousel').owlCarousel({
        dots: false,
        loop: true,
        nav: false,
        dotsEach: false,
        autoplay: true,
        touchDrag: true,
        mouseDrag: true,
        responsive: {
            0: {
                items: 1,
            },
            576: {
                items: 2,
            },
            720: {
                items: 3,
            },
            992:{
                items: 4,
            }
        },
    })

    // blog detail reply //

    var replyButton = $("#myBlog .blog .accordion .card .collapse .card-body .comContent .rep");
    var cancelButton = $("#myBlog .blog .accordion .card .collapse .card-body .comContent .cancel");
    var comment = $("#myBlog .blog .comment");
    var replyComment = $("#myBlog .blog .replyComment");

    replyButton.click(function () {
        replyButton.addClass("hideSpan");
        replyButton.removeClass("showSpan");
        cancelButton.addClass("showSpan");
        cancelButton.removeClass("hideSpan");

        comment.removeClass("showComment");
        comment.addClass("hideComment");
        replyComment.addClass("showComment");
        replyComment.removeClass("hideComment");
    });
    cancelButton.click(function () {
        cancelButton.addClass("hideSpan");
        cancelButton.removeClass("showSpan");
        replyButton.addClass("showSpan");
        replyButton.removeClass("hideSpan");

        comment.removeClass("hideComment");
        comment.addClass("showComment");
        replyComment.addClass("hideComment");
        replyComment.removeClass("showComment");
    });


    // tour datepicker //

    // $("#datepicker").datepicker({
    //     dateFormat: "dd/mm/yy",
    //     changeMonth: true,
    //     changeYear: true,
    //     yearRange: "-20:+2"
    // });

    // TOUR SWITCH//

    var infoView = $("#myTour .information");
    var tourView = $("#myTour .tourPlan");
    var locView = $("#myTour .tourLocation");
    var galView = $("#myTour .tourGallery");
    var revView = $("#myTour .setReviews");

    var switchInfo = $("#Switch .wrapper .nav .infor");
    var switchPlan = $("#Switch .wrapper .nav .plan");
    var switchLoc = $("#Switch .wrapper .nav .loc");
    var switchGal = $("#Switch .wrapper .nav .gal");
    var switchRev = $("#Switch .wrapper .nav .rev");

    switchInfo.click(function () {
        switchInfo.addClass("active");
        switchInfo.siblings().removeClass("active");
        infoView.siblings().css({
            "display": "none"
        });
        infoView.css({
            "display": "block"
        });
    });
    switchPlan.click(function () {
        switchPlan.addClass("active");
        switchPlan.siblings().removeClass("active");
        tourView.siblings().css({
            "display": "none"
        });
        tourView.css({
            "display": "block"
        });
    });
    switchLoc.click(function () {
        switchLoc.addClass("active");
        switchLoc.siblings().removeClass("active");
        locView.siblings().css({
            "display": "none"
        });
        locView.css({
            "display": "block"
        });
    });
    switchGal.click(function () {
        switchGal.addClass("active");
        switchGal.siblings().removeClass("active");
        galView.siblings().css({
            "display": "none"
        });
        galView.css({
            "display": "block"
        });
    });
    switchRev.click(function () {
        switchRev.addClass("active");
        switchRev.siblings().removeClass("active");
        revView.siblings().css({
            "display": "none"
        });
        revView.css({
            "display": "block"
        });
    });
    var grid = $("#myTour .tourLocation .grid");
    grid.children().eq(0).addClass("grid-item--width3");
    grid.children().eq(5).addClass("grid-item--height3");
    grid.children().eq(8).addClass("grid-item--width3");
    
    var sortByDate = $("#searchPage .byDate");
    var sortByPriceHigh = $("#searchPage .byHigh");
    var sortByPriceLow = $("#searchPage .byLow");
    var byname = $("#searchPage .byName");
    var main = $("#searchPage .toursContent");
    var tour = $("#searchPage .toursContent .sort");
    sortByDate.on("click", function () {

        tour.sort(function (a, b) {
            return ($(a).data("date") > $(b).data("date")) ? 1 : -1;
        });

        main.empty();

        $.each(tour, function () {
            main.append(tour);
        });
    });
    sortByPriceHigh.on("click", function () {
        tour.sort(function (a, b) {

            return ($(a).data("price") < $(b).data("price")) ? 1 : -1;
        });

        main.empty();

        $.each(tour, function () {
            main.append(tour);
        });
    });
    sortByPriceLow.on("click", function () {
        tour.sort(function (a, b) {

            return ($(a).data("price") > $(b).data("price")) ? 1 : -1;
        });

        main.empty();

        $.each(tour, function () {
            main.append(tour);
        });
    });
    byname.on("click", function () {
        tour.sort(function (a, b) {

            return ($(a).data("name") < $(b).data("name")) ? 1 : -1;
        });

        main.empty();

        $.each(tour, function () {
            main.append(tour);
        });
    });

});
