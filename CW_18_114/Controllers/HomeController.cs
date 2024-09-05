using CW_18_114.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Diagnostics;

namespace CW_18_114.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index(string massage)
        {
            var books = _bookService.GetAll();
            var res = new List<BookViewModel>();
            foreach (var book in books) {
                res.Add(new BookViewModel { Id = book.Id,Name = book.Name,Genre = book.Genre });
            }
            if (massage != null) {
                ViewData["massage"] = massage;
            }
            return View(res);
        }

        public IActionResult Edit(ValidateToEditBookModel model)
        {
            var res = _bookService.GetById(model.Id,model.UserName,model.Password);
            if (res == null) {
                return RedirectToAction("index","no permission");
            }
            return View(res);
        }

        [HttpPost]
        public IActionResult EditPost(BookViewModel model,string username,string password)
        {
            var isSuccess = _bookService.Edit(new Domain.Enities.Book { Name = model.Name,Id = model.Id,Genre = model.Genre },username,password);
            string massage = "success";
            if (!isSuccess) massage = "no permision";
            return RedirectToAction("Index",massage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
