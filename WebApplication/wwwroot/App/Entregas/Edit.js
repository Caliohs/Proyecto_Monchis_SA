"use strict";
var EntregasEdit;
(function (EntregasEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,
            CantonLista: [],
            DistritoLista: [],
        },
        methods: {
            OnChangeProvincia: function () {
                var _this = this;
                Loading.fire("Cargando...");
                App.AxiosProvider.EntregasChangeProvincia(this.Entity).then(function (data) {
                    Loading.close();
                    _this.CantonLista = data;
                });
            },
            OnChangeCanton: function () {
                var _this = this;
                Loading.fire("Cargando...");
                App.AxiosProvider.EntregasChangeCanton(this.Entity).then(function (data) {
                    Loading.close();
                    _this.DistritoLista = data;
                });
            },
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando..");
                    App.AxiosProvider.EntregasGuardar(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se guardó satisfactoriamente", icon: "success" }).then(function () { return window.location.href = "Entregas/Grid"; });
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
        created: function () {
            this.OnChangeProvincia();
            this.OnChangeCanton();
        }
    });
    Formulario.$mount("#AppEdit");
})(EntregasEdit || (EntregasEdit = {}));
//# sourceMappingURL=Edit.js.map