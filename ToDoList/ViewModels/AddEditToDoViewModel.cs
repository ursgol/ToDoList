using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToDoList.Commands;
using ToDoList.Models.Domains;
using ToDoList.Models.Wrappers;

namespace ToDoList.ViewModels
{
    public class AddEditToDoViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();

        public AddEditToDoViewModel(ToDoWrapper todo = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);


            if (todo == null) 
            {
                ToDo = new ToDoWrapper();
            }
            else
            {
                ToDo = todo;
                IsUpdate = true;
            }

            InitDates();
        }

     

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

       

        private int _selectedDateId;
        public int SelectedDateId
        {
            get { return _selectedDateId; }
            set
            {
                _selectedDateId = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Date> _date;

        public ObservableCollection<Date> Dates
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private void InitDates()
        {
            var dates = _repository.GetDates();
            dates.Insert(0, new Date { Id = 0, FinishDate = DateTime.Now });

            Dates = new ObservableCollection<Date>(dates);

            SelectedDateId = 0;
        }

        private bool _isUpdate;
        public bool IsUpdate
        {
            get { return _isUpdate; }
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }
        private ToDoWrapper _todo;
        public ToDoWrapper ToDo
        {
            get { return _todo; }
            set
            {
                _todo = value;
                OnPropertyChanged();
            }
        }
        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void Confirm(object obj)
        {
            if (!ToDo.IsValid)
                return;

            if (!IsUpdate)
            {
                AddToDo();
            }
            else
            {
                UpdateToDo();
            }

            CloseWindow(obj as Window);

        }

        private void UpdateToDo()
        {
            _repository.UpdateToDo(ToDo);
        }

        private void AddToDo()
        {
            _repository.AddToDo(ToDo);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}
