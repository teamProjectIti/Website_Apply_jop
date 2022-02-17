using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: HomeController1
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var data = _context.categorys.ToList();
            return View(data);
        }
        // GET: HomeController1/Details/5
        public async Task<ActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.categorys
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }
        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(category cat)
        {
            
                if (ModelState.IsValid)
                {
                    _context.Add(cat);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            
                return View();
        }

        // GET: HomeController1/Edit/5
        public async Task<ActionResult> EditAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.categorys.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int? id, category category)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                
                    if (!catExists(category.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                return RedirectToAction(nameof(Index));
                }
            }
            return View(category);
        }

        // GET: HomeController1/Delete/5
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.categorys
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: HomeController1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cat = await _context.categorys.FindAsync(id);
            _context.categorys.Remove(cat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool catExists(int id)
        {
            return _context.categorys.Any(e => e.ID == id);
        }

    }
}
