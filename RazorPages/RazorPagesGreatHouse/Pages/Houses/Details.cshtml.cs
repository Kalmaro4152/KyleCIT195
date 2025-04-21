using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GreatHouse.Model;

namespace RazorPagesGreatHouse.Pages.Houses
{
    public class DetailsModel : PageModel
    {
        private readonly Vvardenfell _context;

        public DetailsModel(Vvardenfell context)
        {
            _context = context;
        }

        public House House { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await _context.House.FirstOrDefaultAsync(m => m.Id == id);

            if (house is not null)
            {
                House = house;

                return Page();
            }

            return NotFound();
        }
    }
}
