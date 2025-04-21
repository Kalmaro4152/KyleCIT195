using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GreatHouse.Model;

namespace RazorPagesGreatHouse.Pages.Persons
{
    public class EditModel : PageModel
    {
        private readonly Vvardenfell _context;

        public EditModel(Vvardenfell context)
        {
            _context = context;
        }

        [BindProperty]
        public Person Person { get; set; } = default!;

        public List <string>RaceList{get;set;}=new List<string>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person =  await _context.Person.FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            Person = person;
           ViewData["HouseId"] = new SelectList(_context.House, "Id", "Clan");
           RaceList=Enum.GetNames(typeof(GreatHouse.Model.Race)).ToList();
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

            _context.Attach(Person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(Person.Id))
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

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}
