using LeaveManagamentSystem.Web.Models.LeaveTypes;

namespace LeaveManagamentSystem.Web.Services {
    public interface ILeaveTypesService {
        Task<bool> CheckIfLeafTypeNameExistAsync(string name);
        Task<bool> CheckIfLeafTypeNameExistForEditAsync(LeaveTypeEditVM leaveTypeEdit);
        Task Create(LeaveTypeCreateVM model);
        Task Edit(LeaveTypeEditVM model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypesAsync();
        bool LeaveTypeExists(int id);
        Task Remove(int id);
    }
}