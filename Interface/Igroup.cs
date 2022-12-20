using librarySampleMVC.Models.Entity;

namespace librarySampleMVC.Interface
{
    public interface Igroup
    {
        List<Group> GroupListItem();

        Group find(int id);


    }
}
