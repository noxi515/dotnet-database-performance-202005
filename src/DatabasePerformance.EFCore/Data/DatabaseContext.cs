using Microsoft.EntityFrameworkCore;

namespace DatabasePerformance.Data
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<SampleEntity> SampleEntities { get; set; } = null!;

        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder models)
        {
            base.OnModelCreating(models);

            models.Entity<SampleEntity>(builder =>
            {
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id).HasColumnName("id");
                builder.Property(e => e.Name).HasColumnName("name");
                builder.Property(e => e.Age).HasColumnName("age");
                builder.Property(e => e.Date).HasColumnName("date");
            });
        }
    }
}