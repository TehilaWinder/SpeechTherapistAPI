
using Microsoft.EntityFrameworkCore;
using SpeechTherapist.Core.Entities;
using System.Data;
using System.Numerics;

namespace SpeechTherapist.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Users> users { get; set; }
        public DbSet<SpeechTerapist> speechTerapists { get; set; }
        public DbSet<Patients> patients { get; set; }
        public DbSet<Appointments> appointments { get; set; }
        public DbSet<Treatments> treatments { get; set; }

        public DbSet<Report> reports { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SpeechTherapist_db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // 1. קשר בין מטופל למשתמש
            modelBuilder.Entity<Patients>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserCode)
                .OnDelete(DeleteBehavior.NoAction); // מניעת קריסה במחיקה

            // 2. קשר בין מטופל לקלינאי
            modelBuilder.Entity<Patients>()
                .HasOne(p => p.speechTherapist)
                .WithMany()
                .HasForeignKey(p => p.SpeechTherapistCode)
                .OnDelete(DeleteBehavior.NoAction);

            // 3. קשר בין קלינאי למשתמש
            modelBuilder.Entity<SpeechTerapist>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserCode)
                .OnDelete(DeleteBehavior.NoAction);

            // 4. קשר בין דיווח (Report) למטופל
            modelBuilder.Entity<Report>()
                .HasOne(r => r.Patient)
                .WithMany()
                .HasForeignKey(r => r.PatientCode)
                .OnDelete(DeleteBehavior.NoAction);

            // 5. קשר בין דיווח לקלינאי
            modelBuilder.Entity<Report>()
                .HasOne(r => r.SpeechTherapist)
                .WithMany()
                .HasForeignKey(r => r.SpeechTherapistCode)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Users>(b =>
                {
                    b.Property(e => e.Type)
                        .HasConversion(
                            v => v.ToString(), // המרה לstring
                            v => Enum.Parse<eType>(v)); // המרה חזרה לenum
                });
            modelBuilder.Entity<SpeechTerapist>(b =>
            {
                b.Property(e => e.Education)
                    .HasConversion(
                        v => v.ToString(), // המרה לstring
                        v => Enum.Parse<eEducation>(v)); // המרה חזרה לenum
            });


        }
    }
}