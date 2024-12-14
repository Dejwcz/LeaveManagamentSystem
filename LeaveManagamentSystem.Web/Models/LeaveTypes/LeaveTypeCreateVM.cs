using System.ComponentModel.DataAnnotations;

namespace LeaveManagamentSystem.Web.Models.LeaveTypes {
    public class LeaveTypeCreateVM {
        [Required]
        [Length(4, 150, ErrorMessage = "You hahe violated the length requirements")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1, 90)]
        [Display(Name = "Number of days")]
        public int NumberOfDays { get; set; }
    }
}