using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Linq;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _IUnitOfWork;
        private string msg = null;

        public ProductController(IUnitOfWork IUnitOfWork)
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




        // GET 
        public IActionResult Upsert(int? Id)
        {
            try
            {
                ProductVM productVm = new ProductVM()
                {
                    product = new(),
                    CatList = _IUnitOfWork.Category.GetAll().Select(
                        i => new SelectListItem
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        }
                    ),

                    CTList = _IUnitOfWork.CoverType.GetAll().Select(
                        i => new SelectListItem
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        }
                    )
                };
                
                
                
                //IEnumerable<SelectListItem> CatList = _IUnitOfWork.Category.GetAll().Select(
                //    u => new SelectListItem
                //    {
                //        Text = u.Name,
                //        Value = u.Id.ToString()
                //    } );
                //  IEnumerable<SelectListItem> CTList = _IUnitOfWork.CoverType.GetAll().Select(
                //    u => new SelectListItem
                //    {
                //        Text = u.Name,
                //        Value = u.Id.ToString()
                //    } );


                if (Id == null || Id == 0)
                {
                     
                    //ViewBag.CatList = CatList;
                    //ViewData["CoverTypes"] = CTList;
                    //return View(product);

                    return View(productVm);


                }
                else
                {
                    // Update case
                }

                return View(productVm);
            }
            catch
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM model, IFormFile _file)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    // _IUnitOfWork.CoverType.update(model);
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
