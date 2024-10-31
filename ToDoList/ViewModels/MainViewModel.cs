using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.ObjectModel;

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using ToDoList.Commands;
using ToDoList.Models.Domains;
using ToDoList.Models.Wrappers;
using ToDoList.Views;


namespace ToDoList.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();

        public MainViewModel()
        {
          
            RefreshToDoCommand = new RelayCommand(RefreshToDo, CanRefreshToDo);
            AddToDoCommand = new RelayCommand(AddEditToDo);
            EditToDoCommand = new RelayCommand(AddEditToDo, CanEditDeleteToDo);
            DeleteToDoCommand = new AsyncRelayCommand(DeleteToDo, CanEditDeleteToDo);
            InitDates();
            RefreshToDo();
        }


        public ICommand RefreshToDoCommand {  get; set; }
        public ICommand AddToDoCommand { get; set; }
        public ICommand EditToDoCommand { get; set; }
        public ICommand DeleteToDoCommand { get; set; }
        public ICommand AddDateCommand { get; set; }

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
            dates.Insert(0, new Date { Id = 0, FinishDate = DateTime.Today });

            Dates = new ObservableCollection<Date>(dates);

            SelectedDateId = 0;
        }
        private ToDoWrapper _selectedToDo;
        public ToDoWrapper SelectedToDo
        {
            get => _selectedToDo;
            set
            {
                _selectedToDo = value;
                OnPropertyChanged();
            }
        }


        private DateTime _selectedDate;

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set { _selectedDate = value; OnPropertyChanged(); }
        }


        private ObservableCollection<ToDoWrapper> _toDos;
        public ObservableCollection<ToDoWrapper> ToDos
        {
            get { return _toDos; }
            set
            {
                _toDos = value;
                OnPropertyChanged();
            }
        }


        private void RefreshToDo(object obj)
        {
            RefreshToDo();
        }


        private async Task DeleteToDo(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog =await metroWindow.ShowMessageAsync("Delete Task", $"Are you sure that you want to delete task {SelectedToDo.Task}?",
                MessageDialogStyle.AffirmativeAndNegative);

            if(dialog != MessageDialogResult.Affirmative)
            {
                return;
            }

            _repository.DeleteToDo(SelectedToDo.Id);

            RefreshToDo();
        }

        private void AddEditToDo(object obj)
        {
            var addEditToDoWindow = new AddEditToDoView(obj as ToDoWrapper);
            addEditToDoWindow.Closed += AddEditToDoWindow_Closed;
            addEditToDoWindow.ShowDialog();

        }




        private void AddEditToDoWindow_Closed(object sender, EventArgs e)
        {
            RefreshToDo();
        }

    


        private bool CanRefreshToDo(object obj)
        {
            return true;
        }

        private bool CanEditDeleteToDo(object obj)
        {
            return SelectedToDo != null;
        }

        private void RefreshToDo()
        {
            ToDos = new ObservableCollection<ToDoWrapper>(_repository.GetToDos(SelectedDateId));
           
        }

    }
}
