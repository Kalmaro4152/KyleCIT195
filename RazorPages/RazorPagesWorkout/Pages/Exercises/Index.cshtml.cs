using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Workout.Model;

namespace RazorPagesWorkout.Pages.Exercises
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Exercise> Exercise { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Exercise = await _context.Exercise.ToListAsync();
        }
    }
}
