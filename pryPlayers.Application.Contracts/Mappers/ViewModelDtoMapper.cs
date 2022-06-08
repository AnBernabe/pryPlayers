using AutoMapper;
using pryPlayers.Application.Contracts.Models.Celular;
using pryPlayers.Application.Contracts.Models.Player;
using pryPlayers.Business.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace pryPlayers.Application.Contracts.Mappers
{
    public class ViewModelDtoMapper : Profile
    {
        public ViewModelDtoMapper()
        {
            #region From DTO to ViewModel
            CreateMap<PlayerDTO, PlayerResponseViewModel>();
            CreateMap<PlayerDTO, PlayerPatchRequestViewModel>();
            CreateMap<PlayerDTO, PlayerPostRequestViewMocel>();
            CreateMap<PlayerDTO, PlayerPutRequestViewModel>();

            CreateMap<CelularDTO, CelularViewModel>();
            #endregion

            #region From ViewModel to DTO
            CreateMap<PlayerResponseViewModel, PlayerDTO>();
            CreateMap<PlayerPatchRequestViewModel, PlayerDTO>();
            CreateMap<PlayerPostRequestViewMocel, PlayerDTO>();
            CreateMap<PlayerPutRequestViewModel, PlayerDTO>();

            CreateMap<CelularViewModel, CelularDTO>();
            #endregion
        }
    }
}
