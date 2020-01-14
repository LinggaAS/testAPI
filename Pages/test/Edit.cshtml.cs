using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testAPI.Data;
using testAPI.models;

namespace testAPI
{
    public class EditModel : PageModel
    {
        private readonly testAPI.Data.testAPIContext _context;

        public EditModel(testAPI.Data.testAPIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public test test { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            test = await _context.test.FirstOrDefaultAsync(m => m.Id == id);

            if (test == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(test).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testExists(test.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool testExists(int id)
        {
            return _context.test.Any(e => e.Id == id);
        }
    }
}
