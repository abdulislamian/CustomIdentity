using AspNetCoreHero.ToastNotification.Abstractions;
using CustomIdentity.Data;
using CustomIdentity.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomIdentity.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public CategoryController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }
        [Authorize(policy: "ViewCategoryRights")]
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
        [Authorize(policy: "CreateCategoryRights")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(policy: "CreateCategoryRights")]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                _notyf.Success("Category Added Successfully.", 3);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [Authorize(policy: "EditCategoryRights")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                _notyf.Error("Not Found.", 3);
                return NotFound();
            }

            var category = _context.Categories.Find(id);

            if (category == null)
            {
                _notyf.Error("Category Not Found.", 3);
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(policy: "EditCategoryRights")]
        public IActionResult Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                _notyf.Information("Category Update Successfully.", 3);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }
        [Authorize(policy: "DeleteCategoryRights")]

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                _notyf.Error("Not Found.", 3);
                return NotFound();
            }

            var category = _context.Categories.Find(id);

            if (category == null)
            {
                _notyf.Error("Category Not Found.", 3);
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(policy: "DeleteCategoryRights")]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _context.Categories.Find(id);
            if(category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                _notyf.Warning("Category Deleted Successfully.", 3);
                return RedirectToAction(nameof(Index));
            }
            _notyf.Error("Couldn't Delete Category.", 3);
            return View();
        }
    }

}
