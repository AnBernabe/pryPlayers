using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pryPlayers.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pryPlayers.DataAccess.EntityConfig
{
    public class PlayerEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<PlayerEntity> entityBuilder)
        {
            entityBuilder.HasKey(e => new
            {
                e.idPlayer
            });

            entityBuilder.ToTable("plaPLAtPlayer");

            entityBuilder.HasIndex(e => e.idPlayer);

            entityBuilder.Property(e => e.idPlayer)
                .HasColumnName("PLAid_player")
                .HasMaxLength(100)
                .IsUnicode(false);

            entityBuilder.Property(e => e.name)
                .HasColumnName("PLAname")
                .HasMaxLength(100)
                .IsUnicode(false);

            entityBuilder.Property(e => e.lastname)
                .HasColumnName("PLAlastname")
                .HasMaxLength(100)
                .IsUnicode(false);

            entityBuilder.Property(e => e.puntaje)
                .HasColumnName("PLApuntaje");

            entityBuilder.Property(e => e.nivel)
                .HasColumnName("PLAnivel");

            entityBuilder.Property(e => e.celular)
                .HasColumnName("PLAcelular")
                .HasMaxLength(250)
                .IsUnicode(false);

            entityBuilder.Property(e => e.fechaRegistro).HasColumnName("PLAfecha_registro");

            entityBuilder.Property(e => e.fechaModificacion).HasColumnName("PLAfecha_modificacion");

            entityBuilder.Property(e => e.estado).HasColumnName("PLAestado");
        }
    }
}
