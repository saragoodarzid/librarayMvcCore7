using librarySampleMVC.Data;
using librarySampleMVC.Interface;
using librarySampleMVC.Models.Dto;
using librarySampleMVC.Models.Entity;
using librarySampleMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;

namespace librarySampleMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly Ibook ibook;
        private readonly Igroup igroup;
        private readonly Ipublisher ipublisher;

        public BookController(Ibook ibook, Igroup igroup, Ipublisher ipublisher)
        {
            this.ibook = ibook;
            this.igroup = igroup;
            this.ipublisher = ipublisher;
        }

        public IActionResult Index()
        {
            dynamic bookModel = new ExpandoObject();
            bookModel.bookList = ibook.book4Last().Result;
            bookModel.bookGroupList = ibook.book4Last().Result;
            return View(bookModel);
        }


        public IActionResult newBookView(BookDto bookDto)
        {
            return View();
        }

        public IActionResult Create(BookDto bookDto)
        {
            var publisherLst = new SelectList(this.ipublisher.PublisherListItem(), "ID", "Name");
            var groupLst = new SelectList(this.igroup.GroupListItem(), "ID", "Name");
            bookDto.groupLst = groupLst;
            bookDto.publisherLst = publisherLst;
            return View(bookDto);
        }

        [HttpPost]
        public IActionResult SaveBook(BookDto bookDto)
        {
            Book book = new Book()
            {
                Author = bookDto.Author,
                Name = bookDto.Name,
                Price = bookDto.Price,
                PublisherDate = bookDto.PublisherDate,
                Shabak = bookDto.Shabak,
                Group = this.igroup.find((Convert.ToInt32(bookDto.groupId))),
                publisher = this.ipublisher.find((Convert.ToInt32(bookDto.publisherId)))
            };
            ibook.save(book);
            return RedirectToAction(nameof(Index));
        }

        //[HttpGet("/Book/bookSearch/{bookName}")]
        public IActionResult bookSearch(String bookName)
        {
            return View(ibook.bookSearch(bookName));

        }
    }
}
