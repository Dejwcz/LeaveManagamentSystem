using LeaveManagamentSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagamentSystem.Web.Controllers {
    public class TestController : Controller {
        public IActionResult Index() {
            var data = new TestViewModel { 
                Name = "Student",
                DateOfBirth = new DateTime(1988,12,01),
            };
            return View(data);
        }
    }
}
