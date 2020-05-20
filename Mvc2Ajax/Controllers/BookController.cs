using Microsoft.AspNetCore.Mvc;
using SharedThings;

namespace Mvc2Ajax.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var model = _bookRepository.GetAll();
            return View();
        }

    }
}