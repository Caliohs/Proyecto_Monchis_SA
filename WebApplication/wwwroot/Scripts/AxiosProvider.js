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
        AxiosProvider.ClientesEliminar = function (id) { return axios.delete("Clientes/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ClientesGuardar = function (entity) { return axios.post("Clientes/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.PedidoPorProductoGuardar = function (entity) { return axios.post("Pedidos/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.PedidoGuardar = function (entity) { return axios.post("Pedidos/Begin", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.PedidosEliminar = function (id) { return axios.delete("Pedidos/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.PedidosEliminarP = function (id) { return axios.delete("Pedidos/Edit?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.EntregasEliminar = function (id) { return axios.delete("Entregas/Grid?handler=Eliminar&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.EntregasGuardar = function (entity) { return axios.post("Entregas/Edit", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.EntregasChangeProvincia = function (entity) { return axios.post("Entregas/Edit?handler=ChangeProvincia", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.EntregasChangeCanton = function (entity) { return axios.post("Entregas/Edit?handler=ChangeCanton", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.UsuarioRegistrar = function (entity) { return ServiceApi.post("api/Usuarios/Registrar", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.UsuarioLogin = function (entity) { return axios.post("Login", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
    })(AxiosProvider = App.AxiosProvider || (App.AxiosProvider = {}));
})(App || (App = {}));
//# sourceMappingURL=AxiosProvider.js.map