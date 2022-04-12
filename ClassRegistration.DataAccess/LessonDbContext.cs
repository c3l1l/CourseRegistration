using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRegistration.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassRegistration.DataAccess
{
    public class LessonDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=ClassRegistrationDb;Trusted_Connection=True;");
        }

        public DbSet<Lesson> Lessons { get; set; }
    }
}
