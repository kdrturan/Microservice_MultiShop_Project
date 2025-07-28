using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductImages()
        {
            var productImages = await _productImageService.GetAllProductImageAsync();
            return Ok(productImages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var productImage = await _productImageService.GetByIdProductImageAsync(id);
            if (productImage == null)
            {
                return NotFound();
            }
            return Ok(productImage);
        }



        [HttpGet("get-by-productid")]
        public async Task<IActionResult> GetByProductIdProductImages(string id)
        {
            var productImage = await _productImageService.GetByProductIdProductImagesAsync(id);
            if (productImage == null)
            {
                return NotFound();
            }
            return Ok(productImage);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün Görselleri eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün Görselleri silindi.");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün Görselleri güncellendi.");
        }
    }
}
