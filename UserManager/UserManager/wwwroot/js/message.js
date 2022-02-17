function readed(value){
    $.ajax({
        dataType: "json",
        url: "/Messages/UpdateMessageState",
        method: "POST",
        data: { messageId : value },
        success: UpdateMessageState(),
    });
  }

function UpdateMessageState(){
    document.getElementById("image").src = "~/img/readed.png"
}