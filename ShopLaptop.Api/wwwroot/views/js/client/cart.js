$(document).ready(function () {
    loadData();
    formatLayout();
    formatPage();
    deleteCart();
    updateSoluong();
    loadMoneyTotal();
})
function loadData() {
    var username = document.cookie;
    $('table tbody').empty();
    var nameRecord = $('table').attr('id');
    $.ajax({
        url: "http://localhost:49974/api/v1/ChiTietHDs/Cart/" + `${username}`,
        method: "GET",
    }).done(function (res) {
        $.each(res, function (index, item) {
            var money = (item['gia']);
            money = formatMoney(money);
            var thanhtien = (item['thanhtien']);
            thanhtien = formatMoney(thanhtien);
            //<td><input type="checkbox" mahd="`+ item.mahd +`" id="checkbox-del" value="option1"></td>
            var tr = $(`<tr>
                            <td style="text-align: center;"> `+ item.mahd + ` </td>
                            <td><a href="product_detail.html?masp=` + item.masp + `"><img alt="" src="/themes/images/cloth/` + item.hinh + `"></a></td>
                            <td>`+ item.tensp + `</td>
                            <td><input type="text" placeholder="`+ item.soluong + `" class="input-mini"></td>
                            <td>`+ money + `</td>
                            <td>`+ thanhtien + `</td>
                            <td>
                                <div style="text-align: center;">
                                        <span>
                                            <a class="agile-icon" href="#" id="delete" data-toggle="modal" data-target="#myModal1"><i class="fa fa-times-circle"></i></a>
                                        </span>
                                </div>
                            </td>
                            <td>
                                <div style="text-align: center;">
                                        <span >
                                            <a class="agile-icon" href="#" id="update" data-toggle="modal" data-target="#myModal"><i class="fas fa-edit"></i></a>
                                        </span>
                               </div>
                            </td>
                        </tr>`);
            $(tr).find('a#delete').attr('recordId', item[nameRecord]);
            $(tr).find('a#update').attr('recordId', item[nameRecord]);
            $('table tbody').append(tr);
            //formatPage();
            //$("a#format-size").each(function () {
            //    if ($(this).text().length > 40) {
            //        $(this).text($(this).text().substr(0, 40)); $(this).append('...');
            //    }
            //});
        })
    }).fail(function (res) {

    })
}

function deleteCart() {
    debugger;
    var me = this;
    var recordId;
    $('*').on('click', 'a#delete', function () {
        recordId = $(this).attr('recordId');
        $('#myModal1').find('span').text(recordId);
    })
    $('#btn-delete').on('click', function () {
        $.ajax({
            url: "http://localhost:49974/api/v1/ChiTietHDs" + `/${recordId}`,
            type: "DELETE",
        }).done(function (res) {
            if (res) {
                me.loadData();
            }
        }).fail(function (res) {

        })
        alert('Xóa đơn hàng ' + recordId + ' thành công');
    })
}


function updateSoluong() {
    var me = this;
    var gia;
    var recordId;
    $('*').on('click', 'a#update', function () {
        recordId = $(this).attr('recordId');
        $.ajax({
            url: "http://localhost:49974/api/v1/ChiTietHDs" + `/${recordId}`,
            type: "GET",
        }).done(function (res) {
            $('#soluong').val(res.soluong);
            gia = res.gia;
        }).fail(function (res) {
        })
    })
    $('#btn-save').on('click', function () {
        debugger;
        var entity = {};
        var soluong = $('#soluong').val();
        entity["soluong"] = parseInt(soluong);
        entity["gia"] = parseInt(gia);
        entity["thanhtien"] = parseInt(soluong * gia);
        entity["mahd"] = recordId;

        $.ajax({
            url: "http://localhost:49974/api/v1/ChiTietHDs/UpdateCart" + `/${recordId}`,
            type: "PUT",
            data: JSON.stringify(entity),
            contentType: "Application/json;charset=utf-8",
            dataType: "json",
        }).done(function (res) {
            if (res) {
                alert('Cập nhật số lượng thành công');
                me.loadData();
            }
        }).fail(function (res) {
            alert('Số lượng sản phẩm không đủ');
        })
    })
}

function loadMoneyTotal() {
    var username = document.cookie;
    $('table tbody').empty();
    var nameRecord = $('table').attr('id');
    $.ajax({
        url: "http://localhost:49974/api/v1/ChiTietHDs/Cart/" + `${username}`,
        method: "GET",
    }).done(function (res) {
        var thanhtien = 0;
        $.each(res, function (index, item) {
            thanhtien += item['thanhtien'];
            
        })
        thanhtien = formatMoney(thanhtien);
        var strong = $(`<strong> Tổng </strong>: ` + thanhtien + `đ<br>`)
        $('#money-total').append(strong);
    }).fail(function (res) {

    })
}