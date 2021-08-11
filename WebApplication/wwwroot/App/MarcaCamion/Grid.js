"use strict";
var MarcaCamionGrid;
(function (MarcaCamionGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "#d33")
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando...");
                App.AxiosProvider.MarcaCamionEliminar(id).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "Se eliminó correctamente", icon: "success" }).then(function () { return window.location.href = "MarcaCamion/Grid"; });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    MarcaCamionGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(MarcaCamionGrid || (MarcaCamionGrid = {}));
//# sourceMappingURL=Grid.js.map