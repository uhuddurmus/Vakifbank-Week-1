using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestfulApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Create a list of Product objects to simulate a database
        private List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.99 },
            new Product { Id = 2, Name = "Product 2", Price = 19.99 },
            // Add more products here
        };

        // HTTP GET request to retrieve all products
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        // HTTP GET request to retrieve a specific product by its ID
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); // Return HTTP 404 Not Found if the product is not found
            }

            return Ok(product);
        }

        // HTTP POST request to create a new product
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest(); // Return HTTP 400 Bad Request if the request body is empty or malformed
            }

            if (string.IsNullOrEmpty(product.Name) || product.Price <= 0)
            {
                return BadRequest(new { error = "Name and price are required fields." }); // Return a detailed error message
            }

            product.Id = products.Count + 1;
            products.Add(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product); // Return HTTP 201 Created with the newly created product
        }

        // HTTP PUT request to update an existing product
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            if (updatedProduct == null || updatedProduct.Id != id)
            {
                return BadRequest(); // Return HTTP 400 Bad Request if the request body is empty, malformed, or if the IDs don't match
            }

            var existingProduct = products.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null)
            {
                return NotFound(); // Return HTTP 404 Not Found if the product to be updated doesn't exist
            }

            if (string.IsNullOrEmpty(updatedProduct.Name) || updatedProduct.Price <= 0)
            {
                return BadRequest(new { error = "Name and price are required fields." }); // Return a detailed error message
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;

            return Ok(existingProduct); // Return HTTP 200 OK with the updated product
        }

        // HTTP DELETE request to delete a product by its ID
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); // Return HTTP 404 Not Found if the product to be deleted doesn't exist
            }

            products.Remove(product);

            return NoContent(); // Return HTTP 204 No Content after successful deletion
        }

        // HTTP GET request to retrieve products by name, with optional query parameter
        [HttpGet("list")]
        public IActionResult GetProductsByName([FromQuery] string name)
        {
            var filteredProducts = products;

            if (!string.IsNullOrEmpty(name))
            {
                // Filter products by name case-insensitively
                filteredProducts = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Sort the filtered products by name
            filteredProducts = filteredProducts.OrderBy(p => p.Name).ToList();

            return Ok(filteredProducts);
        }
    }

    // Define a Product class to represent product data
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
