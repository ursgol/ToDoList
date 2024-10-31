using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models.Wrappers
{
    public class DateWrapper
    {
    

        public int Id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime FinishDate { get; set; }



        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Id):
                        if (Id == 0)
                        {
                            Error = "The Field Id is Required.";
                        }
                        else
                        {
                            Error = string.Empty;
                        }
                        break;

                    default:
                        break;
                }
                return Error;
            }
        }

        public string Error { get; set; }


        public bool IsValid
        {
            get
            {
                return string.IsNullOrWhiteSpace(Error);

            }
        }
    }

}
