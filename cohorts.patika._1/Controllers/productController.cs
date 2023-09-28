using cohorts.patika._1.DataAccess.Abstract;
using cohorts.patika._1.Entities;
using Microsoft.AspNetCore.Mvc;
using cohorts.patika._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestfulApi.Controllers
{
    // "api/products" rotasý için denetleyici sýnýfý tanýmlanýyor.
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        // Denetleyici sýnýfýnýn yapýcý metodu, baðýmlýlýklarý alýr.
        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        // HTTP GET isteði ile belirli bir ürünün detaylarýný getiren metot.
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"{id} li müþteri getirildi.");
                return Ok(_productService.GetById(id));
            }

            return BadRequest(ModelState);
        }

        // HTTP GET isteði ile ürün listesini getiren metot.
        [HttpGet]
        public ActionResult<List<Product>> List([FromQuery] string? name, string order = "ASC")
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Ürünler listelendi.");
                return Ok(_productService.GetList(name, order));
            }

            return BadRequest(ModelState);
        }

        // HTTP POST isteði ile yeni bir ürün oluþturan metot.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public IActionResult Create([FromBody] ProductsCreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(model);
                _logger.LogInformation("Ürün oluþturuldu.");
                return Ok();
            }

            return BadRequest(ModelState);
        }

        // HTTP PUT isteði ile bir ürünü güncelleyen metot.
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public IActionResult Update([FromBody] ProductsUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdatePatch(model);
                _logger.LogInformation($"{model.Id} li ürün güncellendi.");
                return Ok();
            }

            return BadRequest(ModelState);
        }

        // HTTP DELETE isteði ile belirli bir ürünü silen metot.
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _productService.Delete(id);
                _logger.LogInformation($"{id} li ürün silindi.");
                return NoContent();
            }

            return BadRequest(ModelState);
        }
    }
}
