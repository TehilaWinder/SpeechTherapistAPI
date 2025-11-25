
using Microsoft.EntityFrameworkCore;
using SpeechTherapist.Core.Entities;

namespace SpeechTherapist.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Patients> patients { get; set; }
        public DbSet<Appointments> appointments { get; set; }
        public DbSet<Treatments> treatments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SpeechTherapist_db");
        }


    }
}
