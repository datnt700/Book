using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryBook.Enums;
using Microsoft.EntityFrameworkCore;

namespace LibraryBook.Models
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options) { }
        public BookDBContext() { }



        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Author> Authors { get; set; }
        public DbSet<BookBorrowingRequest> BookBorrowingRequests { get; set; }
        public DbSet<BookBorrowingRequestDetail> BookBorrowRequestDetails { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer("Server = DESKTOP-K2FS75Q\\SQLEXPRESS;Database = Library;Trusted_Connection=True;MultipleActiveResultSets= true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
            .Property(f => f.BookId)
            .ValueGeneratedOnAdd();
            builder.Entity<Category>()
            .Property(f => f.CategoryId)
            .ValueGeneratedOnAdd();
            builder.Entity<User>()
            .Property(f => f.UserId)
            .ValueGeneratedOnAdd();

            builder.Entity<BookBorrowingRequest>()
           .Property(f => f.RequestId)
           .ValueGeneratedOnAdd();
            builder.Entity<BookBorrowingRequestDetail>()
          .Property(f => f.Id)
          .ValueGeneratedOnAdd();
            base.OnModelCreating(builder);

            builder.Entity<BookBorrowingRequest>()
            .Property(b => b.Status)
            .HasDefaultValue((Status)0);

            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = 2,
                CategoryName = "Math"

            });
            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = 1,
                CategoryName = "Sciene"

            });
            builder.Entity<Book>().HasData(new Book
            {
                BookId = 1,
                Title = "ABC",
                Description = "Abc",
                CategoryId = 1
            });
            
            builder.Entity<User>().HasData(new User
            {
                UserId = 1,
                Username = "admin",
                Password = "123",
                DoB = DateTime.Now.AddYears(-20),
                Name = "Nguyen Van A",
                Role = (Role)0
            });
            builder.Entity<User>().HasData(new User
            {
                UserId = 2,
                Username = "user",
                Password = "123",
                DoB = DateTime.Now.AddYears(-30),
                Name = "Nguyen Van B",
                Role = (Role)1
            });

        }

    }
}