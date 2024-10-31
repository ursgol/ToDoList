using System;
using System.Data.Entity;
using System.Linq;
using ToDoList.Models.Configurations;
using ToDoList.Models.Domains;

namespace ToDoList
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Date> Dates { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ToDoConfiguration());
          
        }
    }

    
}