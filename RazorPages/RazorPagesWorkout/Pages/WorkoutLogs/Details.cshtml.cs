using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Workout.Model;

namespace RazorPagesWorkout.Pages.WorkoutLogs
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public WorkoutLog WorkoutLog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutlog = await _context.WorkoutLog.FirstOrDefaultAsync(m => m.Id == id);

            if (workoutlog is not null)
            {
                WorkoutLog = workoutlog;

                return Page();
            }

            return NotFound();
        }
    }
}
