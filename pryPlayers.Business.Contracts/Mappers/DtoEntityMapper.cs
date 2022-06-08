using AutoMapper;
using pryPlayers.Business.Contracts.Models;
using pryPlayers.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace pryPlayers.Business.Contracts.Mappers
{
    public class DtoEntityMapper : Profile
    {
        public DtoEntityMapper()
        {
            #region From Entity to DTO
            CreateMap<PlayerEntity, PlayerDTO>()
                .ForMember(dest => dest.celular, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrWhiteSpace(src.celular));
                    opt.MapFrom(src => JsonSerializer.Deserialize<IList<CelularDTO>>(src.celular, null));
                });
            CreateMap<IdPlayerDTO, IdPlayerEntity>();
            #endregion

            #region From DTO to Entity
            CreateMap<PlayerDTO, PlayerEntity>()
                .ForMember(dest => dest.celular, opt =>
                {
                    opt.PreCondition(src => src.celular != null && src.celular.Count > 0);
                    opt.MapFrom(src => JsonSerializer.Serialize(src.celular, null));
                });
            CreateMap<IdPlayerDTO, IdPlayerEntity>();
            #endregion
        }
    }
}
