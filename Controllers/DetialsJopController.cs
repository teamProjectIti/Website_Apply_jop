using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DetialsJopController : Controller
    {
        // GET: HomeController1
        private readonly ApplicationDbContext _context;

        public DetialsJopController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var data = _context.Details_jops.Include(x=>x.categorys).ToList();
            return View(data);
        }
        // GET: HomeController1/Details/5
        public async Task<ActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Details_jops
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
            ViewData["cat_Id"] = new SelectList(_context.categorys, "ID", "Name_Cat");
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Details_jop jop)
        {

            if (ModelState.IsValid)
            {
                _context.Add(jop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cat_Id"] = new SelectList(_context.categorys, "ID", "Name_Cat");
            return View();
        }

        // GET: HomeController1/Edit/5
        public async Task<ActionResult> EditAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Details_jops.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            ViewData["cat_Id"] = new SelectList(_context.categorys, "ID", "Name_Cat");
            return View(cat);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int? id, Details_jop jop)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(jop);
                await _context.SaveChangesAsync();

                if (!catExists(jop.ID))
                {
                    return NotFound();
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["cat_Id"] = new SelectList(_context.categorys, "ID", "Name_Cat");
            return View(jop);
        }

        // GET: HomeController1/Delete/5
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Details_jops
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
            var data = await _context.Details_jops.FindAsync(id);
            _context.Details_jops.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool catExists(int id)
        {
            return _context.Details_jops.Any(e => e.ID == id);
        }
    }
}
