$(document).ready(function (e) {

    $("#rightButton").css("right", "0px");

    var button_toggle = true;
    $("#right_tel").mouseover(function () {
        var tip_top;
        var show = $(this).attr('show');
        var hide = $(this).attr('hide');
        tip_top = 65;
        button_toggle = false;
        $("#right_tip").css("top", tip_top).show().find(".flag_" + show).show();
        $(".flag_" + hide).hide();

    }).mouseout(function () {
        button_toggle = true;
        hideRightTip();
    });


    $("#right_tip").mouseover(function () {
        button_toggle = false;
        $(this).show();
    }).mouseout(function () {
        button_toggle = true;
        hideRightTip();
    })

    function hideRightTip() {
        setTimeout(function () {
            if (button_toggle) $("#right_tip").hide();
        }, 500);
    }

    $("#backToTop").click(function () {
        var _this = $(this);
        $('html,body').animate({ scrollTop: 0 }, 500, function () {
            _this.hide();
        });
    });

    $(window).scroll(function (event) {
        var htmlTop = $(document).scrollTop();
        if (htmlTop > 0) {
            $("#backToTop").show();
        } else {
            $("#backToTop").hide();
        }
    });
});