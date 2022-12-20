using librarySampleMVC.Data;
using librarySampleMVC.Interface;
using librarySampleMVC.Models.Entity;

namespace librarySampleMVC.Services
{
    public class groupService:Igroup
    {
        private readonly LibraryContext libraryContext;
        public groupService( LibraryContext libraryContext)
        {

            this.libraryContext = libraryContext;
        }
        public List<Group> GroupListItem()
        {
            return libraryContext.Group.ToList();
        }

        public Group find(int id)
        {
            return libraryContext.Group.Find(id);
        }


    }
}
