using System.Data.Entity;

namespace EventPlanning.Mvc.Models.Entities
{
    public class EventPlanningContext : DbContext
    {
        public EventPlanningContext() : base("EventPlanningContext")

        {

        }

        public DbSet<FullName> FullNames { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<EventReward> EventRewards { get; set; }
        public DbSet<IssuedReward> IssuedRewards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasMany(c => c.Employees)
                .WithMany(s => s.Events)
                .Map(t => t.MapLeftKey("EventId")
                    .MapRightKey("EmployeeId")
                    .ToTable("EventEmployee"));
        }
    }
}