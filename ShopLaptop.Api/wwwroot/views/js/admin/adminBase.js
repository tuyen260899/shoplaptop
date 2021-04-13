class Base {
    constructor() {
        this.host = "http://localhost:49974/api/v1/";
        this.getApiRoter = null;
        this.setApiRouter();
        this.loadData();
        this.loadCombobox();
        this.btnAdd();
        this.btnDelete();
        this.btnEdit();
        this.validateData();
        this.btnReload();
        this.search();
        this.flag = 0;
    }
    setApiRouter() {

    }

    btnReload() {
        $('#btn-close').click(function () {
            location.reload();
        });
    }

    btnAdd() {
        var me = this;
        try {
            $('a#add').on('click', function () {
                $('#btn-save').click(function () {
                    debugger;
                    me.flag = 1;
                    if (me.flag == 1) {
                        $('input[fileName="maKH"]').attr('flag', 'codeKH');
                        $('input[fileName="maKH"]').removeAttr('fileName');
                        $('input[fileName="maDH"]').attr('flag', 'codeDH');
                        $('input[fileName="maDH"]').removeAttr('fileName');
                    }
                    //Binding data
                    var entity = {};
                    var inputs = $('input[fileName], select[fileName], textarea[fileName]');
                    $.each(inputs, function (index, input) {
                        var propertyName = $(this).attr('fileName');
                        var value = $(this).val();
                        if (propertyName == "gia" || propertyName == "soluong" || propertyName == "thanhtien") {
                            value = parseInt(value);
                        }
                        if (propertyName == "active" || propertyName == "quyenhan") {
                            var bool = $(this).val();
                            if (bool == "1") {
                                value = true;
                            } else if (bool == "0") value = false;
                        }
                        entity[propertyName] = value;
                    })

                    $.ajax({
                        url: me.host + me.getApiRoter,
                        method: "POST",
                        data: JSON.stringify(entity),
                        contentType: 'application/json',
                    }).done(function (res) {
                        if (res == 1 || res == 2) {
                            alert("Thêm thành công");
                        } else alert(res);
                        me.loadData();
                    }).fail(function (res) {
                        alert("Không thêm được");
                    })
                    
                    //Load file anh
                    if (window.FormData !== undefined) {
                        var a = $('input[type="file"]').get(0);
                        var filees = a.files;
                        var formData = new FormData();
                        formData.append('fileImg', filees[0]);
                        $.ajax({
                            type: "POST",
                            url: "http://localhost:49974/api/v1/Images",
                            data: formData,
                            contentType: false,
                            processData: false
                        }).done(function (res) {
                        }).fail(function (res) {
                            debugger;
                        })
                    }
                })
            })
        }
        catch (e) {
            console.log(e);
        }
    }


    btnEdit() {
        var me = this;
        $('*').on('click', 'a#update', function () {
            debugger;
            me.flag = 2;
            if (me.flag == 2) {
                $('input[flag="codeKH"]').attr('fileName', 'maKH');
                $('input[flag="codeKH"]').removeAttr('flag');
                $('input[flag="codeDH"]').attr('fileName', 'maDH');
                $('input[flag="codeDH"]').removeAttr('flag');
            }
            var recordId = $(this).attr('recordId');
            $.ajax({
                url: me.host + me.getApiRoter + `/${recordId}`,
                method: "GET",
            }).done(function (res) {
                if (res) {
                    var inputs = $('input[fileName], select[fileName], textarea[fileName]');
                    $.each(inputs, function (index, input) {
                        var propertyName = $(this).attr('fileName');
                        var value = res[propertyName];
                        if (propertyName == "active" || propertyName == "quyenhan" || propertyName == "thanhtien") {
                            var bool = res['active']
                            if (bool == true) {
                                value = "1";
                            }
                            else if (bool == false) value = "0";
                        }
                        $(this).val(value);
                    })
                }
            }).fail(function (res) {
            })
        })
        //Event accept update
        $('#btn-save').on('click', function () {
            //Get data form dialog
            var entity = {};
            var inputs = $('input[fileName], select[fileName], textarea[fileName]');
            $.each(inputs, function (index, input) {
                var propertyName = $(this).attr('fileName');
                var value = $(this).val();
                if (propertyName == "gia" || propertyName == "soluong" || propertyName == "thanhtien") {
                    value = parseInt(value);
                }
                if (propertyName == "active" || propertyName == "quyenhan") {
                    var bool = $(this).val();
                    if (bool == "1") {
                        value = true;
                    } else if (bool == "0") value = false;
                }
                entity[propertyName] = value;
            })

            if (me.flag == 2) {
                $.ajax({
                    url: me.host + me.getApiRoter,
                    method: "PUT",
                    data: JSON.stringify(entity),
                    contentType: 'application/json',
                }).done(function (res) {
                    me.loadData();
                }).fail(function (res) {

                })
                alert("Cập nhật thành công");
                //Load file anh
                if (window.FormData !== undefined) {
                    var a = $('input[type="file"]').get(0);
                    var filees = a.files;
                    var formData = new FormData();
                    formData.append('fileImg', filees[0]);
                    $.ajax({
                        type: "POST",
                        url: "http://localhost:49974/api/v1/Images",
                        data: formData,
                        contentType: false,
                        processData: false
                    }).done(function (res) {
                    }).fail(function (res) {
                        debugger;
                    })
                }
            }
        })
    }

    /*Catch event delete object
    Create by: TUYEN */
    btnDelete() {
        var me = this;
        var recordId;
        $('*').on('click', 'a#delete', function () {
            recordId = $(this).attr('recordId');
            $('.dialog-del').find('span').text(recordId);
            $('#myModal1').find('span').text(recordId);
        })

        //Event accept delete
        $('#btn-delete').on('click', function () {
            $.ajax({
                url: me.host + me.getApiRoter + `/${recordId}`,
                method: "DELETE",
            }).done(function (res) {
                me.loadData();
            }).fail(function (res) {

            })
            alert("Xóa thành công");
        })
    }
    /*
     */


    /*Validate data input
    Create by: TUYEN */
    validateData() {
        $('input[required]').blur(function () {
            var value = $(this).val();
            if (!value) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Trường này không được bỏ chống');
                $(this).attr('validate', false);
            } else {
                $(this).removeClass('border-red');
                $(this).attr('validate', true);
            }
        })
        //Validate Email
        $('input[type="email"]').blur(function () {
            var value = $(this).val();
            var testemail = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
            if (!testemail.test(value)) {
                $(this).addClass('boder-red');
                $(this).attr('title', "Không đúng định dạng");
                $(this).attr("validate", false);
            } else {
                $(this).removeClass('boder-red');
                $(this).attr('validate', true);
            }
        })
    }

    loadCombobox() {
        try {
            var me = this;
            var selects = $('select[name]');
            $('select').empty();
            $.each(selects, function (index, sel) {
                var tableName = $(this).attr('name');
                var propertyName = $(this).attr('displayName');
                var propertyValue = $(this).attr('fileName');
                $.ajax({
                    url: me.host + `${tableName}`,
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

    search() {
        $('.search').on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $("table tbody tr").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
        });
    }

    /*Load data
     * Create by: Tuyen
     */
    loadData() {
        var me = this;
        try {
            $("table tbody").empty();
            var columns = $('table thead th');
            var nameRecord = $('table').attr('id');
            $.ajax({
                url: this.host + this.getApiRoter,
                method: "GET",
            }).done(function (res) {
                $.each(res, function (index, obj) {
                    var tr = $(`<tr></tr>`);
                    //Lấy thông tin dữ liệu sẽ map tương ứng với các cột
                    $.each(columns, function (index, th) {
                        var td = $(`<td></td>`);
                        var fileName = $(th).attr('fileName');
                        var value = obj[fileName];
                        var checkbox = `<input type="checkbox"/>`
                        if (obj['active'] > 0 || obj['quyenhan'] > 0) {
                            var checkbox = `<input type="checkbox" checked="true"/>`;
                        }
                        if (fileName == "chinhsua") {
                            value = $(`<div style="text-align: center;">
                                        <span >
                                            <a class="agile-icon" href="#" id="update" data-toggle="modal" data-target="#myModal"><i class="fa fa-pencil-square-o"></i></a>
                                        </span>
                                        <span>
                                            <a class="agile-icon" href="#" id="delete" data-toggle="modal" data-target="#myModal1"><i class="fa fa-times-circle"></i></a>
                                        </span>
                                    </div>`);
                        }
                        if (fileName == "active" || fileName == "quyenhan") {
                            value = $(`<div style="text-align: center;">` + checkbox + `</div>`);
                        }
                        if (fileName == "trangthai") {
                            if (obj['trangthai'] == 1) {
                                value = `Đã giao`;
                            } else if (obj['trangthai'] == 2) {
                                value = `Đang giao hàng`;
                            } else if (obj['trangthai'] == 3) {
                                value = `Chưa giao`;
                            }
                        }
                        var formatType = $(th).attr('formatType');
                        switch (formatType) {
                            case "money":
                                value = formatMoney(value);
                                break;
                            case "ngaythang":
                                value = formatDate(value);
                                break;
                            case "thanhtoan":
                                if (obj['active'] == 1) {
                                    value = `Đã thanh toán`;
                                } else value = `Chưa thanh toán`;
                                break;
                            default:
                                break;
                        }
                        td.append(value);
                        tr.append(td);
                        $(tr).find('a#update').attr('recordId', obj[nameRecord]);
                        $(tr).find('a#delete').attr('recordId', obj[nameRecord]);
                    })
                    $('table tbody').append(tr);
                })
            }).fail(function (res) {

            })
        } catch (e) {
            console.log(e);
        }
    }
}