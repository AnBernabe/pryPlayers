using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pryPlayers.Application.Contracts.Models.Player;
using pryPlayers.Business.Contracts.Models;
using pryPlayers.Business.Contracts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pryPlayers_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlayerServiceRead _playerServiceRead;
        private readonly IPlayerServiceWrite _playerServiceWrite;

        public PlayerController(
            IMapper mapper,
            IPlayerServiceRead playerServiceRead,
            IPlayerServiceWrite playerServiceWrite)
        {
            _mapper = mapper;
            _playerServiceRead = playerServiceRead;
            _playerServiceWrite = playerServiceWrite;
        }

        /// <summary>
        /// Devuelve el jugador con el id solicitado
        /// </summary>
        /// <param name="idPlayer">Es el identificador unico de un jugador</param>
        /// <returns>Devuelve un modelo del jugador</returns>
        [ProducesResponseType(200)] //Correcto
        [ProducesResponseType(204)] //No encontrado
        [ProducesResponseType(500)] //Server Error
        [ProducesResponseType(401)] //No esta autentificado
        [HttpGet("{idPlayer}")]
        public async Task<IActionResult> Get(string idPlayer)
        {
            var id = new IdPlayerDTO()
            {
                idPlayer = idPlayer
            };

            var result = _mapper.Map<PlayerResponseViewModel>(await _playerServiceRead.Get(id));

            return Ok(result);
        }

        /// <summary>
        /// Devuelve todos los jugadores
        /// </summary>
        /// <returns>Devuelve una lista con los modelos del jugador</returns>
        [ProducesResponseType(200)] //Correcto
        [ProducesResponseType(204)] //No encontrado
        [ProducesResponseType(500)] //Server Error
        [ProducesResponseType(401)] //No esta autentificado
        [HttpGet]
        public IActionResult Get()
        {
            var result = _mapper.Map<IEnumerable<PlayerResponseViewModel>>(_playerServiceRead.GetAll());

            return Ok(result);
        }

        /// <summary>
        /// Agrega un nuevo jugador
        /// </summary>
        /// <param name="player">Es el modelo del jugador, que sera añadido</param>
        /// <returns>string: Resultado de la operación</returns>
        [ProducesResponseType(200)] //Correcto
        [ProducesResponseType(500)] //Server Error
        [ProducesResponseType(401)] //No esta autentificado
        [Produces("application/json", Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlayerPostRequestViewMocel player)
        {
            var result = await _playerServiceWrite.Add(_mapper.Map<PlayerDTO>(player));

            return Ok(result);
        }

        /// <summary>
        /// Actualiza un jugador
        /// </summary>
        /// <param name="player">Contiene todos los nuevos valores que tendrá el jugador</param>
        /// <returns>string: Resultado de la operación</returns>
        [ProducesResponseType(200)] //Correcto
        [ProducesResponseType(500)] //Server Error
        [ProducesResponseType(401)] //No esta autentificado
        [Produces("application/json", Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PlayerPutRequestViewModel player)
        {
            var result = await _playerServiceWrite.Update(_mapper.Map<PlayerDTO>(player));

            return Ok(result);
        }

        /// <summary>
        /// Actualiza el puntaje de un jugador
        /// </summary>
        /// <param name="player">Contiene todos los nuevos valores que tendrá el jugador</param>
        /// <returns>string: Resultado de la operación</returns>
        [ProducesResponseType(200)] //Correcto
        [ProducesResponseType(500)] //Server Error
        [ProducesResponseType(401)] //No esta autentificado
        [Produces("application/json", Type = typeof(string))]
        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] PlayerPatchRequestViewModel player)
        {
            var result = await _playerServiceWrite.UpdatePuntaje(_mapper.Map<PlayerDTO>(player));

            return Ok(result);
        }

        /// <summary>
        /// Elimina un jugador
        /// </summary>
        /// <param name="idPlayer">Es el identificador unico de un jugador</param>
        /// <returns>string: Resultado de la operación</returns>
        [ProducesResponseType(200)] //Correcto
        [ProducesResponseType(500)] //Server Error
        [ProducesResponseType(401)] //No esta autentificado
        [Produces("application/json", Type = typeof(string))]
        [HttpDelete("{idPlayer}")]
        public async Task<IActionResult> Delete(string idPlayer)
        {
            var id = new IdPlayerDTO()
            {
                idPlayer = idPlayer
            };

            var result = await _playerServiceWrite.Delete(id);

            return Ok(result);
        }
    }
}
