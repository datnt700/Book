using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryBook.Models;
using LibraryBook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BBRDController : ControllerBase
    {
        private IRequestDetail _brrd;
        public BBRDController(IRequestDetail brrd)
        {
            _brrd = brrd;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public ActionResult<IEnumerable<BookBorrowingRequestDetail>> Get()
        {
            return _brrd.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult<BookBorrowingRequestDetail> Get(int id)
        {
            return _brrd.GetById(id);
        }


        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public void Post(BookBorrowingRequestDetail brrd)
        {
            _brrd.Create(brrd);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void Put(int id, BookBorrowingRequestDetail brrd)
        {
            _brrd.Update(brrd);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            _brrd.Delete(id);
        }
    }
}