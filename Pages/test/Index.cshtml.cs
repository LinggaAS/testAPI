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
    public class IndexModel : PageModel
    {
        private readonly testAPI.Data.testAPIContext _context;

        public IndexModel(testAPI.Data.testAPIContext context)
        {
            _context = context;
        }

        public IList<test> test { get;set; }

        public async Task OnGetAsync()
        {
            test = await _context.test.ToListAsync();
        }
    }
}
