using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models.Domains;
using ToDoList.Models.Wrappers;
using ToDoList.Models.Converters;
using System.Data.Entity;

namespace ToDoList
{
   public class Repository
    {
        public List<Date> GetDates()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Dates.ToList();
            }
        }
        public List<ToDoWrapper> GetToDos(int dateId)
        {
            using (var context = new ApplicationDbContext())
            {
                var todos = context.ToDos.Include(x=>x.Date).AsQueryable();

                if (dateId != 0)
                    todos = todos.Where(x => x.DateId == dateId);


                return todos
                    .ToList()
                    .Select(x => x.ToWrapper())
                    .ToList();
            }
        }

        public void DeleteToDo(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var todoToDelete = context.ToDos.Find(id);
                context.ToDos.Remove(todoToDelete);
                context.SaveChanges();
            }
        }

        public void UpdateToDo(ToDoWrapper toDoWrapper)
        {
            var todo = toDoWrapper.ToDao();

            using(var context = new ApplicationDbContext())
            {
                var todoToUpdate = context.ToDos.Find(todo.Id);
                todoToUpdate.Task = todo.Task;
                todoToUpdate.DateId = 2;
                todoToUpdate.Completed = todo.Completed;

                context.SaveChanges();
            }

        }

    

        public void AddToDo(ToDoWrapper toDoWrapper)
        {
            var todo = toDoWrapper.ToDao();

            using(var context = new ApplicationDbContext())
            {
                var dbToDo = context.ToDos.Add(todo);
                dbToDo.DateId = 1;
                context.SaveChanges();

            }
        }

       
    }
}
