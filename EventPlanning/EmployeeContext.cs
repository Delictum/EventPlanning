using System.Data.Entity;

namespace EventPlanning
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=EventPlanningContainer")
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
