﻿namespace ProductosGrid {


    export function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "#d33")
            .then(result => {

                if (result.isConfirmed) {
                    Loading.fire("Borrando...");

                    App.AxiosProvider.ProductosEliminar(id).then(data => {
                        Loading.close();

                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se eliminó correctamente", icon: "success" }).then(
                                () => window.location.href = "Productos/Grid"
                            );
                        } else {

                            Toast.fire({ title: data.MsgError, icon: "error" })
                        }

                    }
                    );


                }

            });

    }

    $("#GridView").DataTable();


}