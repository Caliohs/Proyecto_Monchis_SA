using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IEntregaService
    {
        Task<DBEntity> Create(EntregaEntity entity);
        Task<DBEntity> Delete(EntregaEntity entity);
        Task<IEnumerable<EntregaEntity>> Get();
    }

    public class EntregaService : IEntregaService
    {
        private readonly IDataAccess sql;

        public EntregaService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<EntregaEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<EntregaEntity, PedidoEntity, CamionEntity>("EntregaObtener", "PedidoId, CamionId");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //public async Task<ProductosEntity> GetById(ProductosEntity entity)
        //{
        //    try
        //    {
        //        var result = sql.QueryFirstAsync<ProductosEntity>("ProductoObtener", new
        //        {

        //            entity.ProductoId

        //        });

        //        return await result;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}


        public async Task<DBEntity> Create(EntregaEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("EntregaInsertar", new
                {

                    entity.PedidoId,
                    entity.CamionId,
                    entity.Provincia,
                    entity.Canton,
                    entity.Distrito,
                    entity.FechaEntrega,
                    entity.Estado
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

        public async Task<DBEntity> Delete(EntregaEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("EntregaEliminar", new
                {
                    entity.EntregaId,
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
