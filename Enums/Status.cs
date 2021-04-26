using System.ComponentModel.DataAnnotations;

namespace LibraryBook.Enums 
{
    public enum Status {
        [Display(Name = "Waiting")]
        Waiting,
        [Display(Name = "Approve")]
        Approve,
        [Display(Name = "Rejected")]
        Rejected
    }
}