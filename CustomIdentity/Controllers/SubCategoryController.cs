using AspNetCoreHero.ToastNotification.Abstractions;
using CustomIdentity.Data;
using CustomIdentity.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentity.Controllers
{
    // SubcategoryController.cs
    public class SubcategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public SubcategoryController(ApplicationDbContext context,INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        [Authorize(policy: "ViewsubCategoryRights")]
        public IActionResult Index()
        {
            var subcategories = _context.Subcategories.Include(s => s.Category).ToList();
            return View(subcategories);
        }

        [Authorize(policy: "CreatesubCategoryRights")]

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [Authorize(policy: "CreatesubCategoryRights")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                _context.Subcategories.Add(subcategory);
                _context.SaveChanges();
                _notyf.Success("SubCategory Added Successfully.", 3);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(subcategory);
        }

        [Authorize(policy: "EditsubCategoryRights")]

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                _notyf.Error("Not Found", 3);
                return NotFound();
            }

            var subcategory = _context.Subcategories.Find(id);

            if (subcategory == null)
            {
                _notyf.Error("SubCategory Not Found.", 3);
                return NotFound();
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(subcategory);
        }

        [Authorize(policy: "EditsubCategoryRights")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Subcategory subcategory)
        {
            if (id != subcategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Subcategories.Update(subcategory);
                _context.SaveChanges();
                _notyf.Success("SubCategory Updated Successfully.", 3);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(subcategory);
        }

        [Authorize(policy: "DeletesubCategoryRights")]

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                _notyf.Warning("Not Found.", 3);
                return NotFound();
            }

            var subcategory = _context.Subcategories.Include(s => s.Category).FirstOrDefault(s => s.Id == id);

            if (subcategory == null)
            {
                _notyf.Warning("SubCategory Not Found.", 3);
                return NotFound();
            }

            return View(subcategory);
        }

        [Authorize(policy: "DeletesubCategoryRights")]

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var subcategory = _context.Subcategories.Find(id);
            if(subcategory != null)
            {
                _context.Subcategories.Remove(subcategory);
                _context.SaveChanges();
                _notyf.Success("SubCategory Deleted Successfully.", 3);
                return RedirectToAction(nameof(Index));
            }
            _notyf.Error("Couldn't Delete SubCategory", 3);
            return View();
        }
    }

}
