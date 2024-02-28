using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_project.Data;
using pet_project.Data.Services;

namespace pet_project.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GetAll();
            return View(allActors);
        }
    }
}
