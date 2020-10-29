using BookCatalog.DbConnection;
using BookCatalog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Service
{
    public class BookService
    {
        private readonly BookContext _bookContext;

        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task AddAsync(Book book)
        {
            await _bookContext.Books.AddAsync(book);
            await _bookContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Book>> GetAsync() => await _bookContext.Books.ToListAsync();
        public async Task<Book> GetByIdAsync(int id) => await _bookContext.Books.FindAsync(id);
       
        public async Task DeleteAsync(int id)
        {
            _bookContext.Books.Remove(await _bookContext.Books.FindAsync(id));
            await _bookContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, Book newBook)
        {
            var book = await _bookContext.Books.FindAsync(id);

            book.Title = newBook.Title;
            book.Author = newBook.Author;
            book.PublishingHouse = newBook.PublishingHouse;
            book.Year = newBook.Year;
            book.CategoryId = newBook.CategoryId;

            _bookContext.Entry(book).State = EntityState.Modified;

            await _bookContext.SaveChangesAsync();
        }
    }
}
