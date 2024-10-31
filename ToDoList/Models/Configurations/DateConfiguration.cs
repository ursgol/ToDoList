using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Domains;


namespace ToDoList.Models.Configurations
{
    public class DateConfiguration : EntityTypeConfiguration<Date>
    {
        public DateConfiguration()
        {
            ToTable("dbo.Dates");
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.FinishDate)
                .IsRequired();
        }
    }
}
