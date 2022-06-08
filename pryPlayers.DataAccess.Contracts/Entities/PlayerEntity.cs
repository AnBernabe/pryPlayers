using pryPlayers.DataAccess.Contracts.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace pryPlayers.DataAccess.Contracts.Entities
{
    public partial class PlayerEntity : IdPlayerEntity
    {
        public string name  { get; set; }
        public string lastname { get; set; }
        public int puntaje { get; set; }
        public PlayerNivelEnum nivel { get; set; }
        public string celular { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime fechaModificacion { get; set; }
        public short estado { get; set; }
    }

    public partial class IdPlayerEntity
    {
        public string idPlayer { get; set; }
    }
}
