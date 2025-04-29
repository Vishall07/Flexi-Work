using Flexi_Work.DataBaseManager;


namespace Flexi_Work.BizManager.EmployeeManager
{
    public class EmployeeRegistration
    {
        public String RegisterEmployeeInfo(EmployeeInfo employeeInfo)
        {
            EmployeeRegistrationDB employeeRegistrationDB = new EmployeeRegistrationDB();
            return employeeRegistrationDB.RegisterEmployeeInfoDB(employeeInfo);
        }
    }
}
