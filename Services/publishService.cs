using librarySampleMVC.Data;
using librarySampleMVC.Interface;
using librarySampleMVC.Models.Entity;

namespace librarySampleMVC.Services
{
    public class publishService : Ipublisher
    {
        private readonly LibraryContext libraryContext;
        public publishService(LibraryContext libraryContext)
        {

            this.libraryContext = libraryContext;
        }
        public List<Publisher> PublisherListItem()
        {
            return libraryContext.Publishers.ToList();
        }


        public Publisher find(int id)
        {
            return libraryContext.Publishers.Find(id);
        }
    }
}
