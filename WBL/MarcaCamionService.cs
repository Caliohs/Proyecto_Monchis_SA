using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IMarcaCamionService
    {
        Task<DBEntity> Create(MarcaCamionEntity entity);
        Task<DBEntity> Delete(MarcaCamionEntity entity);
        Task<IEnumerable<MarcaCamionEntity>> Get();
        Task<MarcaCamionEntity> GetById(MarcaCamionEntity entity);
        Task<IEnumerable<MarcaCamionEntity>> GetLista();
        Task<DBEntity> Update(MarcaCamionEntity entity);
    }

    public class MarcaCamionService : IMarcaCamionService
    {
        private readonly IDataAccess sql;

        public MarcaCamionService(IDataAccess _sql)
        {
            sql = _sql;
        }


        public async Task<IEnumerable<MarcaCamionEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<MarcaCamionEntity>("MarcaCamionObtener");

                return await result;
            }
            catch (Exception EX)
            {

                throw;
            }
        }

        public async Task<IEnumerable<MarcaCamionEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<MarcaCamionEntity>("MarcaCamionLista");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<MarcaCamionEntity> GetById(MarcaCamionEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<MarcaCamionEntity>("MarcaCamionObtener", new
                {
                    entity.MarcaCamionId
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<DBEntity> Create(MarcaCamionEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("MarcaCamionInsertar", new
                {
                    entity.Descripcion,
                    entity.Estado,


                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Update(MarcaCamionEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("MarcaCamionActualizar", new
                {
                    entity.MarcaCamionId,
                    entity.Descripcion,
                    entity.Estado,
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Delete(MarcaCamionEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("MarcaCamionEliminar", new
                {
                    entity.MarcaCamionId,
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
