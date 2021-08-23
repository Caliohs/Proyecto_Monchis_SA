"use strict";
var PedidosEdit;
(function (PedidosEdit) {
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
                    Loading.fire("Guardando..");
                    App.AxiosProvider.PedidoPorProductoGuardar(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            (window.location.href = "Pedidos/Edit?id=" + _this.Entity.PedidoId);
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
    //-----------------------------------------------------
    function OnClickEliminar(id) {
        Loading.fire("Borrando...");
        App.AxiosProvider.PedidosEliminarP(id).then(function (data) {
            Loading.close();
            if (data.CodeError == 0) {
                (function () { return window.location.href = "Pedidos/Edit?id=" + Entity.PedidoId; });
            }
            else {
                Toast.fire({ title: data.MsgError, icon: "error" });
            }
        });
    }
    PedidosEdit.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(PedidosEdit || (PedidosEdit = {}));
//# sourceMappingURL=Edit.js.map