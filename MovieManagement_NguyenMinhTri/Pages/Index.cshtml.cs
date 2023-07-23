using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieManagement_NguyenMinhTri.ViewModel;
using Repository;

namespace MovieManagement_NguyenMinhTri.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public LoginVM LoginVM { get; set; }

        private readonly ServiceBase<Account> _serviceBase;

        public IndexModel()
        {
            _serviceBase = new ServiceBase<Account>();
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customer = _serviceBase.GetAll().FirstOrDefault(c => c.AccountId == LoginVM.Username && c.Password == LoginVM.Password && c.AccoutRole == 1);
            if (customer == null)
            {
                ModelState.AddModelError("LoginVM.Password", "You do not have permission to do this function!");
                return Page();
            }

            return RedirectToPage("/Movies/Index");
        }
    }
}