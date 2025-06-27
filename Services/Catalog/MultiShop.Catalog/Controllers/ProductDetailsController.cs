using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailDetailService;

        public ProductDetailsController(IProductDetailService roductDetailService)
        {
            _productDetailDetailService = roductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductDetails()
        {
            var productDetails = await _productDetailDetailService.GetAllProductDetailAsync();
            return Ok(productDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var roductDetail = await _productDetailDetailService.GetByIdProductDetailAsync(id);
            if (roductDetail == null)
            {
                return NotFound();
            }
            return Ok(roductDetail);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün detayı eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün detayı silindi.");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün detayı güncellendi.");
        }
    }
}
