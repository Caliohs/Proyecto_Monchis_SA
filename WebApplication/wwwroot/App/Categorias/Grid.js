"use strict";
var CategoriasGrid;
(function (CategoriasGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "#d33")
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando...");
                App.AxiosProvider.CategoriasEliminar(id).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "Se eliminó correctamente", icon: "success" }).then(function () { return window.location.href = "Categorias/Grid"; });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    CategoriasGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(CategoriasGrid || (CategoriasGrid = {}));
//# sourceMappingURL=Grid.js.map