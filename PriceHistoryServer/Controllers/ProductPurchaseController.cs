using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PriceHistoryServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PriceHistoryServer.Controllers
{
    [Route("api/[controller]")]
    public class ProductPurchaseController : Controller
    {
        private readonly PriceHistoryContext _context;

        public ProductPurchaseController(PriceHistoryContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
           var productsPrices = new Dictionary<Product, List<decimal>>();

            _context.ProductPurchases.Include(pp => pp.Product).ToList().ForEach(pp =>
            {
                var pricesList = new List<decimal>();
                if (productsPrices.TryGetValue(pp.Product, out pricesList))
                {
                    pricesList.Add(pp.Price);
                }
                else
                {
                    productsPrices.Add(pp.Product, new List<decimal>() { pp.Price });
                }
            });

            var productsAveragePrice = new Dictionary<Product, decimal>();

            var averages = productsPrices.Select(p => new ProductAveragePrice
            {
                Product = p.Key,
                AveragePrice = p.Value.Average()
            });

            return Ok(averages);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Purchase([FromBody]ProductPurchase purchase)
        {
            try
            {
                if (_context.Products.Any(p => p.Equals(purchase.Product)))
                {
                    _context.Products.Add(purchase.Product);
                } 

                _context.ProductPurchases.Add(purchase);

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpPost]
        void Post()
        {
            return;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
