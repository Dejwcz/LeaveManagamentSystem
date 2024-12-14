using System.ComponentModel.DataAnnotations;

namespace LeaveManagamentSystem.Web.Models.LeaveTypes {
    public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM {
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Number of days")]
        public int NumberOfDays { get; set; }
    }
}