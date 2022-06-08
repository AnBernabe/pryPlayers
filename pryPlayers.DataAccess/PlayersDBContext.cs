using Microsoft.EntityFrameworkCore;
using pryPlayers.DataAccess.Contracts;
using pryPlayers.DataAccess.Contracts.Entities;
using pryPlayers.DataAccess.EntityConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace pryPlayers.DataAccess
{
    public class PlayersDBContext : DbContext, IPlayersDBContext
    {
        public PlayersDBContext()
        {
        }

        public PlayersDBContext(DbContextOptions<PlayersDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PlayerEntity> Player { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PlayerEntityConfig.SetEntityBuilder(modelBuilder.Entity<PlayerEntity>());
         
            base.OnModelCreating(modelBuilder);
        }
    }
}
