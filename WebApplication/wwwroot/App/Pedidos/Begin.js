"use strict";
var PedidosBegin;
(function (PedidosBegin) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,
        },
        methods: {
            Save: function () {
                var _this = this;
                if (BValidateData(this.Formulario)) {
                    // Loading.fire("Guardando..");
                    App.AxiosProvider.PedidoGuardar(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Cargando...", icon: "success" }).then(function () { return window.location.href = "Pedidos/Edit?id=" + _this.Entity.PedidoId; });
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    });
                }
                else {
                    Toast.fire({ title: "Por favor complete los campos requeridos", icon: "error" });
                }
            }
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        },
    });
    Formulario.$mount("#AppEdit");
})(PedidosBegin || (PedidosBegin = {}));
//# sourceMappingURL=Begin.js.map