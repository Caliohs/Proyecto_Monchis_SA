namespace PedidosBegin {
    var Entity = $("#AppEdit").data("entity");
   
    var Formulario = new Vue({

        data: {
            Formulario: "#FormEdit",
            Entity: Entity,

        },

        methods: {

            Save() {

                if (BValidateData(this.Formulario)) {
                   // Loading.fire("Guardando..");

                    App.AxiosProvider.PedidoGuardar(this.Entity).then(
                        data => {
                            Loading.close();

                            if (data.CodeError == 0) {

                                Toast.fire({ title: "Cargando...", icon: "success" }).then(() => window.location.href = "Pedidos/Edit?id=" + this.Entity.PedidoId);

                                
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


}