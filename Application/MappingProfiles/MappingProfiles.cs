using System;
using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Video, VideoDto>();
        }
    }
}
