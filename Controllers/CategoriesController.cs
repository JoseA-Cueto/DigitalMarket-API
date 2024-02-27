using DigitalMarket_API.Domain.Service.Resource.CategoryResources;
using DigitalMarket_API.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMarket_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoriesService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = await categoriesService.GetOneAsync(id);
            return result.Match(
                categoryDto => Ok(categoryDto),
                error => error switch
                {
                    Error { Reason: ErrorReason.NotFound } => Problem(
                        detail: error.Message,
                        statusCode: 404,
                        title: "Server Error"
                    ),
                    _ => Problem(
                        detail: error.Message,
                        statusCode: 500,
                        title: "Server Error"
                    )
                }
            );
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var error = await categoriesService.DeleteAsync(id);
            if (error is not null)
                return Problem(
                    detail: error.Message,
                    statusCode: 500,
                    title: "Server Error"
                );
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategory categories)
        {
            var categoryDto = await categoriesService.CreateAsync(categories);
            return Ok(categoryDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategory categories)
        {
            var result = await categoriesService.UpdateAsync(categories);
            return result.Match(
                categoryDto => Ok(categoryDto),
                error => Problem(
                    detail: error.Message,
                    statusCode: 500,
                    title: "Server Error"
                )
            );
        }
    }

}
