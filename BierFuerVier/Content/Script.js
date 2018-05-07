function init()
{
    var buttons = document.getElementsByClassName("rating");
    for (var i = 0; i < buttons.length; i++) {
        buttons[i].addEventListener("click", function(){
            var id = this.dataset.id;
            if (this.classList.contains("upvote")) {
                var request = new XMLHttpRequest();
                request.open("POST", "/Home/Upvote");
                request.onreadystatechange = function () {
                    if (request.readyState == XMLHttpRequest.DONE && request.status == 200) {
                        var progress = document.querySelector("progress[data-id='" + id + "']");
                        progress.max++;
                        progress.value++;
                    }
                }
                request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
                request.send("id=" + id);
            }
            else {
                var request = new XMLHttpRequest();
                request.open("POST", "/Home/Downvote");
                request.onreadystatechange = function () {
                    if (request.readyState == XMLHttpRequest.DONE && request.status == 200) {
                        var progress = document.querySelector("progress[data-id='" + id + "']");
                        progress.max++;
                    }
                }
                request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
                request.send("id=" + id);
            }
        });
    }
}

init();