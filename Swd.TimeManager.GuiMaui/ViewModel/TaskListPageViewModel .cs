using Swd.TimeManager.GuiMaui.Model;
using Swd.TimeManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
    public class TaskListPageViewModel : BaseViewModel
    {
        //Fields
        private TimeManagerDatabase _database;
        private ObservableCollection<Model.Task> _taskList;


        //Properties
        public ObservableCollection<Model.Task> TaskList
        {
            get { return _taskList; }
            set
            {
                _taskList = value;
                OnPropertyChanged();
            }
        }


        //Commands
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }



        public TaskListPageViewModel()
        {
            _database = new TimeManagerDatabase();
            TaskList = new ObservableCollection<Model.Task>();

            AddCommand = new Command(
                () => Add(),
                () => IsActionPossible()
                );
            EditCommand = new Command(
                (object taskId) => Edit(taskId),
                (object taskId) => IsActionPossible()
                );
            DeleteCommand = new Command(
                (object taskId) => Delete(taskId),
                (object taskId) => IsActionPossible()
                );
        }



        public async System.Threading.Tasks.Task LoadTasksAsync()
        {
            TaskList = new ObservableCollection<Model.Task>(await _database.GetTaskAsync());

        }

        public async System.Threading.Tasks.Task Add()
        {
            await Shell.Current.GoToAsync("taskadd");
        }


        public async System.Threading.Tasks.Task Edit(object taskId)
        {
            if(int.TryParse(taskId.ToString(), out int id))
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    {"taskId", id }
                };                    ;
                await Shell.Current.GoToAsync("taskedit", navigationParameter);
            }
        }


        public async System.Threading.Tasks.Task Delete(object taskId)
        {
            if (int.TryParse(taskId.ToString(), out int id))
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    {"taskId", id }
                }; ;
                await Shell.Current.GoToAsync("taskdelete", navigationParameter);
            }
        }

        private bool IsActionPossible()
        {
            bool isActionPossible = true;


            return isActionPossible;
        }

    }
}
