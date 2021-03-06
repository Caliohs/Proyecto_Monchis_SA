"use strict";
var ProductosGrid;
(function (ProductosGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "#d33")
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando...");
                App.AxiosProvider.ProductosEliminar(id).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "Se eliminĂ³ correctamente", icon: "success" }).then(function () { return window.location.href = "Productos/Grid"; });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    ProductosGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(ProductosGrid || (ProductosGrid = {}));
//# sourceMappingURL=Grid.js.map