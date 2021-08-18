
namespace App.AxiosProvider   {

    //export const GuardarEmpleado = () => axios.get<Entity.DBEntity>("aplicacion").then(({data})=>data );

    export const CamionEliminar = (id) => axios.delete<DBEntity>("Camion/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);

    export const CamionGuardar = (entity) => axios.post<DBEntity>("Camion/Edit",entity).then(({ data }) => data);

    export const ConductorEliminar = (id) => axios.delete<DBEntity>("Conductor/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);

    export const ConductorGuardar = (entity) => axios.post<DBEntity>("Conductor/Edit", entity).then(({ data }) => data);

    export const MarcaCamionEliminar = (id) => axios.delete<DBEntity>("MarcaCamion/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);

    export const MarcaCamionGuardar = (entity) => axios.post<DBEntity>("MarcaCamion/Edit", entity).then(({ data }) => data);

    export const ProductosEliminar = (id) => axios.delete<DBEntity>("Productos/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);

    export const ProductosGuardar = (entity) => axios.post<DBEntity>("Productos/Edit", entity).then(({ data }) => data);

    export const CategoriasEliminar = (id) => axios.delete<DBEntity>("Categorias/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);

    export const CategoriasGuardar = (entity) => axios.post<DBEntity>("Categorias/Edit", entity).then(({ data }) => data);

    export const ClientesEliminar = (id) => axios.delete<DBEntity>("Clientes/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);

    export const ClientesGuardar = (entity) => axios.post<DBEntity>("Clientes/Edit", entity).then(({ data }) => data);
}




