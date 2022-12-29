using librarySampleMVC.Data;

namespace librarySampleMVC.Services
{
    public class genericService<T>
    {

        private readonly LibraryContext _libraryContext;
        public genericService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public void Add<T>(T Model) where T : class 
        {
            _libraryContext.Set<T>().Add(Model);

            _libraryContext.SaveChanges();
        }
    }
}
