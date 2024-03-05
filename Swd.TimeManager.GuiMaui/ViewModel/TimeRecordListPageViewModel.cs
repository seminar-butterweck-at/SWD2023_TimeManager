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
    public class TimeRecordListPageViewModel : BaseViewModel
    {
        //Fields
        private TimeManagerDatabase _database;
        private ObservableCollection<TimeRecord> _timeRecordList;


        //Properties
        public ObservableCollection<TimeRecord> TimeRecordList
        {
            get { return _timeRecordList; }
            set
            {
                _timeRecordList = value;
                OnPropertyChanged();
            }
        }


        //Commands
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }



        public TimeRecordListPageViewModel()
        {
            _database = new TimeManagerDatabase();
            _timeRecordList = new ObservableCollection<TimeRecord>();

            AddCommand = new Command(
                () => Add(),
                () => IsActionPossible()
                );
            EditCommand = new Command(
                (object projectId) => Edit(projectId),
                (object projectId) => IsActionPossible()
                );
            DeleteCommand = new Command(
                (object projectId) => Delete(projectId),
                (object projectId) => IsActionPossible()
                );
        }



        public async System.Threading.Tasks.Task LoadTimeRecordsAsync()
        {
            TimeRecordList = new ObservableCollection<TimeRecord>(await _database.GetTimeRecordsAsync());
        }

        public async System.Threading.Tasks.Task Add()
        {
            await Shell.Current.GoToAsync("timerecordadd");
        }


        public async System.Threading.Tasks.Task Edit(object timeRecordId)
        {
            if(int.TryParse(timeRecordId.ToString(), out int id))
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    {"timeRecordId", id }
                };                    ;
                await Shell.Current.GoToAsync("timerecordedit", navigationParameter);
            }
        }


        public async System.Threading.Tasks.Task Delete(object timeRecordId)
        {
            if (int.TryParse(timeRecordId.ToString(), out int id))
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    {"timeRecordId", id }
                }; ;
                await Shell.Current.GoToAsync("timerecorddelete", navigationParameter);
            }
        }

        private bool IsActionPossible()
        {
            bool isActionPossible = true;


            return isActionPossible;
        }

    }
}
