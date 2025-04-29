public class EmployeeInfo{
    public EmployeeInfo()
    {
        Guid newGuid = Guid.NewGuid();
        this.EmployeeId = newGuid;
    }
    public Guid EmployeeId { get; set; }
    public String EmployeeName { get; set; }
    public String EmployeePhoneNumber {get; set;}
    public String EmployeeEmailId { get; set; }
    public String Password { get; set; }
}