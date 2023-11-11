using Microsoft.AspNetCore.Mvc;
using UkraineSvoNews.Models;
using UkraineSvoNews.ViewModel;

namespace UkraineSvoNews.Controllers
{
    public class PublicationController : Controller
    {
        private readonly MainContext _context;

        public PublicationController(MainContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var publications = _context.Publications.ToList();
            return View(publications);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatePublicationViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var publication = new Publication
            {
                UserId = 1,
                Description = viewModel.Description,
                Title = viewModel.Title,
            };
            _context.Publications.Add(publication);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
