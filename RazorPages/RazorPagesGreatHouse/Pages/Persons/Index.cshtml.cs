using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GreatHouse.Model;

namespace RazorPagesGreatHouse.Pages.Persons
{
    public class IndexModel : PageModel
    {
        private readonly Vvardenfell _context;

        public IndexModel(Vvardenfell context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Person = await _context.Person
                .Include(p => p.House).ToListAsync();
        }
    }
}
