using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagamentSystem.Web.Models.LeaveTypes;
using LeaveManagamentSystem.Web.Services;


namespace LeaveManagamentSystem.Web.Controllers {
    [Authorize(Roles = Roles.Administrator)]
    public class LeaveTypesController(ILeaveTypesService _leaveTypesService) : Controller
    {
        private static string _nameExistValidationMessage = "Name is already exists in database";

        public async Task<IActionResult> Index()
        {
            var data = await _leaveTypesService.GetAllLeaveTypesAsync();
            return View(data);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var leaveType = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreate)
        {
            if (leaveTypeCreate.Name.Contains("vacation")) {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), "Name denided");
            }

            if (await _leaveTypesService.CheckIfLeafTypeNameExistAsync(leaveTypeCreate.Name)) {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), _nameExistValidationMessage);
            } 

            if (ModelState.IsValid)
            {
                await _leaveTypesService.Create(leaveTypeCreate); 
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreate);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypesService.Get<LeaveTypeEditVM>(id.Value);
            if (leaveType == null) {
                return NotFound();
            }
            return View(leaveType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
        {
            if (id != leaveTypeEdit.Id)
            {
                return NotFound();
            }

            if (await _leaveTypesService.CheckIfLeafTypeNameExistForEditAsync(leaveTypeEdit)) {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name), _nameExistValidationMessage);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _leaveTypesService.Edit(leaveTypeEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_leaveTypesService.LeaveTypeExists(leaveTypeEdit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeEdit);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypesService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
