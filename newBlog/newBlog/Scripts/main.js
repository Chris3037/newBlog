$(document).ready(function () {
    //$('#nav2').on('mouseenter', function () {
    //    $('.nav2Items').fadeIn();
    //});
    //$('#nav2').on('mouseleave', function () {
    //    $('.nav2Items').fadeOut();
    //});

    $('.likes').on('click', function () {
        var id = $(this).data('id');
        var postLikes = $(this);
        $.get('/home/like/' + id, function (data) {
            $(postLikes.parent().html(data));
        });
    });

    $('.showComments').on('click', function () {
        $(this).parent().find('.comments').slideToggle();
    });

    $('.commentForm').on('submit', function (event) {
        //Stop form from submitting
        event.preventDefault();
        var id = $(this).data('id');
        var theForm = $(this);
        //$(this).serialize() sends the data
        $.post('/Home/AddComment/' + id, $(this).serialize(), function (data) {
            $(theForm).parent().html(data);
        });
    });
});