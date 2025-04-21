using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GreatHouse.Model;

namespace RazorPagesGreatHouse.Pages.Houses
{
    public class EditModel : PageModel
    {
        private readonly Vvardenfell _context;

        public EditModel(Vvardenfell context)
        {
            _context = context;
        }

        public List<string>ClanList {get;set;} = new List<string>();

        [BindProperty]
        public House House { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ClanList = Enum.GetNames(typeof(GreatHouse.Model.Clan)).ToList();
            var house =  await _context.House.FirstOrDefaultAsync(m => m.Id == id);
            if (house == null)
            {
                return NotFound();
            }
            House = house;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(House).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseExists(House.Id))
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

        private bool HouseExists(int id)
        {
            return _context.House.Any(e => e.Id == id);
        }
    }
}
