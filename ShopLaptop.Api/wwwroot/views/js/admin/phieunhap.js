$(document).ready(function () {
    new PhieuNhap();

})
class PhieuNhap extends Base {
    constructor() {
        super();
    }
    setApiRouter() {
        this.getApiRoter = "PhieuNhaps";
    }
}