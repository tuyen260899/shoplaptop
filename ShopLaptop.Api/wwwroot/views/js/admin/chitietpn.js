$(document).ready(function () {
    new ChiTietPN();

})
class ChiTietPN extends Base {
    constructor() {
        super();
    }
    setApiRouter() {
        this.getApiRoter = "ChiTietPNs";
    }
}