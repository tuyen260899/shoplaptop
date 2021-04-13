function formatMoney(money) {
    if (money) {
        money = parseFloat(money);
        return money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, '$1.');
    }
    //return "20000";
    else {
        return "";
    }
}
function formatPage() {
    if (document.cookie != "admin");
    {
        var username = document.cookie;
        $('*').find('button#btn-order').attr('username', username);
    }
}
function formatLayout() {
    if (document.cookie != "admin") {
        var username = document.cookie;
        $.ajax({
            url: "http://localhost:49974/api/v1/KhachHangs/" + `${username}`,
            method: "GET",
        }).done(function (res) {
            $('a#acc').text(res.username);
        }).fail(function (res) {

        })
    }
    else {
        $('a#acc').html('<a href="../admin/sanpham.html" style="color: #959595;"><u>Admin</u></a>');
    }
}