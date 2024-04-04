using Microsoft.AspNetCore.Mvc;
using pet_project.Data.Services;
using pet_project.Models;

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
            var allActors = await _service.GetAllAsync();
            return View(allActors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

		public async Task<IActionResult> Edit(int id)
		{
			var actor = await _service.GetByIdAsync(id);
            return View(actor);
		}

		[HttpPatch]
        public async Task<IActionResult> Edit(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                // Если модель не прошла валидацию, возвращаем представление с ошибками валидации
                return RedirectToAction(nameof(Create));
            }
            await _service.UpdateAsync(actor);
            return RedirectToAction(nameof(Index));
        }
    }
}
