﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Data;
using ProjetFinal.Models;

namespace ProjetFinal.Controllers
{
    public class FoodsController : Controller
    {
        private readonly FoodDBContext _context;

        public FoodsController(FoodDBContext context)
        {
            _context = context;
        }

        // GET: Foods
        public async Task<IActionResult> Index()
        {
            var FoodDBContext = _context.Food.Include(m => m.Chef);
            return View(await FoodDBContext.ToListAsync());
        }



        public async Task<IActionResult> FoodsAndTheirChefs()
        {
            var FoodDBContext = _context.Food.Include(m => m.Chef);
            return View(await FoodDBContext.ToListAsync());
        }


      // action search by titre
        public IActionResult SearchByTitle(string s)
        {

            return View(_context.Food.Where(m => m.Nom.Contains(s)).ToList());
        }


        // GET: Foods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Food == null)
            {
                return NotFound();
            }

            var food = await _context.Food
                .FirstOrDefaultAsync(m => m.Id == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // GET: Foods/Create
        public IActionResult Create()
        {
            ViewData["ChefId"] = new SelectList(_context.Chef, "Id", "Id");

            return View();
        }

        // POST: Foods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,,ImageUrl,Nom,Specialite,Ingredient,Prix,ChefId")] Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Add(food);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChefId"] = new SelectList(_context.Chef, "Id", "Id", food.ChefId);

            return View(food);
        }

        // GET: Foods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Food == null)
            {
                return NotFound();
            }

            var food = await _context.Food.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            ViewData["ChefId"] = new SelectList(_context.Chef, "Id", "Id", food.ChefId);
            return View(food);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageUrl,Nom,Specialite,Ingredient,Prix,ChefId")] Food food)
        {
            if (id != food.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(food);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodExists(food.Id))
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
            return View(food);
        }

        // GET: Foods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Food == null)
            {
                return NotFound();
            }

            var food = await _context.Food
                .FirstOrDefaultAsync(m => m.Id == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Food == null)
            {
                return Problem("Entity set 'FoodDBContext.Food'  is null.");
            }
            var food = await _context.Food.FindAsync(id);
            if (food != null)
            {
                _context.Food.Remove(food);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodExists(int id)
        {
          return (_context.Food?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
