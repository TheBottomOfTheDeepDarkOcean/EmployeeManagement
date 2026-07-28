namespace EmployeesManagement.Models
{
    public class Holiday : UserActivity
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }
    }
}
