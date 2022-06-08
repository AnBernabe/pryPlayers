using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using pryPlayers.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pryPlayers.DataAccess.Contracts
{
    public interface IPlayersDBContext
    {
        DbSet<PlayerEntity> Player { get; set; }

        //Metodos que nos permiten usar metodos de EF
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        void RemoveRange(IEnumerable<object> entities);
        EntityEntry Update(object entity);
        Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default);

    }
}
