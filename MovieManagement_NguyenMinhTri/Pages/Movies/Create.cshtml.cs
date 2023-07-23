using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Globalization;

namespace MovieManagement_NguyenMinhTri.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly ServiceBase<Movie> _context;

        public CreateModel()
        {
            _context = new ServiceBase<Movie>();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.GetAll() == null || Movie == null)
            {
                return Page();
            }

            if (MovieExists(Movie.MovieId))
            {
                ModelState.AddModelError(string.Empty, "Id already exists.");
                return Page();
            }

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            Movie.MovieName = textInfo.ToTitleCase(Movie.MovieName);

            Movie.CreatedAt = DateTime.Now;
            Movie.UpdatedAt = Movie.CreatedAt;

            _context.Add(Movie);

            return RedirectToPage("./Index");
        }

        private bool MovieExists(int id)
        {
            return (_context.GetAll()?.Any(e => e.MovieId == id)).GetValueOrDefault();
        }
    }
}
