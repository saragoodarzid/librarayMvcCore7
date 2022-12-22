using librarySampleMVC.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace librarySampleMVC.Data;
//test ast
public class LibraryContext : DbContext
{
    protected readonly IConfiguration Configuration;
   
    public LibraryContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

        //add-migration initial -context LibraryContext
        //remove - migration - context LibraryContext
        //update-database -context LibraryContext
    }


    public DbSet<Group> Group { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<BookGroups> BookGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>().HasData(new Group {ID=1, Name="رمان",Comment="-----" },
                                                new Group {ID=2, Name = "تخیلی" ,Comment="---"},
                                                new Group {ID=3, Name="علمی" ,Comment="پر فروشترین"},
                                                new Group {ID=4, Name="تخصصی" ,Comment="-"});

        modelBuilder.Entity<Publisher>().HasData(
            new Publisher {ID=1, Name = "یاقوت", Comment = "ناشر برتر سال 1400", EstablishmentDate = DateTime.Now },
            new Publisher {ID=2, Name = "قلم چی", Comment = "ناشر برتر سال 1401", EstablishmentDate = DateTime.Now },
            new Publisher {ID=3, Name = "خیلی سبز", Comment = "ناشر معمولی", EstablishmentDate = DateTime.Now },
            new Publisher {ID=4, Name = "بنفشه", Comment = "ناشر مبتدی", EstablishmentDate = DateTime.Now },
            new Publisher {ID=5, Name = "فتح", Comment = "ناشر غیرفعال", EstablishmentDate = DateTime.Now }
            );

        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                ID = 1,
                Author = "نویسنده اول",
                Name = "کتاب اول",
                Price = 100000,
                PublisherDate = DateTime.Now,
                Shabak = "123-1-125",
                publisherId =5
            },
            new Book
            {
                ID = 2,
                Author = "نویسنده دوم",
                Name = "کتاب دوم",
                Price = 100000,
                PublisherDate = DateTime.Now,
                Shabak = "123-2-125",
                publisherId = 1
            },
            new Book
            {
                ID = 3,
                Author = "نویسنده سوم",
                Name = "کتاب سوم",
                Price = 100000,
                PublisherDate = DateTime.Now,
                Shabak = "123-3-125",
                publisherId = 3
            },
            new Book
            {
                ID = 4,
                Author = "نویسنده چهارم",
                Name = "کتاب چهارم",
                Price = 100000,
                PublisherDate = DateTime.Now,
                Shabak = "123-4-125",
                publisherId = 3
            }
            );

        modelBuilder.Entity<BookGroups>().HasData(
            new BookGroups
            {
                ID = 1,
                bookId = 1,
                groupId = 1
            }
            , new BookGroups
            {
                ID = 2,
                bookId = 2,
                groupId = 1
            }, new BookGroups
            {
                ID = 3,
                bookId = 3,
                groupId = 1
            }, new BookGroups
            {
                ID = 4,
                bookId = 1,
                groupId = 2
            }, new BookGroups
            {
                ID = 5,
                bookId = 2,
                groupId = 2
            }, new BookGroups
            {
                ID = 6,
                bookId = 1,
                groupId = 3
            }, new BookGroups
            {
                ID = 7,
                bookId = 1,
                groupId = 4
            }, new BookGroups
            {
                ID = 8,
                bookId = 2,
                groupId = 4
            }
        );

    }

}
