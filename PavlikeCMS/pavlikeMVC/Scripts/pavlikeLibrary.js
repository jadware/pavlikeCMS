

function refreshList(url,appendDiv) {
    $.get(url, function (data) {
        $("#"+ appendDiv).html(null);
        $("#"+ appendDiv).html(data);
      
    });
}



