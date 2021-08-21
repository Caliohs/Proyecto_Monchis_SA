using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IPedidoPorProductoService
    {
        Task<IEnumerable<PedidoPorProductoEntity>> GetByIdDetails(PedidoPorProductoEntity entity);
        Task<DBEntity> Create(PedidoPorProductoEntity entity);
    }

    public class PedidoPorProductoService : IPedidoPorProductoService
    {
        private readonly IDataAccess sql;

        public PedidoPorProductoService(IDataAccess _sql)
        {
            sql = _sql;
        }

        
        public async Task<IEnumerable<PedidoPorProductoEntity>> GetByIdDetails(PedidoPorProductoEntity entity)
        {
           
            try
            {
                var result = sql.QueryAsync<PedidoPorProductoEntity,ProductosEntity>
                    ("PedidoObtenerDetalle", "PedidoPorProductoId,ProductoId", entity.PedidoId);

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Create(PedidoPorProductoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PedidoProductoInsertar", new
                {

                    entity.ProductoId,
                    entity.PedidoId,
                    entity.Cantidad
                   
                    
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

        //public async Task<DBEntity> Delete(ProductosEntity entity)
        //{
        //    try
        //    {
        //        var result = sql.ExecuteAsync("ProductoEliminar", new
        //        {
        //            entity.ProductoId,


        //        });

        //        return await result;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

    }
}
