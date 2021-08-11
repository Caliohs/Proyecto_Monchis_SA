using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IConductorService
    {
        Task<DBEntity> Create(ConductorEntity entity);
        Task<DBEntity> Delete(ConductorEntity entity);
        Task<IEnumerable<ConductorEntity>> Get();
        Task<ConductorEntity> GetById(ConductorEntity entity);
        Task<IEnumerable<ConductorEntity>> GetLista();
        Task<DBEntity> Update(ConductorEntity entity);
    }

    public class ConductorService : IConductorService
    {
        private readonly IDataAccess sql;

        public ConductorService(IDataAccess _sql)
        {
            sql = _sql;
        }


        public async Task<IEnumerable<ConductorEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ConductorEntity>("ConductorObtener");

                return await result;
            }
            catch (Exception EX)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ConductorEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<ConductorEntity>("ConductorLista");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<ConductorEntity> GetById(ConductorEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ConductorEntity>("ConductorObtener", new
                {
                    entity.ConductorId
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<DBEntity> Create(ConductorEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ConductorInsertar", new
                {
                    entity.CedulaConductor,
                    entity.NombreCompleto,
                    entity.Telefono,
                    entity.Edad,
                    entity.Estado,

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Update(ConductorEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ConductorActualizar", new
                {
                    entity.ConductorId,                   
                    entity.NombreCompleto,
                    entity.Telefono,
                    entity.Edad,
                    entity.Estado,
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Delete(ConductorEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ConductorEliminar", new
                {
                    entity.ConductorId,
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
