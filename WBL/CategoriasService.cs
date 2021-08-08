using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public class CategoriasService
    {
        private readonly IDataAccess sql;

        public CategoriasService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<CategoriasEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<CategoriasEntity>("CategoriaObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CategoriasEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<CategoriasEntity>("CategoriaLista");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CategoriasEntity> GetById(CategoriasEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<CategoriasEntity>("CategoriaObtener", new
                {

                    entity.CategoriaId

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Create(CategoriasEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CategoriaInsertar", new
                {

                    entity.Descripcion,
                    entity.Estado

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Update(CategoriasEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CategoriaActualizar", new
                {
                    entity.CategoriaId,
                    entity.Descripcion,
                    entity.Estado

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Delete(CategoriasEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CategoriaEliminar", new
                {
                    entity.CategoriaId,


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
