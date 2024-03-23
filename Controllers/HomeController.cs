using Microsoft.AspNetCore.Mvc;
using mission11_day.Models;
using mission11_day.Models.ViewModels;
using System.Diagnostics;

namespace mission11_day.Controllers 
{
    public class HomeController : Controller
    {
        private IBookstoreRepository _bookRepo;  
        public HomeController(IBookstoreRepository temp)
        {
            _bookRepo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var bookData = new BooksListViewModel
            {
                Books = _bookRepo.Books
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _bookRepo.Books.Count(),
                }
            };
            return View(bookData);
        }
    }
}
