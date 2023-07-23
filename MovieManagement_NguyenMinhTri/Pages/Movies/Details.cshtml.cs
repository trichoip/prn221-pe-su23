using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace MovieManagement_NguyenMinhTri.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly ServiceBase<Movie> _context;

        public DetailsModel()
        {
            _context = new ServiceBase<Movie>();
        }

        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GetAll() == null)
            {
                return NotFound();
            }

            var movie = await _context.GetAll().FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
