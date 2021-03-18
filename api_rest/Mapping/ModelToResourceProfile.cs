using api_rest.Domains.Models;
using api_rest.Resources;
using AutoMapper;

namespace api_rest.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
        }
    }
}