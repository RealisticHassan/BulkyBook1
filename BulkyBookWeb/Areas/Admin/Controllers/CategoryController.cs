
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBookWeb.DataAccess;

using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _IUnitOfWork;
        private string msg = null;

        public CategoryController(IUnitOfWork IUnitOfWork)
        {
            _IUnitOfWork = IUnitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> obj = _IUnitOfWork.Category.GetAll();
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

                    _IUnitOfWork.Category.Add(model);
                    _IUnitOfWork.Save();
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
                // var categoryFromDb = _db.Categories.Find(Id);

                ////// ALTERNATIVES///////////
                var catFirst = _IUnitOfWork.Category.GetFirstOrDefault(x => x.Id == Id);
                // var catSingle = _db.Categories.SingleOrDefault(x => x.Id == Id);

                if (catFirst == null)
                {
                    return NotFound();
                }

                return View(catFirst);
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

                    _IUnitOfWork.Category.update(model);
                    _IUnitOfWork.Save();
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
                var categoryFromDb = _IUnitOfWork.Category.GetFirstOrDefault(u => u.Id == Id);

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


                var obj = _IUnitOfWork.Category.GetFirstOrDefault(u => u.Id == Id);

                if (obj == null)
                {
                    return NotFound();
                }

                _IUnitOfWork.Category.Remove(obj);
                _IUnitOfWork.Save();
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
