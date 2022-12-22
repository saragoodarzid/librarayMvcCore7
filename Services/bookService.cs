using librarySampleMVC.Data;
using librarySampleMVC.Interface;
using librarySampleMVC.Models;
using librarySampleMVC.Models.Dto;
using librarySampleMVC.Models.Entity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace librarySampleMVC.Services
{

    public class bookService :Ibook
    {
        private readonly ILogger<bookService> logger;
        private readonly LibraryContext libraryContext;

        public bookService(ILogger<bookService> logger,LibraryContext libraryContext)
        {
            this.logger = logger;
            this.libraryContext = libraryContext;
        }

        public List<BookDto> bookSearch(String bookname)
        {
             List<BookDto> booksLst = libraryContext.Book.Where(x => x.Name.Contains(bookname))
                                    .Select(c => new BookDto
                                    {
                                        Name = c.Name,
                                        Author = c.Author,
                                        Price = c.Price,
                                        PublisherDate = c.PublisherDate,
                                        Shabak = c.Shabak
                                    }).ToList();
             return booksLst;
        }

        public async Task<List<Book>> book4Last()
        {
            List<Book> booksLst = libraryContext.Book.ToList().OrderByDescending(x=>x.PublisherDate).TakeLast(4).ToList();
            return booksLst;
        }

        public async Task<List<BookDto>> book3Last()
        {
            List<BookDto> lstbook = new List<BookDto>();
            var lstbooks = (from b in libraryContext.Book
                           join bg in libraryContext.BookGroups
                          on b.ID equals bg.bookId into subs
                          from sub in subs.DefaultIfEmpty()
                          group sub by new { b.ID,b.Name } into gr
                          select new
                          {
                              gr.Key.ID,
                              gr.Key.Name,
                              total = gr.Count(x => x != null)
                          }).ToList();
            if(lstbooks.Count>0)
            {
                lstbooks = lstbooks.OrderByDescending(x => x.total).ToList();
                lstbook = lstbooks.Take(3).Select(d=>new BookDto
                {
                    Name = d.Name,
                    count = d.total,
                }).ToList();

            }
            return lstbook;
        }

        public void save(Book book)
        {
            libraryContext.Book.Add(book);

            BookGroups bookGroups = new BookGroups
            {
                Book = book,
                Group = book.Group
            };
            libraryContext.BookGroups.Add(bookGroups);
            libraryContext.SaveChanges();
        }
    }
}
