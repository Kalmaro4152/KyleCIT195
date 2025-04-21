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
    public class IndexModel : PageModel
    {
        private readonly Vvardenfell _context;

        public IndexModel(Vvardenfell context)
        {
            _context = context;
        }

        public IList<House> House { get;set; } = default!;

        public async Task OnGetAsync()
        {
            House = await _context.House.ToListAsync();
        }
    }
}
