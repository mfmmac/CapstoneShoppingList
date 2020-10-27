using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapstoneShoppingList.Context;
using CapstoneShoppingList.Models;

namespace CapstoneShoppingList.Controllers
{
    public class ProductsController : Controller
    {
        private readonly InventoryContext _context;
        private ShoppingCartModel _shoppingCartModel;

        public ProductsController(InventoryContext context, ShoppingCartModel shoppingCartModel)
        {
            _context = context;
            _shoppingCartModel = shoppingCartModel;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> ShoppingCart(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _shoppingCartModel.ShoppingList.Add(product);
            _shoppingCartModel.Total += product.ProductPrice;
            return View(_shoppingCartModel);
        }

        public IActionResult Checkout()
        {
            var model = new CheckoutModel();
            model.ShoppingList = _shoppingCartModel.ShoppingList;
            model.Total = _shoppingCartModel.Total;
            model.Tax = Decimal.Multiply(model.Total, (decimal)0.06);
            model.GrandTotal = Decimal.Add(model.Total, model.Tax);
            return View(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (id != products.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = products.ProductID }, products);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return products;
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}

