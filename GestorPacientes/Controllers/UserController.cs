using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

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

        // GET: /User
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllViewModel();
            return View(users);
        }

        // GET: /User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Check if the username already exists
                if (await _userService.UsernameExists(viewModel.UserName))
                {
                    ModelState.AddModelError(string.Empty, "The username already exists.");
                }
                else
                {
                    // Other validation and user creation logic here
                    await _userService.Add(viewModel);
                    return RedirectToAction("Index");
                }
            }
            return View(viewModel);
        }

        // GET: /User/Edit/1
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

        // POST: /User/Edit/1
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
                // Check if the username already exists
                if (await _userService.UsernameExists(viewModel.UserName))
                {
                    ModelState.AddModelError(string.Empty, "The username already exists.");
                }
                else
                {
                    // Other validation and user editing logic here
                    await _userService.Update(viewModel);
                    return RedirectToAction("Index");
                }
            }

            return View(viewModel);
        }

        // GET: /User/Delete/1
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

        // POST: /User/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.Delete(id);
            return RedirectToAction("Index");
        }
    }

}
