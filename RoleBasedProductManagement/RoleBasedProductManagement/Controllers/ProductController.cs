using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleBasedProductManagement.Data;
using RoleBasedProductManagement.Models;

namespace RoleBasedProductManagement.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ProductList()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct() => View();

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(model);
                _context.SaveChanges();
                TempData["Message"] = $"Product \"{model.Name}\" has been successfully created!";
                return RedirectToAction("ProductList");
            }
            return View(model);
        }

        public IActionResult EditProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(model);
                _context.SaveChanges();
                TempData["Message"] = $"Product \"{model.Name}\" has been successfully updated!";
                return RedirectToAction("ProductList");
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            TempData["Message"] = $"Product \"{product.Name}\" has been deleted!";
            return RedirectToAction("ProductList");
        }
    }
}
