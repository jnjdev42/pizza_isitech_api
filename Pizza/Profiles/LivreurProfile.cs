using AutoMapper;
using Pizza.Entities;
using Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Profiles
{
    public class LivreurProfile : Profile
    {
        public LivreurProfile()
        {
            CreateMap<LivreurForUpdateDto, Livreur>();

            CreateMap<LivreurForCreateDto, Livreur>();
        }
    }
}
