using System.Collections.Generic;
using System.Threading.Tasks;
using api_rest.Domains.Models;
using api_rest.Domains.Services;
using api_rest.Resources;
using api_rest.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace api_rest.Controllers
{
    [ApiController]
    [Route("/api/category")]
    
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);

            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
           if(!ModelState.IsValid)
           {
               return BadRequest(ModelState.GetErrorMessages());
           }

           var category = _mapper.Map<SaveCategoryResource, Category>(resource);
           var result = await _categoryService.SaveAsync(category);

           if(!result.Success)
           {
               return BadRequest(result.Massage);
           }

           var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
           return Ok(categoryResource);
        }
    }
}