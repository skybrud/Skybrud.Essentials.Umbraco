(function () {

    function service(overlayService) {

        // https://stackoverflow.com/a/2117523
        function uuidv4() {
            return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, function (c) {
                const r = Math.random() * 16 | 0, v = c === "x" ? r : (r & 0x3 | 0x8);
                return v.toString(16);
            });
        }

        function htmlEncode(value) {
            return value.replace(/[\u00A0-\u9999<>\&]/gim, function (i) {
                return '&#' + i.charCodeAt(0) + ';';
            });
        }

        function confirmDelete(o) {

            o = Utilities.extend({
                view: "/App_Plugins/Skybrud.Essentials/Views/Overlays/Delete.html",
                closeButtonLabel: "Fortryd",
                submitButtonLabel: "Ja, slet bare",
                submitButtonStyle: "danger",
                close: function () {
                    overlayService.close();
                }
            }, o);

            overlayService.open(o);

        }

        return {
            guid: uuidv4,
            uuid: uuidv4,
            htmlEncode,
            confirmDelete
        };

    }

    // Since the package is using the "Skybrud.Essentials" brand, we primarily register the service as "skybrud"
    angular.module("umbraco").factory("skybrud", service);

    // But we also register "limbo" as an alias to match our company name
    angular.module("umbraco").factory("limbo", function (skybrud) {
        return skybrud;
    });


})();