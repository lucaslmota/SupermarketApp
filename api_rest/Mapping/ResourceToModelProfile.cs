using api_rest.Domains.Models;
using api_rest.Resources;
using AutoMapper;

namespace api_rest.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
        }
    }
}