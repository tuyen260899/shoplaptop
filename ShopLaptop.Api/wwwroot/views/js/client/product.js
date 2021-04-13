$(document).ready(function () {
    loadData();
    loadDatabyTen();
    formatLayout();
    formatPage();
    loadCombobox();
    filter();
    all();
})
function loadData() {
    $('#list-product1').empty();
    $.ajax({
        url: "http://localhost:49974/api/v1/SanPhams",
        method: "GET",
    }).done(function (res) {
        $.each(res, function (index, item) {
            var money = (item['gia']);
            money = formatMoney(money);
            var li = $(`<li class="span3">
                            <div class="product-box">
                                <a href="product_detail.html?masp=` + item.masp + `"><img alt="" src="/themes/images/cloth/` + item['hinh'] +`"></a><br />
                                <a href="#" masp="` + item['masp'] + `" class="title" id="format-size">`+ item['tensp'] +`</a><br />
                                <a href="#" class="category" id="format-size">`+ item['cpu'] +`</a>
                                <p class="price">`+ money +`</p>
                            </div>
                        </li>`);
            $('#list-product1').append(li);
            //formatPage();
            $("a#format-size").each(function () {
                if ($(this).text().length > 40) {
                    $(this).text($(this).text().substr(0, 40)); $(this).append('...');
                }
            });
        })
    }).fail(function (res) {
        debugger;
    })
}

function loadDatabyTen() {
    $('button#button-search').click(function () {
        var tensp = $('input#tensp').val();
        $('#list-product1').empty();
        $.ajax({
            url: "http://localhost:49974/api/v1/SanPhams/tensp?tensp=" + `${tensp}`,
            method: "GET",
        }).done(function (res) {
            $.each(res, function (index, item) {
                var money = (item['gia']);
                money = formatMoney(money);
                var li = $(`<li class="span3">
                            <div class="product-box">
                                <a href="product_detail.html?masp=` + item.masp + `"><img alt="" src="/themes/images/cloth/` + item['hinh'] + `"></a><br />
                                <a href="#" masp="` + item['masp'] + `" class="title" id="format-size">` + item['tensp'] + `</a><br />
                                <a href="#" class="category" id="format-size">`+ item['cpu'] + `</a>
                                <p class="price">`+ money + `</p>
                            </div>
                        </li>`);
                $('#list-product1').append(li);
                //formatPage();
                $("a#format-size").each(function () {
                    if ($(this).text().length > 40) {
                        $(this).text($(this).text().substr(0, 40)); $(this).append('...');
                    }
                });

            })
            debugger;
        }).fail(function (res) {
            debugger;
        })

    })
    
}

function loadCombobox() {
    try {
        var selects = $('select[name]');
        $('select[name]').empty();
        $.each(selects, function (index, sel) {
            var tableName = $(this).attr('name');
            var propertyName = $(this).attr('displayName');
            var propertyValue = $(this).attr('fileName');
            $(sel).append(`<option value=""> Tất cả </option>`)
            $.ajax({
                url: "http://localhost:49974/api/v1/" + `${tableName}`,
                method: "GET"
            }).done(function (res) {
                if (res) {
                    $.each(res, function (index, obj) {
                        var display = obj[propertyName];
                        var value = obj[propertyValue];
                        var option = $(`<option value="${value}">${display}</option>`);
                        $(sel).append(option);
                    })
                }
            }).fail(function (res) {

            })
        })
    } catch (e) {
        Console.log(e);
    }
}

function getGiaMax(gia) {
    var giaMax = 0;
    switch (gia) {
        case "0":
            $.ajax({
                url: "http://localhost:49974/api/v1/SanPhams/GiaMax",
                type: "GET",
                async: false,
            }).done(function (res) {
                if (res) {
                    giaMax = parseInt(res);
                }
            }).fail(function (res) {

            });
            break;
        case "1":
            giaMax = 5000000;
            break;
        case "2":
            giaMax = 10000000;
            break;
        case "3":
            giaMax = 15000000;
            break;
        case "4":
            giaMax = 20000000;
            break;
        case "5":
            giaMax = 999999999;
            break;
        default:
            break;
    }
    return giaMax;
}
function getGiaMin(gia) {
    var giaMin = 0;
    switch (gia) {
        case "0":
            $.ajax({
                url: "http://localhost:49974/api/v1/SanPhams/GiaMin",
                type: "GET",
                async: false,
            }).done(function (res) {
                if (res) {
                    giaMin = parseInt(res);
                }
            }).fail(function (res) {

            });
            break;
        case "1":
            giaMin = 0;
            break;
        case "2":
            giaMin = 5000000;
            break;
        case "3":
            giaMin = 10000000;
            break;
        case "4":
            giaMin = 15000000;
            break;
        case "5":
            giaMin = 20000000;
            break;
        default:
            break;
    }
    return giaMin;
}

function filter() {
    $('#filter-search').click(function () {
        var entity = {};
        var gia = $('select[fileName="gia"]').val();
        var giaMax = getGiaMax(gia);
        var giaMin = getGiaMin(gia);
        var maLoaiSP = $('select[fileName="maloai"]').val().toString();
        var maNSX = $('select[fileName="mansx"]').val();
        var sort = $('select[fileName="sort"]').val();

        entity["giaMax"] = giaMax;
        entity["giaMin"] = giaMin;
        entity["maloai"] = maLoaiSP;
        entity["mansx"] = maNSX;
        entity["sort"] = sort;
        debugger;
        $.ajax({
            url: "http://localhost:49974/api/v1/SanPhams/Filter",
            type: "POST",
            data: JSON.stringify(entity),
            contentType: "Application/json;charset=utf-8",
            dataType: "json",  
        }).done(function (res) {
            if (res != null) {
                $('#list-product1').empty();
                $.each(res, function (index, item) {
                    var money = (item['gia']);
                    money = formatMoney(money);
                    var li = $(`<li class="span3">
                            <div class="product-box">
                                <a href="product_detail.html?masp=` + item.masp + `"><img alt="" src="/themes/images/cloth/` + item['hinh'] + `"></a><br />
                                <a href="#" masp="` + item['masp'] + `" class="title" id="format-size">` + item['tensp'] + `</a><br />
                                <a href="#" class="category" id="format-size">`+ item['cpu'] + `</a>
                                <p class="price">`+ money + `</p>
                            </div>
                        </li>`);
                    $('#list-product1').append(li);
                    //formatPage();
                    $("a#format-size").each(function () {
                        if ($(this).text().length > 40) {
                            $(this).text($(this).text().substr(0, 40)); $(this).append('...');
                        }
                    });

                    formatPage();
                })
            }
            if ($('#list-product1').text() == "") {
                var text = $(`<div style="padding-left: 40%;"><p>Không có sản phẩm nào phù hợp</p></div>`);
                $('#list-product1').append(text);
            }
        }).fail(function (res) {

        })
    })
}

function all() {
    var me = this;
    $('#all').click(function () {
        me.loadData();
    })
}