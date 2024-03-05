using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Swd.TimeManager.GuiMaui.Model;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
    
        public class PersonAddPageViewModel : BaseViewModel
        {
            //Fields
            private TimeManagerDatabase _database;
            private Person _person;


            //Properties
            public Person Person
            {
                get { return _person; }
                set
                {
                _person = value;
                    OnPropertyChanged();
                }
            }


            //Commands
            public ICommand SaveCommand { get; set; }
            public ICommand CancelCommand { get; set; }


        public PersonAddPageViewModel()
            {
                _database = new TimeManagerDatabase();
                Person = new Person { EntryDate = DateTime.Today, ExitDate = null};
                

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
                await _database.SavePersonAsync(this.Person);
                await Shell.Current.GoToAsync("..");
            }

        public async System.Threading.Tasks.Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private bool IsActionPossible()
            {
                bool isActionPossible = true;



                return isActionPossible;
            }
        }
}
