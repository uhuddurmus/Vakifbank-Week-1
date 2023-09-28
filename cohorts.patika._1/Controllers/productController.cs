using cohorts.patika._1.DataAccess.Abstract;
using cohorts.patika._1.Entities;
using Microsoft.AspNetCore.Mvc;
using cohorts.patika._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestfulApi.Controllers
{
    // "api/products" rotas� i�in denetleyici s�n�f� tan�mlan�yor.
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        // Denetleyici s�n�f�n�n yap�c� metodu, ba��ml�l�klar� al�r.
        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        // HTTP GET iste�i ile belirli bir �r�n�n detaylar�n� getiren metot.
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"{id} li m��teri getirildi.");
                return Ok(_productService.GetById(id));
            }

            return BadRequest(ModelState);
        }

        // HTTP GET iste�i ile �r�n listesini getiren metot.
        [HttpGet]
        public ActionResult<List<Product>> List([FromQuery] string? name, string order = "ASC")
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("�r�nler listelendi.");
                return Ok(_productService.GetList(name, order));
            }

            return BadRequest(ModelState);
        }

        // HTTP POST iste�i ile yeni bir �r�n olu�turan metot.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public IActionResult Create([FromBody] ProductsCreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(model);
                _logger.LogInformation("�r�n olu�turuldu.");
                return Ok();
            }

            return BadRequest(ModelState);
        }

        // HTTP PUT iste�i ile bir �r�n� g�ncelleyen metot.
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public IActionResult Update([FromBody] ProductsUpdateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdatePatch(model);
                _logger.LogInformation($"{model.Id} li �r�n g�ncellendi.");
                return Ok();
            }

            return BadRequest(ModelState);
        }

        // HTTP DELETE iste�i ile belirli bir �r�n� silen metot.
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _productService.Delete(id);
                _logger.LogInformation($"{id} li �r�n silindi.");
                return NoContent();
            }

            return BadRequest(ModelState);
        }
    }
}
