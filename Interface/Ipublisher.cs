using librarySampleMVC.Models.Entity;

namespace librarySampleMVC.Interface
{
    public interface Ipublisher
    {
        public List<Publisher> PublisherListItem();

        Publisher find(int id);
    }
}
