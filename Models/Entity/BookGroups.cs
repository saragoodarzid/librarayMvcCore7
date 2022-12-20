using librarySampleMVC.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace librarySampleMVC.Models
{
    public class BookGroups
    {
        public int ID { get; set; }

        [ForeignKey("Book")]
        public int bookId { get; set; }

        [ForeignKey("Group")]
        public int groupId { get; set; }
        public virtual Book Books { get; set; }

        public virtual Group Groups { get; set; }

    }
}
