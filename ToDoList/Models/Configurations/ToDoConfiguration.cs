using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Domains;

namespace ToDoList.Models.Configurations
{
    public class ToDoConfiguration : EntityTypeConfiguration<ToDo>
    {
        public ToDoConfiguration()
        {
            ToTable("dbo.ToDos");

            HasKey(x => x.Id);

            Property(x => x.Task)
                .IsRequired();

          
        }

    }
}
