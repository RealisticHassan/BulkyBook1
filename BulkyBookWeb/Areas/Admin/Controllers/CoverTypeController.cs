using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {

        private readonly IUnitOfWork _IUnitOfWork;
        private string msg = null;

        public CoverTypeController(IUnitOfWork IUnitOfWork)
        {
            _IUnitOfWork = IUnitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> obj = _IUnitOfWork.CoverType.GetAll();
            return View(obj);
        }

        // GET  
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType model)
        {
            try
            {
               

                if (ModelState.IsValid)
                {

                    _IUnitOfWork.CoverType.Add(model);
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
                // var CoverTypeFromDb = _db.Categories.Find(Id);

                ////// ALTERNATIVES///////////
                var catFirst = _IUnitOfWork.CoverType.GetFirstOrDefault(x => x.Id == Id);
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
        public IActionResult Edit(CoverType model)
        {
            try
            {
                
                if (ModelState.IsValid)
                {

                    _IUnitOfWork.CoverType.update(model);
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
                var CoverTypeFromDb = _IUnitOfWork.CoverType.GetFirstOrDefault(u => u.Id == Id);

                if (CoverTypeFromDb == null)
                {
                    return NotFound();
                }

                return View(CoverTypeFromDb);
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


                var obj = _IUnitOfWork.CoverType.GetFirstOrDefault(u => u.Id == Id);

                if (obj == null)
                {
                    return NotFound();
                }

                _IUnitOfWork.CoverType.Remove(obj);
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
