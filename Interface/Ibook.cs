using librarySampleMVC.Models.Dto;
using librarySampleMVC.Models.Entity;

namespace librarySampleMVC.Interface
{
    public interface Ibook
    {
        List<BookDto> bookSearch(String bookName);

        Task<List<Book>> book4Last();

        Task<List<Book>> book3Last();

        void save(Book book);

    }
}
