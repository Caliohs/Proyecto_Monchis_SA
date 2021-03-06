"use strict";
var ConductorGrid;
(function (ConductorGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "#d33")
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando...");
                App.AxiosProvider.ConductorEliminar(id).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "Se eliminĂ³ correctamente", icon: "success" }).then(function () { return window.location.href = "Conductor/Grid"; });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    ConductorGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(ConductorGrid || (ConductorGrid = {}));
//# sourceMappingURL=Grid.js.map