using Microsoft.EntityFrameworkCore;
using pryPlayers.DataAccess.Contracts;
using pryPlayers.DataAccess.Contracts.Entities;
using pryPlayers.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pryPlayers.DataAccess.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IPlayersDBContext _playersDBContext;

        public PlayerRepository(IPlayersDBContext playersDBContext)
        {
            _playersDBContext = playersDBContext;
        }

        public PlayerEntity Add(PlayerEntity entity)
        {
            var newEntity = _playersDBContext.Player.Add(entity);

            return newEntity.Entity;
        }

        public PlayerEntity Delete(PlayerEntity entity)
        {
            var deletedEntity = _playersDBContext.Player.Remove(entity);

            return deletedEntity.Entity;
        }

        public async Task<bool> Exist(IdPlayerEntity id)
        {
            var entity = await _playersDBContext.Player
                .AsNoTracking()
                .SingleOrDefaultAsync(r => r.idPlayer == id.idPlayer);

            return entity != null;
        }

        public async Task<PlayerEntity> Get(IdPlayerEntity id)
        {
            var result = await _playersDBContext.Player
                .AsNoTracking()
                .SingleAsync(r => r.idPlayer == id.idPlayer);

            return result;
        }

        public IEnumerable<PlayerEntity> GetAll()
        {
            var result = _playersDBContext.Player.AsNoTracking();

            return result;
        }

        public PlayerEntity Update(PlayerEntity entity)
        {
            var updateEntity = _playersDBContext.Player.Update(entity);

            return updateEntity.Entity;
        }

        public async Task SaveChanges()
        {
            await _playersDBContext.SaveChangesAsync();
        }
    }
}
