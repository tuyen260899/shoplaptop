$(document).ready(function () {
    formatLayout();
    formatPage();
    login();
})

function login() {
    var me = this;
    $('#btn-login').click(function () {
        var inputvalidates = $('#login-form').find('input[required]');
        $.each(inputvalidates, function (index, input) {
            $(input).trigger('blur');
        })
        var inputnotvalidate = $('input[validate="false"]');
        if (inputnotvalidate && inputnotvalidate.length > 0) {
            alert("Dữ liệu không hợp lệ");
            inputnotvalidate[0].focus();
            return;
        } else {
            var user = $('input[fileName="username"]').val();
            var pass = $('input[fileName="password"]').val();
            if (user == "admin" && pass == "admin123") {
                document.cookie = "admin";
                location.reload();
            } else {
                $.ajax({
                    url: "http://localhost:49974/api/v1/KhachHangs" + `/${user}` + `/${pass}`,
                    method: "GET"
                }).done(function (res) {
                    if (res) {
                        //$('.dialog').hide();
                        //$('.login-model').hide();
                        location.replace('customer.html');
                        document.cookie = res.username;
                    }
                    else {
                        alert("Thông tin tài khoản hoặc mật khẩu không chính xác");
                    }
                }).fail(function (res) {

                })
            }
        }
    })
}