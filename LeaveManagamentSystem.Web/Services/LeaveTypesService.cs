using AutoMapper;
using LeaveManagamentSystem.Web.Data;
using LeaveManagamentSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagamentSystem.Web.Services;
public class LeaveTypesService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypesService {

    public async Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypesAsync() {
        var data = await _context.LeaveTypes.ToListAsync();
        var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
        return viewData;
    }

    public async Task<T?> Get<T>(int id) where T : class {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null) {
            return null;
        }
        var viewData = _mapper.Map<T>(data);
        return viewData;
    }

    public async Task Remove(int id) {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data != null) {
            _context.LeaveTypes.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
    public async Task Edit(LeaveTypeEditVM model) {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Create(LeaveTypeCreateVM model) {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }

    public bool LeaveTypeExists(int id) {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }
    public async Task<bool> CheckIfLeafTypeNameExistAsync(string name) {
        return await _context.LeaveTypes.AnyAsync(m => m.Name.ToLower().Equals(name.ToLower()));
    }

    public async Task<bool> CheckIfLeafTypeNameExistForEditAsync(LeaveTypeEditVM leaveTypeEdit) {
        return await _context.LeaveTypes.AnyAsync(m => m.Name.ToLower().Equals(leaveTypeEdit.Name.ToLower()) && m.Id != leaveTypeEdit.Id);
    }
}
