using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Globalization;

namespace MovieManagement_NguyenMinhTri.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly ServiceBase<Movie> _context;

        public EditModel()
        {
            _context = new ServiceBase<Movie>();
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
            Movie = movie;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                Movie.MovieName = textInfo.ToTitleCase(Movie.MovieName);
                Movie.UpdatedAt = DateTime.Now;

                _context.Update(Movie);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.MovieId))
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

        private bool MovieExists(int id)
        {
            return (_context.GetAll()?.Any(e => e.MovieId == id)).GetValueOrDefault();
        }
    }
}
