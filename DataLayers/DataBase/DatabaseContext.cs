using DataLayers.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayers.DataBase
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataBaseUser>().Property(e => e.id).ValueGeneratedOnAdd();

            // Create user
            var user = new DataBaseUser()
            {
                id = 1,
                Names = "John Doe",
                Password = "1234",
                Email = "JohnDoe@abv.bg",
                Fac_Num = " ",
                Role = Welcome.Others.UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            };
            var user1 = new DataBaseUser()
            {
                id = 2,
                Names = "Derek Smith",
                Password = "1234",
                Email = "JohnDoe@abv.bg",
                Fac_Num = " ",
                Role = Welcome.Others.UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddYears(5)
            };
            var user2 = new DataBaseUser()
            {
                id = 3,
                Names = "Steven Adams",
                Password = "1234",
                Email = "JohnDoe@abv.bg",
                Fac_Num = " ",
                Role = Welcome.Others.UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddYears(7)
            };
            modelBuilder.Entity<DataBaseUser>().HasData(user);
            modelBuilder.Entity<DataBaseUser>().HasData(user1);
            modelBuilder.Entity<DataBaseUser>().HasData(user2);
        }
        public DbSet<DataBaseUser> Users { get; set; }
        public DbSet<LogEntry> Logs { get; set; }

    }


}
