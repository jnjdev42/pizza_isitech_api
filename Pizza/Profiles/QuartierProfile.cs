using AutoMapper;
using Pizza.Entities;
using Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Profiles
{
    public class QuartierProfile : Profile
    {
        public QuartierProfile()
        {
            CreateMap<QuartierForUpdateDto, Num_Cde_Cli>();

            CreateMap<QuartierForCreateDto, Num_Cde_Cli>();
        }
    }
}
