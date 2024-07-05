using Microsoft.EntityFrameworkCore;
using StudentAPIFakeDataCRUD.API.Models;

namespace StudentAPIFakeDataCRUD.API.Data
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=data source=(localdb)\\MSSQLLocalDB;Initial Catalog=FakeDataStudentDB;User Id=sa;Password=123;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Ali",
                    Surname = "Veli",
                    Address = "test adres",
                    City = "istanbul",
                    Email = "aliveli@gmail.com",
                    Phone = "0212 123 45 67"
                },
                new Student
                {
                    Id = 2,
                    Name = "Ali",
                    Surname = "Doğru",
                    Address = "test adres",
                    City = "istanbul",
                    Email = "alidogru@gmail.com",
                    Phone = "0212 123 45 68"
                },
                new Student
                {
                    Id = 3,
                    Name = "Tarık",
                    Surname = "Kır",
                    Address = "test adres",
                    City = "İzmir",
                    Email = "tarikkir@gmail.com",
                    Phone = "0312 123 45 67"
                },
                new Student
                {
                    Id = 4,
                    Name = "Cem",
                    Surname = "Can",
                    Address = "test adres",
                    City = "Bursa",
                    Email = "cemcan@gmail.com",
                    Phone = "0458 123 45 67"
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
