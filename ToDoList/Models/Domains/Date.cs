using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models.Domains
{
    public class Date
    {
        public Date()
        {
            ToDos = new Collection<ToDo>();

        }

        public int Id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime FinishDate { get; set; }

        public ICollection<ToDo> ToDos { get; set; }


    }
}
