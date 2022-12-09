using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using obl.opg.asp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace obl.opg.asp.Controllers
{

    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var bookFromDb = await _db.Book.FirstOrDefaultAsync(x => x.Id == id);
            if (bookFromDb != null)
            {
                _db.Book.Remove(bookFromDb);
                await _db.SaveChangesAsync();
                return Json(new { success = true, message = "Delete successfull" });

            }
            else
            {
                return Json(new { success = false, message= "Error while deleting" });
            }
        }
    }
}
