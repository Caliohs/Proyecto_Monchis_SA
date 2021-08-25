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
        Task<EntregaEntity> GetById(EntregaEntity entity);
        Task<DBEntity> Update(EntregaEntity entity);
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
                var result = sql.QueryAsync<EntregaEntity, PedidoEntity, CamionEntity,CatalogoProvinciaEntity, CatalogoCantonEntity, CatalogoDistritoEntity>
                    ("EntregaObtener", "PedidoId, CamionId, IdCatalogoProvincia, IdCatalogoCanton, IdCatalogoDistrito");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<EntregaEntity> GetById(EntregaEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<EntregaEntity>("EntregaObtener", new
                {

                    entity.EntregaId

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<DBEntity> Create(EntregaEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("EntregaInsertar", new
                {

                    entity.PedidoId,
                    entity.CamionId,
                    entity.ProvinciaId,
                    entity.CantonId,
                    entity.DistritoId,
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

        public async Task<DBEntity> Update(EntregaEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("EntregaActualizar", new
                {
                    entity.EntregaId,
                    entity.CamionId,
                    entity.PedidoId,
                    entity.ProvinciaId,
                    entity.CantonId,
                    entity.DistritoId,
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
