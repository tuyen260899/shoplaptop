$(document).ready(function () {
    new NhanVien();
})
class NhanVien extends Base {
    constructor() {
        super();
    }
    setApiRouter() {
        this.getApiRoter = "NhanViens";
    }
}