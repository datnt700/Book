using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryBook.Enums;

namespace LibraryBook.Models
{
    public class BookBorrowingRequest
    {
        [Key]
        public int RequestId {get; set;}
        [Required]
        public DateTime DateRequest {get; set;}
        public DateTime? ReturnRequest {get; set;}
        [Required]
        public Status Status {get; set;}
        [Required]
        public int RequestUserId {get; set;}
        public virtual User RequestUser {get; set;}
        
        public int? ApprovalUserId {get; set;}
        [NotMapped]
        public virtual User ApprovalUser {get; set;}
        
        public  int? RejectUserId {get; set;}
        [NotMapped]
        public virtual User RejectUser {get; set;}
        public virtual ICollection<BookBorrowingRequestDetail> BookBorrowRequestDetails {get; set;}

        
    }
}