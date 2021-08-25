namespace PedidosEdit {
    var Entity = $("#AppEdit").data("entity");
    
    var Formulario = new Vue({
    
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,
           
        },

        methods: {

            Save() {

                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando..");

                    App.AxiosProvider.PedidoPorProductoGuardar(this.Entity).then(
                        data => {
                            Loading.close();
                          
                            if (data.CodeError == 0) {
                               
                             (window.location.href = "Pedidos/Edit?id=" + this.Entity.PedidoId);

                                
                            } else {

                           Toast.fire({ title: data.MsgError, icon: "error" })
                            }

                        }

                    );

                }
                else {

                    Toast.fire({ title: "Por favor complete los campos requeridos", icon: "error" });
                }
            }
            
            
        },
        
        mounted() {

            CreateValidator(this.Formulario);
        },
        


    }
    );

    Formulario.$mount("#AppEdit");

    //-----------------------------------------------------
    //-----------------------------------------------------
    export function OnClickEliminar(id) {

        Loading.fire("Borrando...");

        App.AxiosProvider.PedidosEliminarP(id).then(data => {
            Loading.close();

            if (data.CodeError == 0) {
                Toast.fire({ title: "Se eliminó correctamente", icon: "success" }).then(
                    () => window.location.href = "Pedidos/Edit?id=" + Entity.PedidoId);

            } else {

                Toast.fire({ title: data.MsgError, icon: "error" })
            }

        });





    }


    $("#GridView").DataTable();


}