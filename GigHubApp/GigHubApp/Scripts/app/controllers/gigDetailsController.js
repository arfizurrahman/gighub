var GigDetailsController = function (followingService) {
    var followButton;

    var init = function () {
        $(".js-toggle-follow").click(toggleFollowing);
    };

    var toggleFollowing = function (e) {
        followButton = $(e.target);

        var followId = followButton.attr("data-user-id");

        if (followButton.hasClass("btn-default"))
            followingService.createFollowing(followId, done, fail);
        else
            followingService.deleteFollowing(followId, done, fail);

    };

    var done = function () {
        var text = (followButton.text().trim() == "Follow") ? "Following" : "Follow";
        followButton.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    var fail = function () {
        alert("Something went wrong");
    };

    return {
        init: init
    }
}(FollowingService);