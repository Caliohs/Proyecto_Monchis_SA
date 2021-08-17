"use strict";
var App;
(function (App) {
    var AxiosProvider;
    (function (AxiosProvider) {
        //export const GuardarEmpleado = () => axios.get<Entity.DBEntity>("aplicacion").then(({data})=>data );
        AxiosProvider.CamionEliminar = function (id) { return axios.delete("Camion/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.CamionGuardar = function (entity) { return axios.post("Camion/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ConductorEliminar = function (id) { return axios.delete("Conductor/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ConductorGuardar = function (entity) { return axios.post("Conductor/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.MarcaCamionEliminar = function (id) { return axios.delete("MarcaCamion/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.MarcaCamionGuardar = function (entity) { return axios.post("MarcaCamion/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ProductosEliminar = function (id) { return axios.delete("Productos/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ProductosGuardar = function (entity) { return axios.post("Productos/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.CategoriasEliminar = function (id) { return axios.delete("Categorias/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.CategoriasGuardar = function (entity) { return axios.post("Categorias/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
    })(AxiosProvider = App.AxiosProvider || (App.AxiosProvider = {}));
})(App || (App = {}));
//# sourceMappingURL=AxiosProvider.js.map