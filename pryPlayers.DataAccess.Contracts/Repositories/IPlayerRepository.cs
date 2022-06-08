using pryPlayers.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pryPlayers.DataAccess.Contracts.Repositories
{
    public interface IPlayerRepository : IRepository<PlayerEntity, IdPlayerEntity>
    {

    }
}
