using pryPlayers.Business.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pryPlayers.Business.Contracts.Services
{
    public interface IPlayerServiceRead
    {
        Task<PlayerDTO> Get(IdPlayerDTO id);
        IEnumerable<PlayerDTO> GetAll();
    }

    public interface IPlayerServiceWrite
    {
        Task<PlayerDTO> Add(PlayerDTO objDTO);
        Task<PlayerDTO> Update(PlayerDTO objDTO);
        Task<PlayerDTO> Delete(IdPlayerDTO id);
        Task<PlayerDTO> UpdatePuntaje(PlayerDTO objDTO);
    }
}
