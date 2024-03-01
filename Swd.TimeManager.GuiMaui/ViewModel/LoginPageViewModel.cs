using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
    public class LoginPageViewModel: INotifyPropertyChanged
    {
        //Fields
        private string _username;
        private string _password;

        //Events
        public event PropertyChangedEventHandler PropertyChanged;


        //Properties
        public string Username
        {
            get { return _username; }
            set { 
                _username = value;
                OnPropertyChanged("Username");
                }
        }

        public string Password
        {
            get { return _password; }
            set { 
                _password = value;
                OnPropertyChanged();
            }
        }


        //Commands
        public ICommand LoginCommand { get; set; }



        public LoginPageViewModel() {
            Username = "marcel.butterweck";
            Password = "12345";


            LoginCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Login(),
                //Can Execute: Methode die true/false zurücklieft
                () => IsLoginDataComplete()
                );

        }


        public void OnPropertyChanged([CallerMemberName] string name = "" ) =>
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( name ) );


        public async Task Login()
        {
            //await Shell.Current.GoToAsync("main");
            Application.Current.MainPage = new AppShell();
        }


        private bool IsLoginDataComplete()
        {
            bool isLoginDataComplete = true;



            return isLoginDataComplete;
        }

    }
}
