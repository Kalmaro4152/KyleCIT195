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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<WorkoutLog> WorkoutLog { get;set; } = default!;

        public async Task OnGetAsync()
        {
            WorkoutLog = await _context.WorkoutLog
                .Include(w => w.Exercise)
                .Include(w => w.User).ToListAsync();
        }
    }
}
