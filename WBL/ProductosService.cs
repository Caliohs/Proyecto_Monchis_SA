using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{

    public interface IProductosService
    {
        Task<DBEntity> Create(ProductosEntity entity);
        Task<DBEntity> Delete(ProductosEntity entity);
        Task<IEnumerable<ProductosEntity>> Get();
        Task<ProductosEntity> GetById(ProductosEntity entity);
        Task<DBEntity> Update(ProductosEntity entity);
    }

    public class ProductosService : IProductosService
    {
        private readonly IDataAccess sql;

        public ProductosService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<ProductosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ProductosEntity, CategoriasEntity>("ProductoObtener", "ProductoId, CatgeoriaId");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<ProductosEntity> GetById(ProductosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ProductosEntity>("ProductoObtener", new
                {

                    entity.ProductoId

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<DBEntity> Create(ProductosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ProductoInsertar", new
                {

                    entity.CategoriaId,
                    entity.Producto,
                    entity.Color,
                    entity.Material,
                    entity.Cantidad_Disponible,
                    entity.Precio,
                    entity.Estado
                    


                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Update(ProductosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ProductoActualizar", new
                {
                    entity.ProductoId,
                    entity.CategoriaId,
                    entity.Producto,
                    entity.Color,
                    entity.Material,
                    entity.Cantidad_Disponible,
                    entity.Precio,
                    entity.Estado

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Delete(ProductosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ProductoEliminar", new
                {
                    entity.ProductoId,


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
