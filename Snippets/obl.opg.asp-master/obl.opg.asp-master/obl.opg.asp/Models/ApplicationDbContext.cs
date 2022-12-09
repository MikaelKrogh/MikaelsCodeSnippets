using System;
using Microsoft.EntityFrameworkCore;
using obl.opg.asp.Models;

namespace obl.opg.asp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Book {get;set;}


    }
}
