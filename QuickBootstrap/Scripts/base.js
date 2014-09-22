
$(function () {

    //鼠标经过导航栏特效
    $('.navbar-nav li').mouseover(function () {
        $(this).addClass('active').siblings().removeClass('active');
    });

    if ($.support.style == false) {
        alert('你的浏览器已经Out了，赶快升级你的浏览器到Chrome吧！');
        window.open('https://www.google.com/intl/zh-CN/chrome/browser');
    }
    
});