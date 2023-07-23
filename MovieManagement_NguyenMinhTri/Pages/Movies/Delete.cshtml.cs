using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace MovieManagement_NguyenMinhTri.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly ServiceBase<Movie> _context;
        private readonly ServiceBase<Ticket> _contextTicket;

        public DeleteModel()
        {
            _context = new ServiceBase<Movie>();
            _contextTicket = new ServiceBase<Ticket>();
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.GetAll() == null)
            {
                return NotFound();
            }
            var movie = await _context.GetAll().FirstOrDefaultAsync(m => m.MovieId == id);

            if (movie != null)
            {
                Movie = movie;

                var tickets = _contextTicket.GetAll().Where(t => t.MovieId == Movie.MovieId);
                _contextTicket.RemoveAll(tickets);
                _context.Remove(Movie);

            }

            return RedirectToPage("./Index");
        }
    }
}
