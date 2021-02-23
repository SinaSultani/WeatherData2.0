using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeatherData2._0;
using WeatherData2._0.Models;

namespace WeatherData2._0.Controllers
{
    public class EnviornmentsController : Controller
    {
        private readonly WeatherDbContext _context;

        public EnviornmentsController(WeatherDbContext context)
        {
            _context = context;
        }

        // GET: Enviornments
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["TempSortParm"] = sortOrder == "Temperature" ? "temp_desc" : "Temperature";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var temps = from t in _context.Enviornments
                        select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                temps = temps.Where(t => t.Temperature.ToString().Contains(searchString));
            }
                switch (sortOrder)
                {
                    case "temp_desc":
                        temps = temps.OrderByDescending(t => t.Temperature);
                        break;
                    case "Date":
                        temps = temps.OrderBy(t => t.Date);
                        break;
                    case "date_desc":
                        temps = temps.OrderByDescending(t => t.Date);
                        break;
                    default:
                        temps = temps.OrderBy(t => t.Temperature);
                        break;
                }
           return View(await temps.AsNoTracking().ToListAsync());
            
        }

            // GET: Enviornments/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enviornment = await _context.Enviornments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enviornment == null)
            {
                return NotFound();
            }

            return View(enviornment);
        }

        // GET: Enviornments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enviornments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Temperature,Humidity,InsideOrOutside")] Enviornment enviornment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enviornment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enviornment);
        }

        // GET: Enviornments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enviornment = await _context.Enviornments.FindAsync(id);
            if (enviornment == null)
            {
                return NotFound();
            }
            return View(enviornment);
        }

        // POST: Enviornments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Temperature,Humidity,InsideOrOutside")] Enviornment enviornment)
        {
            if (id != enviornment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enviornment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnviornmentExists(enviornment.Id))
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
            return View(enviornment);
        }

        // GET: Enviornments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enviornment = await _context.Enviornments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enviornment == null)
            {
                return NotFound();
            }

            return View(enviornment);
        }

        // POST: Enviornments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enviornment = await _context.Enviornments.FindAsync(id);
            _context.Enviornments.Remove(enviornment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnviornmentExists(int id)
        {
            return _context.Enviornments.Any(e => e.Id == id);
        }
    }
}
