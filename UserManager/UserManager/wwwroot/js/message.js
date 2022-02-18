function readed(value){
    $.ajax({
        dataType: "json",
        url: "/Messages/UpdateMessageState",
        method: "POST",
        data: { messageId: value },
        success: UpdateMessageState(value),
    });
  }

function UpdateMessageState(value) {


    let newImg = document.createElement("img")
    newImg.src = "https://res.cloudinary.com/dtomjloda/image/upload/v1645193085/img/readed_pt3hoq.png"
    newImg.height = 25
    newImg.width = 25
    let str = "image" + value
    document.getElementById(str).replaceWith(newImg)


}