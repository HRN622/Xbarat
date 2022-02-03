using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Persons;
using Application.Interface.Contexts;
using System.Threading;

namespace Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DbSet<Person> Persons { get; set; }
        public DataBaseContext(DbContextOptions options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
