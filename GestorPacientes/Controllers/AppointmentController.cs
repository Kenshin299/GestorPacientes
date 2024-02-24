using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Appointmens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GestorPacientes.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(IAppointmentService appointmentService, ILogger<AppointmentController> logger)
        {
            _appointmentService = appointmentService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _appointmentService.GetAllViewModel();
            return View(users);
        }

        public IActionResult Create()
        {
            var viewModel = new SaveAppointmentViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveAppointmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                /*if (await _appointmentService.UsernameExists(viewModel.UserName))
                {
                    ModelState.AddModelError(nameof(viewModel.UserName), "El usuario ya existe.");
                }
                else
                {*/
                    await _appointmentService.Add(viewModel);
                    return RedirectToAction("Index");
                //}
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _appointmentService.GetByIdSaveViewModel(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SaveAppointmentViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                /*if (await _userService.UsernameExists(viewModel.UserName))
                {
                    ModelState.AddModelError(nameof(viewModel.UserName), "El usuario ya existe.");
                }
                else
                {*/
                    await _appointmentService.Update(viewModel);
                    return RedirectToAction("Index");
                //}
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _appointmentService.GetByIdSaveViewModel(id.Value);
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
            await _appointmentService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
