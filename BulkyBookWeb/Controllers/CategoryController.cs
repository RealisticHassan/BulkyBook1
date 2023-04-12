using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly AppDbContext _db;
        private string msg = null;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> obj = _db.Categories;
            return View(obj);
        }

        // GET 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            try
            {
                if (model.Name == model.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("name", "Category name and display order can not be same.");
                }

                if (ModelState.IsValid)
                {

                    _db.Categories.Add(model);
                    _db.SaveChanges();
                    msg = "Data has been saved successfully.";
                    TempData["Success"] = msg;
                    return RedirectToAction("Index");

                }
            }
            catch (Exception)
            {

                throw;
            }

            return View(model);
        }



        // GET 
        public IActionResult Edit(int? Id)
        {
            try
            {
                if (Id == null || Id == 0)
                {
                    return NotFound();
                }
                var categoryFromDb = _db.Categories.Find(Id);

                ////// ALTERNATIVES///////////
                // var catFirst = _db.Categories.FirstOrDefault(x => x.Id == Id);
                // var catSingle = _db.Categories.SingleOrDefault(x => x.Id == Id);

                if (categoryFromDb == null)
                {
                    return NotFound();
                }

                return View(categoryFromDb);
            }
            catch
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category model)
        {
            try
            {
                if (model.Name == model.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("name", "Category name and display order can not be same.");
                }

                if (ModelState.IsValid)
                {

                    _db.Categories.Update(model);
                    _db.SaveChanges();
                    msg = "Data has been updated successfully.";
                    TempData["Success"] = msg;
                    return RedirectToAction("Index");

                }
            }
            catch (Exception)
            {

                throw;
            }

            return View(model);
        }


        public IActionResult Delete(int? Id)
        {
            try
            {
                if (Id == null || Id == 0)
                {
                    return NotFound();
                }
                var categoryFromDb = _db.Categories.Find(Id);

                if (categoryFromDb == null)
                {
                    return NotFound();
                }

                return View(categoryFromDb);
            }
            catch
            {

                throw;
            }

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? Id)
        {
            try
            {


                var obj = _db.Categories.Find(Id);

                if (obj == null)
                {
                    return NotFound();
                }

                _db.Categories.Remove(obj);
                _db.SaveChanges();
                msg = "Data has been deleted successfully.";
                TempData["Success"] = msg;
                return RedirectToAction("Index");


            }
            catch (Exception)
            {

                throw;
            }

            
        }





    }
}
