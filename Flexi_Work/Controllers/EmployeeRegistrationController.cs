using Flexi_Work.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flexi_Work.BizManager.EmployeeManager;
namespace Flexi_Work.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeRegistrationController : ControllerBase
    {
        [HttpPost(Name = "PostJobRegistration")]
        public IActionResult Post(EmployeeInfo employeeInfo)
        {
            EmployeeRegistration employeeRegistration = new EmployeeRegistration();
            employeeRegistration.RegisterEmployeeInfo(employeeInfo);
            return Ok(employeeInfo);
        }
    }

}
