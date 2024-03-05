
using Swd.TimeManager.GuiMaui.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
 
    public class PersonListPageViewModel : BaseViewModel
    {
        //Fields
        private TimeManagerDatabase _database;
        private ObservableCollection<Person> _personList;
        private string _warning;


        //Properties
        public ObservableCollection<Person> PersonList
        {
            get { return _personList; }
            set
            {
                _personList = value;
                OnPropertyChanged();
            }
        }
        public string Warning
        {
            get { return _warning; }
            set
            {
                _warning = value;
                OnPropertyChanged();
            }
        }



        //Commands
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        public PersonListPageViewModel()
        {
            
            _database = new TimeManagerDatabase();
            _personList = new ObservableCollection<Person>();

            AddCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Add(),
                //Can Execute: Methode die true/false zurücklieft
                () => IsActionPossible()
                );
            EditCommand = new Command(
                //Execute: Methode die aufgerufen wird
                (object projectId) => Edit(projectId),
                //Can Execute: Methode die true/false zurücklieft
                (object projectId) => IsActionPossible()
                );
            DeleteCommand = new Command(
                //Execute: Methode die aufgerufen wird
                (object projectId) => Delete(projectId),
                //Can Execute: Methode die true/false zurücklieft
                (object projectId) => IsActionPossible()
                );

        }



        public async System.Threading.Tasks.Task LoadPersonAsync()
        {
            PersonList = new ObservableCollection<Person>(await _database.GetPersonsAsync());
        }

        
        public async System.Threading.Tasks.Task Add()
        {
            await Shell.Current.GoToAsync("personadd");
        }

        public async System.Threading.Tasks.Task Edit(object personId)
        {

            if(int.TryParse(personId.ToString(), out int id))
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    {"personId",id}
                };
                await Shell.Current.GoToAsync("personedit", navigationParameter) ;
            }

            
        }
        
        public async System.Threading.Tasks.Task Delete(object personId)
        {
            if (int.TryParse(personId.ToString(), out int id))
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    {"personId",id}
                };
                await Shell.Current.GoToAsync("persondelete", navigationParameter);
            }

        }


        private bool IsActionPossible()
        {
            bool isActionPossible = true;
            return isActionPossible;
        }


    }
}
