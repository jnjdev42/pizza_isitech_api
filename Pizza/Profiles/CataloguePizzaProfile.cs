using AutoMapper;
using Pizza.Entities;
using Pizza.Models;

namespace Pizza.Profiles
{
    public class CataloguePizzaProfile : Profile
    {
        public CataloguePizzaProfile()
        {
            CreateMap<CataloguePizzaForUpdateDto, Catalogue_Pizza>();

            CreateMap<CataloguePizzaForCreateDto, Catalogue_Pizza>();
        }
    }
}
