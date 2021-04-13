$(document).ready(function () {
    new LoaiSP();
    //dialogDetail = $('.modal-dialog').modal({
    //    autoOpen: false,
    //    fluid: true,
    //    minWidth: 350,
    //    resizable: false,
    //    modal: true,
    //    position: ({ my: "center", at: "center", of: window }),
    //});
})
class LoaiSP extends Base {
    constructor() {
        super();
    }
    setApiRouter() {
        this.getApiRoter = "LoaiSPs";
    }
}