//$(document).ready(function () {
//    loadData();
//})
//function loadData() {
//    $.ajax({
//        url: "http://localhost:49974/api/v1/SanPhams",
//        method: "GET",
//    }).done(function (res) {
//        var data = res;
//        $.each(data, function (index, item) {
//            var money = item['gia'];
//            money = formatMoney(money);
//            var checkbox = `<input type="checkbox"/>`;
//            if (item['active'] > 0) {
//                var checkbox = `<input type="checkbox" checked="true"/>`
//            }
//            var tr = $(`<tr class="info">
//                                <td>`+ item['id'] + `</td>
//                                <td>`+ item['masp'] +`</td>
//                                <td>`+ item['tensp'] + `</td>
//                                <td>`+ item['chitiet'] + `</td>
//                                <td>`+ money +`</td>
//                                <td>`+ item['cpu'] +`</td>
//                                <td>`+ item['baohanh'] + `</td>
//                                <td><div style="text-align: center;">` + checkbox +`</div></td>
//                                <td style="text-align: center;">
//                                    <span >
//                                        <a class="agile-icon" href="#" data-toggle="modal" data-target="#myModal"><i class="fa fa-pencil-square-o"></i></a>
//                                    </span>
//                                    <span>
//                                        <a class="agile-icon" href="#" data-toggle="modal" data-target="#myModal1"><i class="fa fa-times-circle"></i></a>
//                                    </span>

//                                </td>
//                            </tr>`);
//            $('table tbody').append(tr);
//        })
        
//    }).fail(function (res) {

//    })
//}
$(document).ready(function () {
    new SanPham();
    //dialogDetail = $('.modal-dialog').modal({
    //    autoOpen: false,
    //    fluid: true,
    //    minWidth: 350,
    //    resizable: false,
    //    modal: true,
    //    position: ({ my: "center", at: "center", of: window }),
    //});
})
class SanPham extends Base {
    constructor() {
        super();
    }
    setApiRouter() {
        this.getApiRoter = "SanPhams";
    }
}