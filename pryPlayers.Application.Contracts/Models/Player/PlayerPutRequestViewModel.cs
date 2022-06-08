using pryPlayers.Application.Contracts.Models.Celular;
using System;
using System.Collections.Generic;
using System.Text;

namespace pryPlayers.Application.Contracts.Models.Player
{
    public class PlayerPutRequestViewModel
    {
        public string idPlayer { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public int puntaje { get; set; }
        public short nivel { get; set; }
        public short estado { get; set; }

        public IList<CelularViewModel> celular { get; set; }
    }
}
