using Microsoft.EntityFrameworkCore;
using pr2.Models;
using System.Collections.Generic;

namespace pr2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactForm> ContactForms { get; set; }
    }
}
