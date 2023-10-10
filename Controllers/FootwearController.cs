using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parcial1.Data;
using parcial1.Models;

namespace parcial1.Controllers
{
    public class FootwearController : Controller
    {
        private readonly StoreShoesContext _context;

        public FootwearController(StoreShoesContext context)
        {
            _context = context;
        }

        // GET: Footwear
     public async Task<IActionResult> Index(string searchString)
{
    var footwear = from f in _context.Footwear select f;

    if (!string.IsNullOrEmpty(searchString))
    {
        footwear = footwear.Where(f => f.Model.ToUpper().Contains(searchString.ToUpper()));
    }


    

    return View(await footwear.ToListAsync());
}





        // GET: Footwear/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Footwear == null)
            {
                return NotFound();
            }

            var footwear = await _context.Footwear
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footwear == null)
            {
                return NotFound();
            }

            return View(footwear);
        }

        // GET: Footwear/Create
        public IActionResult Create()
        {   
            
            //LISTA DE TIPOS DE CALZADO
            var tipos = new List<string> { "Urbano", "Botin", "Running" };
            ViewBag.Tipos = new SelectList(tipos);

            //LISTA DE TALLES DISPONIBLES
            var talles = new List<int> { 35,36,37,38, 39, 40, 41, 42, 43, 44 };
            ViewBag.Talles = new SelectList(talles);

            return View();     

        }

        // POST: Footwear/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Brand,Model,Gender,Size,Price,PayInInstallments,ImageUrl")] Footwear footwear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(footwear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(footwear);
        }

        // GET: Footwear/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Footwear == null)
            {
                return NotFound();
            }

            var footwear = await _context.Footwear.FindAsync(id);
            if (footwear == null)
            {
                return NotFound();
            }
            return View(footwear);
        }

        // POST: Footwear/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Brand,Model,Gender,Size,Price,PayInInstallments,ImageUrl")] Footwear footwear)
        {
            if (id != footwear.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footwear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootwearExists(footwear.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(footwear);
        }

        // GET: Footwear/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Footwear == null)
            {
                return NotFound();
            }

            var footwear = await _context.Footwear
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footwear == null)
            {
                return NotFound();
            }

            return View(footwear);
        }

        // POST: Footwear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Footwear == null)
            {
                return Problem("Entity set 'StoreShoesContext.Footwear'  is null.");
            }
            var footwear = await _context.Footwear.FindAsync(id);
            if (footwear != null)
            {
                _context.Footwear.Remove(footwear);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootwearExists(int id)
        {
          return (_context.Footwear?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
