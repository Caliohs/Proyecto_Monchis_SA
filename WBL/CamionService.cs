using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface ICamionService
    {
        Task<DBEntity> Create(CamionEntity entity);
        Task<DBEntity> Delete(CamionEntity entity);
        Task<IEnumerable<CamionEntity>> Get();
        Task<CamionEntity> GetById(CamionEntity entity);
        Task<IEnumerable<CamionEntity>> GetLista();
        Task<DBEntity> Update(CamionEntity entity);
    }

    public class CamionService : ICamionService
    {
        private readonly IDataAccess sql;

        public CamionService(IDataAccess _sql)
        {
            sql = _sql;
        }



        public async Task<IEnumerable<CamionEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<CamionEntity,MarcaCamionEntity,ConductorEntity
                    >("CamionObtener","MarcaCamionId,ConductorId");

                return await result;
            }
            catch (Exception EX)
            {

                throw;
            }
        }
        public async Task<IEnumerable<CamionEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<CamionEntity>("CamionLista");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<CamionEntity> GetById(CamionEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<CamionEntity>("CamionObtener", new
                {
                    entity.CamionId
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<DBEntity> Create(CamionEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CamionInsertar", new
                {
                    entity.MarcaCamionId,
                    entity.ConductorId,
                    entity.Matricula,
                    entity.Color,
                    entity.FechaModelo,
                    entity.Estado,

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Update(CamionEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CamionActualizar", new
                {
                    entity.CamionId,
                    entity.MarcaCamionId,
                    entity.ConductorId,
                    entity.Matricula,
                    entity.Color,
                    entity.FechaModelo,
                    entity.Estado,
                }); ;

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Delete(CamionEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("CamionEliminar", new
                {
                    entity.CamionId,
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
