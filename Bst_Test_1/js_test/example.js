var con = 1;
function js1() {
    ////$('#pos0').append(sho3);
    //// $('#resultado table').remove();
    $("#result h2").remove();
    $('#result').load('/Test/jstest/', { id: 1 });
}

function ajax1() {
    $.ajax({
        url: '/Test/jstest2',
        data: { id: con }
    }).done(function (data) {
  //}).success(function (data) {
        $('#result').append(data);
        con++;
    });
}