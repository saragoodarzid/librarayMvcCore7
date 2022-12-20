using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace librarySampleMVC.Models.Entity
{
    public class Book
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Shabak { get; set; }
        public string Author { get; set; }
        public DateTime PublisherDate { get; set; }
        public long Price { get; set; }

        [ForeignKey("Publisher")]
        public int publisherId { get; set; } 
        public Publisher publisher { get; set; }

        [NotMapped]
        public Group Group { get; set; }

    }
}
