using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GestorPacientes.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllViewModel();
            return View(users);
        }

        public IActionResult Create()
        {
            var viewModel = new SaveUserViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.UsernameExists(viewModel.UserName))
                {
                    ModelState.AddModelError(nameof(viewModel.UserName), "El usuario ya existe.");
                }
                else
                {
                    await _userService.Add(viewModel);
                    return RedirectToAction("Index");
                }
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetByIdSaveViewModel(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SaveUserViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await _userService.UsernameExists(viewModel.UserName))
                {
                    ModelState.AddModelError(nameof(viewModel.UserName), "El usuario ya existe.");
                }
                else
                {
                    await _userService.Update(viewModel);
                    return RedirectToAction("Index");
                }
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetByIdSaveViewModel(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
