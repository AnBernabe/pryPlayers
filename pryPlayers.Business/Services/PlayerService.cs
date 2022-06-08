using AutoMapper;
using pryPlayers.Business.Contracts.Models;
using pryPlayers.Business.Contracts.Services;
using pryPlayers.DataAccess.Contracts.Entities;
using pryPlayers.DataAccess.Contracts.Enum;
using pryPlayers.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pryPlayers.Business.Services
{
    public class PlayerService : IPlayerServiceRead, IPlayerServiceWrite
    {
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _repository;

        public PlayerService(
            IMapper mapper,
            IPlayerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PlayerDTO> Add(PlayerDTO objDTO)
        {
            var id = new IdPlayerDTO()
            {
                idPlayer = objDTO.idPlayer
            };

            var entityExist = await _repository.Exist(_mapper.Map<IdPlayerEntity>(id));

            if (entityExist)
                throw new Exception("El jugador ya está registrado en el sistema, por favor actualice la página.");

            if (!Enum.IsDefined(typeof(PlayerNivelEnum), objDTO.nivel))
                throw new Exception("El nivel del jugador no coincide con ninguno definido.");
          
            objDTO.idPlayer = Guid.NewGuid().ToString();
            objDTO.fechaRegistro = objDTO.fechaModificacion = DateTime.Now;
            objDTO.estado = 1;
            objDTO.name = objDTO.name?.Trim();
            objDTO.lastname = objDTO.lastname?.Trim();

            var newEntity = _repository.Add(_mapper.Map<PlayerEntity>(objDTO));

            await _repository.SaveChanges();

            return _mapper.Map<PlayerDTO>(newEntity);
        }

        public async Task<PlayerDTO> Delete(IdPlayerDTO id)
        {
            var idEntity = _mapper.Map<IdPlayerEntity>(id);

            var exist = await _repository.Exist(idEntity);

            if (!exist)
            {
                throw new Exception("El jugador no está registrado en el sistema, por favor actualice la página.");
            }

            var entity = await _repository.Get(idEntity);

            var newEntity = _repository.Delete(entity);

            await _repository.SaveChanges();

            return _mapper.Map<PlayerDTO>(newEntity);
        }

        public async Task<PlayerDTO> Get(IdPlayerDTO id)
        {
            var idEntity = _mapper.Map<IdPlayerEntity>(id);

            var exist = await _repository.Exist(idEntity);

            if (!exist)
                return null;

            var entity = await _repository.Get(idEntity);

            var objDTO = _mapper.Map<PlayerDTO>(entity);

            return objDTO;
        }

        public IEnumerable<PlayerDTO> GetAll()
        {
            var getAllEntities = _repository.GetAll();

            return _mapper.Map<IEnumerable<PlayerDTO>>(getAllEntities);
        }

        public async Task<PlayerDTO> Update(PlayerDTO objDTO)
        {
            var id = new IdPlayerDTO()
            {
                idPlayer = objDTO.idPlayer,
            };

            var idEntity = _mapper.Map<IdPlayerEntity>(id);

            var exist = await _repository.Exist(idEntity);

            if (!exist)
                throw new Exception("El jugador no está registrado en el sistema, por favor actualice la página.");

            if (!Enum.IsDefined(typeof(PlayerNivelEnum), objDTO.nivel))
                throw new Exception("El nivel del jugador no coincide con ninguno definido.");

            var entity = await _repository.Get(idEntity);

            entity.name = objDTO.name?.Trim();
            entity.lastname = objDTO.lastname?.Trim();
            entity.fechaModificacion = DateTime.Now;
            entity.estado = objDTO.estado;
            entity.name = objDTO.name;
            entity.lastname = objDTO.lastname;
            entity.puntaje = objDTO.puntaje;
            entity.nivel = objDTO.nivel;
            entity.celular = JsonSerializer.Serialize(objDTO.celular);

            var newEntity = _repository.Update(entity);

            await _repository.SaveChanges();

            return _mapper.Map<PlayerDTO>(newEntity);
        }

        public async Task<PlayerDTO> UpdatePuntaje(PlayerDTO objDTO)
        {
            var id = new IdPlayerDTO()
            {
                idPlayer = objDTO.idPlayer,
            };

            var idEntity = _mapper.Map<IdPlayerEntity>(id);

            var exist = await _repository.Exist(idEntity);

            if (!exist)
                throw new Exception("El jugador no está registrado en el sistema, por favor actualice la página.");

            var entity = await _repository.Get(idEntity);

            entity.fechaModificacion = DateTime.Now;
            entity.puntaje = objDTO.puntaje;

            var newEntity = _repository.Update(entity);

            await _repository.SaveChanges();

            return _mapper.Map<PlayerDTO>(newEntity);
        }
    }
}
