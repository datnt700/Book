using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryBook.Models
{
    public class Book
    {
       [Key]
       [Required]
       
       public int BookId {get; set;}
       [Required]
       public string Title {get; set;}
       public string Author {get; set;}
       public string Image {get; set;}
       
    
       public string Description {get; set;}
       [Required]
       public int CategoryId {get; set;}
       public virtual Category Category {get; set;}
       
       public virtual ICollection<BookBorrowingRequestDetail> BookBorrowingRequestDetails {get; set;}
    }
}