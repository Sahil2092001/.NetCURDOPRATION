using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newmachinetest.Models;
using X.PagedList;
using X.PagedList.Extensions;


namespace CURDOP.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _Db;
        public ProductController(ProductDbContext context)
        {
            this._Db = context;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;

            var products = await _Db.productss.ToListAsync();

            return View(products.ToPagedList(pageNumber, pageSize));
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product Obj)

        {

            if (ModelState.IsValid)
            {
                _Db.Add(Obj);
                await _Db.SaveChangesAsync();
                TempData["SuccessMessege"] = "Product Added Successfully";
                return RedirectToAction("Index");
            }
            return View(Obj);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var products = await _Db.productss.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product Obj)
        {

            if (id != Obj.ProductId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _Db.Update(Obj);
                await _Db.SaveChangesAsync();
                TempData["SuccessMessege"] = "Product Update Successfully";
                return RedirectToAction("Index");
            }
            return View(Obj);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var products = await _Db.productss.FindAsync(id);
            if (products != null)
            {
                _Db.productss.Remove(products);
                await _Db.SaveChangesAsync();
                TempData["SuccessMessege"] = "Product Deleted Successfully";

            }
            else
            {
                TempData["SuccessMessege"] = "Product Not found";
            }
            return RedirectToAction("Index");
        }
    }

}

