namespace EntregasEdit {
    var Entity = $("#AppEdit").data("entity");

    var Formulario = new Vue({

        data: {
            Formulario: "#FormEdit",
            Entity: Entity,
            CantonLista: [],
            DistritoLista: [],
        },

        methods: {

            OnChangeProvincia() {
                Loading.fire("Cargando...")

                App.AxiosProvider.EntregasChangeProvincia(this.Entity).then(
                    data => {
                        Loading.close();
                        this.CantonLista=data

                    }

                );

            },

            OnChangeCanton() {
                Loading.fire("Cargando...")

                App.AxiosProvider.EntregasChangeCanton(this.Entity).then(
                    data => {
                        Loading.close();
                        this.DistritoLista = data

                    }

                );

            },

            Save() {

                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando..");

                    App.AxiosProvider.EntregasGuardar(this.Entity).then(
                        data => {
                            Loading.close();

                            if (data.CodeError == 0) {
                                Toast.fire({ title: "Se guardó satisfactoriamente", icon: "success" }).then(() => window.location.href = "Entregas/Grid");

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

        created() {
            this.OnChangeProvincia();
            this.OnChangeCanton();

        }

    }
    );

    Formulario.$mount("#AppEdit");


}