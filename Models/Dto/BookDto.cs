using librarySampleMVC.Models.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.ProjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace librarySampleMVC.Models.Dto
{
    [NotMapped]
    public class BookDto
    {
        public int ID { get; set; }

        [Display(Name = "نام کتاب")]
        [Required(ErrorMessage = "نام کتاب باید وارد شود")]
        public string Name { get; set; }

        [Display(Name = "شابک")]
        [Required(ErrorMessage = "شابک باید وارد شود")]
        [RegularExpression(@"(\d{3})-(\d{1})-(\d{3})", ErrorMessage = "فرمت اشتباه میباشد")]
        public string Shabak { get; set; }

        [Display(Name = "نویسنده")]
        [Required(ErrorMessage = "نویسنده باید وارد شود")]
        public string Author { get; set; }

        [Display(Name = "تاریخ انتشار")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [DataType(DataType.Date)]
        public DateTime PublisherDate { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "قیمت باید وارد شود")]
        public long Price { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage ="دسته بندی باید وارد شود")]
        public string groupId { get; set; }

        [Display(Name = "ناشر")]
        [Required(ErrorMessage = "ناشر باید وارد شود")]
        public string publisherId { get; set; }

        [NotMapped]
        public SelectList groupLst { get; set; }

        [NotMapped]
        public SelectList publisherLst { get; set; }

    }
}
