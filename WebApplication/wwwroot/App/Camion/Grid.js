"use strict";
var CamionGrid;
(function (CamionGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "#d33")
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando...");
                App.AxiosProvider.CamionEliminar(id).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "Se eliminĂ³ correctamente", icon: "success" }).then(function () { return window.location.href = "Camion/Grid"; });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    CamionGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(CamionGrid || (CamionGrid = {}));
//# sourceMappingURL=Grid.js.map