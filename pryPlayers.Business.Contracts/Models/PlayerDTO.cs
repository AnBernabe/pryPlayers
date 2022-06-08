using pryPlayers.DataAccess.Contracts.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace pryPlayers.Business.Contracts.Models
{
    public class PlayerDTO : IdPlayerDTO
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public int puntaje { get; set; }
        public PlayerNivelEnum nivel { get; set; }
        public DateTime fechaRegistro { get; set; }
        public DateTime fechaModificacion { get; set; }
        public short estado { get; set; }

        public IList<CelularDTO> celular { get; set; }
    }

    public class IdPlayerDTO
    {
        public string idPlayer { get; set; }
    }
}
