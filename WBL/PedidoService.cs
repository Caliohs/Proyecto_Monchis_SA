using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IPedidoService
    {
        //Task<DBEntity> Create(PedidoEntity entity, PedidoPorProductoEntity en);
        Task<IEnumerable<PedidoEntity>> Get();
        Task<PedidoEntity> GetById(PedidoEntity entity);
        Task<int> GetId();
        Task<IEnumerable<PedidoEntity>> GetLista();
        Task<DBEntity> Create(PedidoEntity entity);

        Task<DBEntity> Delete(PedidoEntity entity);
    }

    public class PedidoService : IPedidoService
    {
        private readonly IDataAccess sql;

        public PedidoService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<PedidoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<PedidoEntity>("PedidoObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<PedidoEntity> GetById(PedidoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<PedidoEntity>
                    ("PedidoObtener", new
                    {
                        entity.PedidoId
                    });
 

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<IEnumerable<PedidoEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<PedidoEntity>("PedidoLista");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<int> GetId()
        {
            try
            {
                var result = sql.QueryFirstAsync<int>("InicializarPedido");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        
        public async Task<DBEntity> Create(PedidoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PedidoClienteInsertar", new
                {

                    entity.PedidoId,
                    entity.Cliente


                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public async Task<DBEntity> Update(ProductosEntity entity)
        //{
        //    try
        //    {
        //        var result = sql.ExecuteAsync("ProductoActualizar", new
        //        {
        //            entity.ProductoId,
        //            entity.CategoriaId,
        //            entity.Producto,
        //            entity.Color,
        //            entity.Material,
        //            entity.Cantidad_Disponible,
        //            entity.Precio,
        //            entity.Estado

        //        });

        //        return await result;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public async Task<DBEntity> Delete(PedidoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PedidoEliminar", new
                {
                    entity.PedidoId,


                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
