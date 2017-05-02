let upVote = (postID) => {
    let data = {
        id: postID
    }

    $.ajax({
        url: "/Vote/UpVote",
        data: JSON.stringify(data),
        contentType: "application/json",
        type: "POST",
        dataType: "html",
        success: (newHtml) => {
            $("#voteCounter").html(newHtml);
        }
    })
}


let downVote = (postID) => {
    $.ajax({
        url: "/Vote/DownVote",
        data: JSON.stringify({ id: postId }),
        contentType: "application/json",
        type: "POST",
        dataType: "html",
        success: (newHtml) => {
            $("#voteCounter-").html(newHtml);
        }
    })
}