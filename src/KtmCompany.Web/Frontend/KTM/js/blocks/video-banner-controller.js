export function videoBannerController() {
    //control the video banner player
    //select video player in VideoBannerBlock
    var video = $("#videoBanner")[0],
        //get current playing time
        currentTime = 0;
    if (video != undefined) {
        var currentVideoSource = video.src;
        video.onclick = function() {
            var paused = this.paused;
            if (paused) {
                this.src = currentVideoSource;
                this.load();
                this.currentTime = currentTime;
                this.play();
            } else {
                this.pause();
                currentTime = this.currentTime;
                this.src = "";
            }
        }
        // display poster after finish playing
        video.on("ended", function(){
            this.load();
        });

    }

}
