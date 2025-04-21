using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GreatHouse.Model;

namespace RazorPagesGreatHouse.Pages.Houses
{
    public class CreateModel : PageModel
    {
        private readonly Vvardenfell _context;

        public CreateModel(Vvardenfell context)
        {
            _context = context;
        }

        public List <string> ClanList{get;set;} = new List <string>();
        public IActionResult OnGet()
        {
            ClanList = Enum.GetNames(typeof(GreatHouse.Model.Clan)).ToList();

            return Page();
        }

        [BindProperty]
        public House House { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.House.Add(House);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
