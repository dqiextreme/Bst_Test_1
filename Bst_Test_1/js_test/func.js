var con = 1;
function bt1() {
    ////$('#pos0').append(sho3);
    //// $('#resultado table').remove();
    $("#result h2").remove();
    $('#result').load('/Test/jstest/', { id: 1 });
}

function bt2() {
    $.ajax({
        url: '/Test/jstest2',
        data: { id: con }
    }).success(function (data) {
        $('#result').append(data);
        con++;
    });
}

function bt3() {
    $.ajax({
        url: '/Test/jstest2',
        data: { id: con }
    }).success(function (data) {
        $('#result').prepend(data);
        con++;
    });
}

function bt4() {
    $.ajax({
        url: '/Test/jstest3',
        data: { id: con }
    }).success(function (data) {
        $('#result').prepend(data);
        con++;
    });
}
