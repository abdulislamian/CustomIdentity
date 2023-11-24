using AspNetCoreHero.ToastNotification.Abstractions;
using CustomIdentity.Data;
using CustomIdentity.Models;
using CustomIdentity.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentity.Controllers
{
    public class ProductController : Controller
    {
        public ApplicationDbContext _context { get; }
        public INotyfService _notyf { get; }

        public ProductController(ApplicationDbContext context,INotyfService notfy)
        {
            _context = context;
            _notyf = notfy;
        }
        //[Authorize(policy: "PolicyTypes.Products.Manage")]
        [Authorize(policy: "ViewRights")]
        //[Authorize(policy: "FullProductAccess")]

        public IActionResult Index()
        {
            var products = _context.Products.Include(p => p.Subcategory).ThenInclude(s => s.Category).ToList();
            return View(products);
        }

        [Authorize(policy: "CreateRights")]
        public IActionResult Create()
        {
            ViewBag.Subcategories = GetSubcategorySelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(policy: "CreateRights")]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                _notyf.Success($"{product.Name} Created Successfully.", 3);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Subcategories = GetSubcategorySelectList();
            return View(product);
        }

        [Authorize(policy: "EditRights")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                _notyf.Error($"Product Id is Null", 3);
                return NotFound();
            }

            var product = _context.Products.Include(p => p.Subcategory).ThenInclude(s => s.Category).FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                _notyf.Error($"Product Against Id is not Found.", 3);
                return NotFound();
            }

            ViewBag.Subcategories = GetSubcategorySelectList(product.Subcategory.CategoryId, product.SubcategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(policy: "EditRights")]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                _notyf.Information($"{product.Name} Updated Successfully.", 3);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Subcategories = GetSubcategorySelectList(product.Subcategory.CategoryId, product.SubcategoryId);
            return View(product);
        }

        [Authorize(policy: "DeleteRights")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                _notyf.Error($"Not Found.", 3);
                return NotFound();
            }

            var product = _context.Products.Include(p => p.Subcategory).ThenInclude(s => s.Category).FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                _notyf.Success($"Product not Found.", 3);
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(policy: "DeleteRights")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                _notyf.Error($"{product.Name} Deleted Successfully.", 3);
                return RedirectToAction(nameof(Index));
            }
            _notyf.Warning($"{product.Name} Deleted Successfully.", 3);
            return View();
        }

        private SelectList GetSubcategorySelectList(int? categoryId = null, int? selectedSubcategoryId = null)
        {
            var subcategories = _context.Subcategories.Where(s => categoryId == null || s.CategoryId == categoryId).ToList();
            //var subcategories = _context.Subcategories.ToList(); ;
            return new SelectList(subcategories, nameof(Subcategory.Id), nameof(Subcategory.Name), selectedSubcategoryId);
        }
    }
}
