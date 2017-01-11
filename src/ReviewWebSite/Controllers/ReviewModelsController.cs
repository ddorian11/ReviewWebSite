using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReviewWebSite.Data;
using ReviewWebSite.Models;

namespace ReviewWebSite.Controllers
{
    public class ReviewModelsController : Controller
    {
        private readonly ReviewContext _context;

        public ReviewModelsController(ReviewContext context)
        {
            _context = context;    
        }

        // GET: ReviewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reviews.ToListAsync());
        }

        // GET: ReviewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewModel = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            if (reviewModel == null)
            {
                return NotFound();
            }

            return View(reviewModel);
        }

        // GET: ReviewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReviewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Comment,DateTime,Email,Name,Rating")] ReviewModel reviewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reviewModel);
        }

        // GET: ReviewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewModel = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            if (reviewModel == null)
            {
                return NotFound();
            }
            return View(reviewModel);
        }

        // POST: ReviewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Comment,DateTime,Email,Name,Rating")] ReviewModel reviewModel)
        {
            if (id != reviewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewModelExists(reviewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(reviewModel);
        }

        // GET: ReviewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewModel = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            if (reviewModel == null)
            {
                return NotFound();
            }

            return View(reviewModel);
        }

        // POST: ReviewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviewModel = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            _context.Reviews.Remove(reviewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ReviewModelExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
