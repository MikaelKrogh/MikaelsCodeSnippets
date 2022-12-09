using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using obl.opg.asp.Models;
using System.Threading.Tasks;

namespace obl.opg.asp.Pages.BookList
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost() //virker fordi html 'form=post'
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
