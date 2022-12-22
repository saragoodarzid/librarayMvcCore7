using librarySampleMVC.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace librarySampleMVC.Models.Entity
{
    public class BookGroups
    {
        public int ID { get; set; }
         
        public int bookId { get; set; }
         
        public int groupId { get; set; }
        public virtual Book Book { get; set; }

        public virtual Group Group { get; set; }

    }
}
