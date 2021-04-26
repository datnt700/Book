using System.ComponentModel.DataAnnotations;

namespace LibraryBook.Enums 
{
    public enum Role {
        [Display(Name = "Admin")]
        Admin,
        [Display(Name = "User")]
        User
    }
}