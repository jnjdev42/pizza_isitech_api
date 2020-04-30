using AutoMapper;
using Pizza.Entities;
using Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Profiles
{
    public class LigneCommandeProfile : Profile
    {
        public LigneCommandeProfile()
        {
            CreateMap<LigneCommandeForUpdateDto, Ligne_Cde_Cli>();

            CreateMap<LigneCommandeForCreateDto, Ligne_Cde_Cli>();
        }
    }
}
