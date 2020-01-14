using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using testAPI.Data;
using testAPI.models;

namespace testAPI
{
    public class DetailsModel : PageModel
    {
        private readonly testAPI.Data.testAPIContext _context;

        public DetailsModel(testAPI.Data.testAPIContext context)
        {
            _context = context;
        }

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
    }
}
