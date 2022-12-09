using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using obl.opg.asp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace obl.opg.asp.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();            
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Book.FindAsync(id);
            if (book != null)
            {
                _db.Book.Remove(book);
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return NotFound();
        }


        public async Task<IActionResult> OnPostExportJson(Book bookId) {

            Book book = await _db.Book.FirstOrDefaultAsync(x => x.Id == bookId.Id);

            var serializedData = JsonSerializer.Serialize(book);
            byte[] bytes = Encoding.UTF8.GetBytes(serializedData);

            return File(bytes, "application/octet-stream", "booktext.json");

        }
        public async Task<IActionResult> OnPostExportYaml(Book bookId) {
            Book book = await _db.Book.FirstOrDefaultAsync(x => x.Id == bookId.Id);
            //Yaml kræver nuggets package
            var yamlSerializer = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
            var serializedData = yamlSerializer.Serialize(book);
            byte[] bytes = Encoding.UTF8.GetBytes(serializedData);

            return File(bytes, "application/octet-stream", "booktext.Yaml");
        }


    }
}
