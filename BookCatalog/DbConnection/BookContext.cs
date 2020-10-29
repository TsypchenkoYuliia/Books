using BookCatalog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.DbConnection
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category[]
               {
                  new Category() {
                    Id=1,
                    Title ="Detectives and Thrillers"
                  },

                  new Category() {
                    Id=2,
                    Title ="Dramaturgy"
                  },

                  new Category() {
                    Id=3,
                    Title ="Novels"
                  },

                  new Category() {
                    Id=4,
                    Title ="Computers and the Internet"
                  },

                  new Category() {
                    Id=5,
                    Title ="Poetry"
                  },
               }); 
        }


        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Genres { get; set; }
    }
}
