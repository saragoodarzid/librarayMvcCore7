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
             List<BookDto> booksLst = libraryContext.Books.Where(x => x.Name.Contains(bookname))
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
            List<Book> booksLst = libraryContext.Books.ToList().OrderByDescending(x=>x.PublisherDate).TakeLast(4).ToList();
            return booksLst;
        }

        public async Task<List<Book>> book3Last()
        {
            var bookGroupMax = libraryContext.BookGroups.GroupBy(x => x.Books.ID).Select(s => new
            {
                count = s.Count(),
                ID = s.Key
            }).ToList().OrderByDescending(x => x.count).TakeLast(3).ToList();
            
            //var bookSelected = libraryContext.Books

            List<Book> lstbook = libraryContext.Books.Where(x=> bookGroupMax.Any(y=>y.ID==x.ID)).ToList() ;
            return lstbook;
        }

        public void save(Book book)
        {
            libraryContext.Books.Add(book);

            BookGroups bookGroups = new BookGroups
            {
                Books = book,
                Groups = book.Group
            };
            libraryContext.BookGroups.Add(bookGroups);
            libraryContext.SaveChanges();
        }
    }
}
