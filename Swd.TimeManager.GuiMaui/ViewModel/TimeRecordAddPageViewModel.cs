using Swd.TimeManager.GuiMaui.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swd.TimeManager.GuiMaui.ViewModel
{

    
    public class TimeRecordAddPageViewModel : BaseViewModel
    {

        //Fields
        private TimeRecord _timeRecord;
        private int _timeRecordId;
        private ObservableCollection<Project> _projectList;
        private Project _selectedProject;
        private ObservableCollection<Person> _personList;
        private Person _selectedPerson;
        private ObservableCollection<Model.Task> _taskList;
        private Model.Task _selectedTask;
        private TimeManagerDatabase _database;


        //Properties
        public TimeRecord TimeRecord
        {
            get { return _timeRecord; }
            set
            {
                _timeRecord = value;
                OnPropertyChanged();
            }
        }
        public int TimeRecordId
        {
            get { return _timeRecordId; }
            set
            {
                _timeRecordId = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Project> ProjectList
        {
            get { return _projectList; }
            set
            {
                _projectList = value;
                OnPropertyChanged();
            }
        }
        public Project SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                _selectedProject = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Person> PersonList
        {
            get { return _personList; }
            set
            {
                _personList = value;
                OnPropertyChanged();
            }
        }
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Model.Task> TaskList
        {
            get { return _taskList; }
            set
            {
                _taskList = value;
                OnPropertyChanged();
            }
        }
        public Model.Task SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged();
            }
        }


        //Commands
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }



        public TimeRecordAddPageViewModel()
        {
            _database = new TimeManagerDatabase();

            TimeRecord = new TimeRecord { Date = DateTime.Today, Duration = 0.25M  };

            SaveCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Save(),
                //Can Execute: Methode die true/false zurücklieft
                () => IsActionPossible()
                );
            CancelCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Cancel(),
                //Can Execute: Methode die true/false zurücklieft
                () => IsActionPossible()
                );
        }



        public async System.Threading.Tasks.Task Save()
        {
            this.TimeRecord.ProjectId = this.SelectedProject.Id;

            await _database.SaveTimeRecordAsync(this.TimeRecord);
            await Shell.Current.GoToAsync("..");
        }

        public async System.Threading.Tasks.Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }


        public async System.Threading.Tasks.Task LoadProjectsAsync()
        {
            ProjectList = new ObservableCollection<Project>(await _database.GetProjectsAsync());
        }

        public async System.Threading.Tasks.Task LoadTasksAsync()
        {
            TaskList = new ObservableCollection<Model.Task>(await _database.GetTaskAsync());
        }

        public async System.Threading.Tasks.Task LoadPersonsAsync()
        {
            PersonList = new ObservableCollection<Person>(await _database.GetPersonsAsync());
        }


        private bool IsActionPossible()
        {
            bool isActionPossible = true;

            return isActionPossible;
        }


    }
}
