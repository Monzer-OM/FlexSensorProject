using FlexSensorProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FlexSensorProject.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Test>()
                .HasOne(c => c.Patient)
                .WithMany(u => u.Tests)
                .HasForeignKey(u => u.PatientId)
                .IsRequired();




        }



        public DbSet<Patient> Patients { get; set; }
        public DbSet<Test> Tests { get; set; }



    }
}
