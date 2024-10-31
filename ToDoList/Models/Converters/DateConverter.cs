using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Domains;
using ToDoList.Models.Wrappers;

namespace ToDoList.Models.Converters
{
    static class DateConverter
    {
        public static DateWrapper ToWrapper(this Date model)
        {
            return new DateWrapper
            {
                Id = model.Id,
                FinishDate = model.FinishDate
            };
        }

        public static Date ToDao(this DateWrapper model)
        {
            return new Date
            {
                Id = model.Id,
                FinishDate = model.FinishDate
                
            };
        }
    }
}
