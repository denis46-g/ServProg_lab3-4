using Laba3_4.models;
using Microsoft.EntityFrameworkCore;

namespace Laba3_4.data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { }
        public DbSet<TestimonialService> Testimonials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestimonialService>().ToTable("testimonials");
        }
    }
}
