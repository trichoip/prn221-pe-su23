using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManagement_NguyenMinhTri.Paging;
using Repository;

namespace MovieManagement_NguyenMinhTri.Pages.Movies
{
    public class IndexModel : PageModel
    {

        private readonly ServiceBase<Movie> _context;

        public PaginatedList<Movie> Movie { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchField { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? pageIndex { get; set; }

        public IndexModel()
        {
            _context = new ServiceBase<Movie>();
        }

        public async Task<IActionResult> OnGetAsync()
        {

            IQueryable<Movie> CorrespondingAuthorIQ = _context.GetAll().OrderByDescending(c => c.CreatedAt);

            ViewData["SearchField"] = new SelectList(new List<string> { "MovieName", "Duration" });

            if (!String.IsNullOrEmpty(SearchString) && !String.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "Duration":
                        try
                        {
                            int duration = Convert.ToInt32(SearchString);

                            CorrespondingAuthorIQ = CorrespondingAuthorIQ.Where(s => s.Duration == duration);
                        }
                        catch (Exception e)
                        {
                            ModelState.AddModelError(string.Empty, "Duration must be a number");

                        }

                        break;
                    case "MovieName":
                        CorrespondingAuthorIQ = CorrespondingAuthorIQ.Where(s => s.MovieName.Contains(SearchString));
                        break;
                }
            }

            var pageSize = 3;
            Movie = await PaginatedList<Movie>.CreateAsync(CorrespondingAuthorIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            return Page();
        }
    }
}
