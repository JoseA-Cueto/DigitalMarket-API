using DigitalMarket_API.Domain.Service.Resource.ProductResources;
using DigitalMarket_API.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMarket_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProduct product)
        {
            var productDto = await productsService.CreateAsync(product);
            return Ok(productDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProduct product)
        {
            var result = await productsService.UpdateAsync(product);
            return result.Match(
                productDto => Ok(productDto),
                error => Problem(
                    detail: error.Message,
                    statusCode: 500,
                    title: "Server Error"
                )
            );
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var error = await productsService.DeleteAsync(id);
            if (error is not null)
                return Problem(
                    detail: error.Message,
                    statusCode: 500,
                    title: "Server Error"
                );
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = await productsService.GetOneAsync(id);
            return result.Match(
                productDto => Ok(productDto),
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await productsService.GetAllAsync();
            return Ok(products);
        }
    }

}
