using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Doctor;
using GestorPacientes.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GestorPacientes.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(IDoctorService doctorService, ILogger<DoctorController> logger)
        {
            _doctorService = doctorService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var medicalProfessionals = await _doctorService.GetAllViewModel();
            return View(medicalProfessionals);
        }

        public IActionResult Create()
        {
            var viewModel = new SaveDoctorViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveDoctorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Validate that all fields must have a value
                if (string.IsNullOrWhiteSpace(viewModel.FirstName) || string.IsNullOrWhiteSpace(viewModel.LastName) ||
                    string.IsNullOrWhiteSpace(viewModel.Email) || string.IsNullOrWhiteSpace(viewModel.Phone) ||
                    string.IsNullOrWhiteSpace(viewModel.LicenseNumber))
                {
                    ModelState.AddModelError(string.Empty, "Todos los campos deben estar completos.");
                }
                else
                {
                    await _doctorService.Add(viewModel);
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

            var medicalProfessional = await _doctorService.GetByIdSaveViewModel(id.Value);
            if (medicalProfessional == null)
            {
                return NotFound();
            }

            return View(medicalProfessional);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SaveDoctorViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Validate that all fields must have a value
                if (string.IsNullOrWhiteSpace(viewModel.FirstName) || string.IsNullOrWhiteSpace(viewModel.LastName) ||
                    string.IsNullOrWhiteSpace(viewModel.Email) || string.IsNullOrWhiteSpace(viewModel.Phone) ||
                    string.IsNullOrWhiteSpace(viewModel.LicenseNumber))
                {
                    ModelState.AddModelError(string.Empty, "Todos los campos deben estar completos.");
                }
                else
                {
                    await _doctorService.Update(viewModel);
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

            var medicalProfessional = await _doctorService.GetByIdSaveViewModel(id.Value);
            if (medicalProfessional == null)
            {
                return NotFound();
            }

            return View(medicalProfessional);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _doctorService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
