/* BEGIN EXTERNAL SOURCE */

        $(document).ready(function () {
            var userid = $("#userId").val();
            $.ajax({
                url: '../User/ShowBalance?userid=' + parseInt(userid),
                type: 'GET',
                success: function (data) {

                    console.log("success");
                },
                error: function (error) {
                    console.error("Error occurred: ", error);
                }

            });
        })
    
/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

    ////var UID = /*************/;

        $(document).ready(function () {
            const videos = document.querySelectorAll('.video');

            videos.forEach(video => {
                video.addEventListener('ended', function() {
                    this.currentTime = 0;
                    $(this).attr("watched", "true");
                    $(this).next('.controls').html("<p>Video already watched</p>");
                    var userid = $("#userId").val();
                    var videoid = $(this).attr('id');
                    $.ajax({
                        url: '../User/AddBalance?userid=' + parseInt(userid) + '&videoid=' + videoid,
                        type: 'GET',
                        success: function (data) {

                            console.log("success");
                        },
                        error: function (error) {
                            console.error("Error occurred: ", error);
                        }

                    });
                    this.controls = false; // Disables controls after the video is watched
                });

                video.addEventListener('seeking', function() {
                    this.currentTime = 0;


                });

                video.addEventListener('play', function() {
                    videos.forEach(vid => {
                        if (vid !== video && !vid.paused) {
                            vid.pause();
                        }
                    });
                });
            });

            $(".fullscreen").click(function() {
                const video = $(this).parent().prev('.video')[0];
                if (video.requestFullscreen) {
                    video.requestFullscreen();
                }
            });

            $(".play").click(function() {
                const video = $(this).parent().prev('.video')[0];
                video.play();
            });

            $(".pause").click(function() {
                const video = $(this).parent().prev('.video')[0];
                video.pause();
            });
        });

/* END EXTERNAL SOURCE */
