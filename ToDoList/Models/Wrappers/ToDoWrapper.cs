using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models.Wrappers
{
    public class ToDoWrapper : IDataErrorInfo
    {
        public ToDoWrapper()
        {
            Date = new DateWrapper();
        }


        public int Id { get; set; }
        public string Task { get; set; }
     
        public bool Completed { get; set; }
        public int DateId { get; set; }

        public DateWrapper Date { get; set; }


        private bool _isTaskValid;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Task):
                        if (string.IsNullOrWhiteSpace(Task))
                        {
                            Error = "The Field Task is Required.";
                            _isTaskValid = false;
                        }
                        else
                        {
                            _isTaskValid = true;
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
                return _isTaskValid && Date.IsValid; 

            }
        }
    }
}
