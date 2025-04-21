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
    public class DetailsModel : PageModel
    {
        private readonly Vvardenfell _context;

        public DetailsModel(Vvardenfell context)
        {
            _context = context;
        }

        public Person Person { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var person = await _context.Person.FirstOrDefaultAsync(m => m.Id == id);
            var person = await _context.Person
                .Include(h => h.House)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (person is not null)
            {
                Person = person;

                return Page();
            }

            return NotFound();
        }
    }
}
