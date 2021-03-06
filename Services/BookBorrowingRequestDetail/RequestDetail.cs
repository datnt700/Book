using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryBook.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LibraryBook.Services
{
    public class RequestDetail : IRequestDetail
    {
        private BookDBContext _context;
        public RequestDetail(BookDBContext context)
        {
            _context = context;
        }
        public  bool Create(BookBorrowingRequestDetail bbrd)
        {
            try
            {
                _context.BookBorrowRequestDetails.Add(bbrd);
                _context.SaveChanges();
                return true;

            }
            catch 
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            var bbrd = _context.BookBorrowRequestDetails.FirstOrDefault(x => x.Id == id);
            try
            {
                _context.BookBorrowRequestDetails.Remove(bbrd);
                _context.SaveChanges();
                return true;


            }
            catch 
            {
                return false;
            }

        }

        public List<BookBorrowingRequestDetail> GetAll()
        {
            return _context.BookBorrowRequestDetails.ToList();
        }

        public BookBorrowingRequestDetail GetById(int id) 
        {
            return _context.BookBorrowRequestDetails.Find(id);
        }
        public bool Update(BookBorrowingRequestDetail brrd)
        {
            try
            {
                var item = _context.BookBorrowRequestDetails.FirstOrDefault(x => x.Id == brrd.Id);
                item.Id = brrd.Id;
                item.BookId = brrd.BookId;
                item.RequestId = brrd.RequestId;
                _context.SaveChanges();
                return true;
           
            }
            catch 
            {
                return false;
            }

        }
    }
}