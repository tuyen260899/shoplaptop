$(document).ready(function () {
    loadDetail(getmaSP());
    dathang();
    formatLayout();
    formatPage();
})

function loadDetail(maSP) {
    var me = this;
    $.ajax({
        url: "http://localhost:49974/api/v1/SanPhams" + `/${maSP}`,
        method: "GET",
    }).done(function (res) {
        if (res) {
            var tr = $(`<tr class="">
                            <th>CPU</th>
                            <td>` + res.cpu + `</td>
                        </tr>
                        <tr class="alt">
                            <th>RAM</th>
                            <td>` + res.ram + `</td>
                        </tr>
                        <tr class="">
                            <th>Đĩa cứng</th>
                            <td>` + res.hdd + `</td>
                        </tr>
                        <tr class="alt">
                            <th>Trọng lượng</th>
                            <td>` + res.weight + `</td>
                        </tr>
                        <tr class="">
                            <th>Bảo hành</th>
                            <td>` + res.baohanh + `</td>
                        </tr>`);
            
            var tinhtrang = `Còn hàng`
            if (res.active == true) {
                var tinhtrang = `Còn hàng`;
            } else if (res.active == false) {
                var tinhtrang = `Hết hàng`;
            }

            var image_detail = $(`<a href="/themes/images/cloth/` + res.hinh + `" class="thumbnail" data-fancybox-group="group1" title="Description 1"><img alt="" src="/themes/images/cloth/` + res.hinh +`"></a>
                                    <ul class="thumbnails small">
                                        <li class="span1">
                                            <a href="/themes/images/cloth/laptop2.jpg" class="thumbnail" data-fancybox-group="group1" title="Description 2"><img src="/themes/images/cloth/laptop2.jpg" alt=""></a>
                                        </li>
                                        <li class="span1">
                                            <a href="/themes/images/cloth/laptop4.png" class="thumbnail" data-fancybox-group="group1" title="Description 3"><img src="/themes/images/cloth/laptop4.png" alt=""></a>
                                        </li>
                                        <li class="span1">
                                            <a href="/themes/images/cloth/laptop3.png" class="thumbnail" data-fancybox-group="group1" title="Description 4"><img src="/themes/images/cloth/laptop3.png" alt=""></a>
                                        </li>
                                        <li class="span1">
                                            <a href="/themes/images/cloth/laptop1.png" class="thumbnail" data-fancybox-group="group1" title="Description 5"><img src="/themes/images/cloth/laptop1.png" alt=""></a>
                                        </li>
                                    </ul>`);

            var value = $(`<address>
                                <strong>Tên sản phẩm:</strong> <span>` + res.tensp + `</span><br>
                                <strong>CPU:</strong> <span>` + res.cpu + `</span><br>
                                <strong>Tình trạng:</strong> <span>` + tinhtrang + `</span><br>
                                <strong>Ram:</strong> <span>` + res.ram + `</span><br>
                                <strong>Ổ cứng:</strong> <span>` + res.hdd + `</span><br>
                                <strong>VGA:</strong> <span>` + res.vga + `</span><br>
                         </address>
                         <h4><strong>Giá: `+ formatMoney(res.gia) + `đ</strong></h4>`);

            var form = $(`<form class="form-inline">
                                <p>&nbsp;</p>
                                <label>SL:</label>
                                <input type="text" id="soluong" class="span1" required>
                                <button type="button" class="btn btn-inverse" id="btn-order" masp="`+ maSP + `" username="` + document.cookie +`">Thêm vào giỏ</button>
                           </form>`);

            $('div #cart-detail').append(form);
            $('div #image-detail').append(image_detail);
            $('div #pro-detail').append(value);
            $('table tbody').append(tr);
            formatPage();
        }

    }).fail(function (res) {

    })

}

function getmaSP() {
    var url = document.URL;
    var start = url.lastIndexOf("\=");
    url = url.substring(start + 1);
    return url;

}

function dathang() {
    try {
        var me = this;
        $('div#cart-detail').on('click', 'button#btn-order', function () {
            if ($(this).attr('username') == "") {
                alert('Bạn chưa đăng nhập');
                window.location.replace('register.html');
            }
            else {
                var entity = {};
                var masp = $(this).attr('masp');
                var username = $(this).attr('username');
                $.ajax({
                    url: "http://localhost:49974/api/v1/SanPhams" + `/${masp}`,
                    method: "GET",
                }).done(function (res) {
                    if (res) {
                        var soluong = $('input#soluong').val();
                        soluong = parseInt(soluong);

                        entity["masp"] = masp;
                        entity["username"] = username;
                        entity["soluong"] = soluong;
                        entity["gia"] = res.gia;
                        entity["thanhtien"] = res.gia * soluong;

                        debugger;

                        
                        $.ajax({
                            url: "http://localhost:49974/api/v1/ChiTietHDs/",
                            type: "POST",
                            data: JSON.stringify(entity),
                            contentType: "Application/json;charset=utf-8",
                            dataType: "json",   
                        }).done(function (res) {
                            if (res == 2) {
                                alert('Đã thêm vào giỏ hàng');
                                location.reload();
                            }
                            else {
                                alert('Thêm thất bại');
                            }
                        }).fail(function (res) {
                            alert('Thêm thất bại');
                        })

                    }
                }).fail(function (res) {

                })

            }
        })
    }
    catch (e) {
        console.log(e);
    }
    
}
