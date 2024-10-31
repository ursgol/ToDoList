using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Domains;
using ToDoList.Models.Wrappers;

namespace ToDoList.Models.Converters
{
    public static class ToDoConverter
    {
        public static ToDoWrapper ToWrapper(this ToDo model)
        {
            return new ToDoWrapper
            {
                Id = model.Id,
                Task = model.Task,
                Completed = model.Completed,
                DateId = model.DateId,
                Date = new DateWrapper { Id=model.Date.Id, FinishDate = model.Date.FinishDate}
            };
        }

        public static ToDo ToDao(this ToDoWrapper model)
        {
            return new ToDo
            {
                Id = model.Id,
                Task = model.Task,
                DateId = model.DateId,
                Completed = model.Completed
            };
        }
    }
}
