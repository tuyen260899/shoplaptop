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

function formatDate(date) {
    var date = new Date(date);
    if (Number.isNaN(date.getTime())) {
        return "";
    } else {
        var day = date.getDate(),
            month = date.getMonth() + 1,
            year = date.getFullYear();
        day = day < 10 ? '0' + day : day;
        month = month < 10 ? '0' + month : month;

        return day + '/' + month + '/' + year;
    }
}

function getNameImg(value) {
    var stack = value.lastIndexOf("\\");
    value = value.substring(stack + 1);
    return value;
}
