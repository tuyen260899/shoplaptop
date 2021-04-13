$(document).ready(function () {
    formatLayout();
    formatInfor();
    formatPage();
    //logout();
    loadData();
})

//function logout() {
//    $('a#logout').click(function () {
//        $.cookie('index', 'index', { expires: -1, path: '/' });
//        $.cookie('customer', 'customer', { expires: -1, path: '/' });
//        $.cookie('register', 'register', { expires: -1, path: '/' });
//        $.cookie('product_detail', 'product_detail', { expires: -1, path: '/' });
//        location.reload();
//    })
//}

function formatInfor() {
    var username = document.cookie;
    $.ajax({
        url: "http://localhost:49974/api/v1/KhachHangs/" + `${username}`,
        type: "GET",
    }).done(function (res) {
        $('#name').val(res.hoten);
        $('#address').val(res.diachi);
        $('#numberphone').val(res.sodienthoai);
    }).fail(function (res) {

    })
}

function loadData() {
    var username = document.cookie;
    $(' #product-bought').empty();
    $.ajax({
        url: "http://localhost:49974/api/v1/HoaDons/Product/" + `${username}`,
        type: "GET",
    }).done(function (res) {
        $.each(res, function (index, obj) {
            var gia = obj['gia'];
            gia = formatMoney(gia);
            var li = $(`
                        <li class="span3">
                                <div class="product-box">
                                    <a href="product_detail.html?masp=` + obj['masp'] + `"><img alt="" src="/themes/images/cloth/` + obj['hinh'] + `"></a><br />
                                    <a href="product_detail.html" class="title" id="format-size">`+ obj['tensp'] + `</a><br />
                                    <a href="#" class="category" id="format-size">`+ obj['cpu'] + `</a>
                                    <p class="price">`+ gia +` đ</p>
                                </div>
                        </li>
                        `);
            $('#product-bought').append(li);
            
            $("a#format-size").each(function () {
                if ($(this).text().length > 40) {
                    $(this).text($(this).text().substr(0, 40)); $(this).append('...');
                }
            });
            debugger;
        })
 
    }).fail(function (res) {

    })
}