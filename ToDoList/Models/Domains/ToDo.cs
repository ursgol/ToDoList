using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models.Domains
{
    public class ToDo
    {
       
        public int Id { get; set; }
        public string Task { get; set; }
       
        public bool Completed { get; set; }


        public int DateId { get; set; }

        public Date Date { get; set; }
    }
}
