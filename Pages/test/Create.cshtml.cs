using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using testAPI.Data;
using testAPI.models;

namespace testAPI
{
    public class CreateModel : PageModel
    {
        private readonly testAPI.Data.testAPIContext _context;

        public CreateModel(testAPI.Data.testAPIContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public test test { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.test.Add(test);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}