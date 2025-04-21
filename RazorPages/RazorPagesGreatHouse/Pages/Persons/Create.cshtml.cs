using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GreatHouse.Model;

namespace RazorPagesGreatHouse.Pages.Persons
{
    public class CreateModel : PageModel
    {
        private readonly Vvardenfell _context;

        public CreateModel(Vvardenfell context)
        {
            _context = context;
        }
        public List <string> RaceList {get;set;} = new List<string>();

        public IActionResult OnGet()
        {
            RaceList= Enum.GetNames(typeof(GreatHouse.Model.Race)).ToList();
        ViewData["HouseId"] = new SelectList(_context.House, "Id", "Clan");
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Person.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
