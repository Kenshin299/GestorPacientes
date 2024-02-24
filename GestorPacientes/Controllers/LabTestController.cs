using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.Services;
using GestorPacientes.Core.Application.ViewModels.LabTest;
using GestorPacientes.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GestorPacientes.Controllers
{
    public class LabTestController : Controller
    {
        private readonly ILabTestService _labTestService;
        private readonly ILogger<LabTestController> _logger;

        public LabTestController(ILabTestService labTestService, ILogger<LabTestController> logger)
        {
            _labTestService = labTestService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _labTestService.GetAllViewModel();
            return View(users);
        }

        public IActionResult Create()
        {
            var viewModel = new SaveLabTestViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveLabTestViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
               /* if (await _labTestService.(viewModel.UserName))
                {
                    ModelState.AddModelError(nameof(viewModel.UserName), "El usuario ya existe.");
                }
                else
                {*/
                    await _labTestService.Add(viewModel);
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

            var labTest = await _labTestService.GetByIdSaveViewModel(id.Value);
            if (labTest == null)
            {
                return NotFound();
            }

            return View(labTest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SaveLabTestViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               /* if (await _labTestService.UsernameExists(viewModel.UserName))
                {
                    ModelState.AddModelError(nameof(viewModel.UserName), "El usuario ya existe.");
                }*/
               /* else
                {*/
                    await _labTestService.Update(viewModel);
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

            var labTest = await _labTestService.GetByIdSaveViewModel(id.Value);
            if (labTest == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _labTestService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
