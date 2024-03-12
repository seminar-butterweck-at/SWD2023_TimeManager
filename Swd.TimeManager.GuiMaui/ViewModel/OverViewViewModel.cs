using CommunityToolkit.Mvvm.ComponentModel;
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
    public class OverViewViewModel : ObservableValidator
    {

        //Fields
        private TimeManagerDatabase _database;
        private ObservableCollection<OverViewData> _overViewList;


        //Properties
        public ObservableCollection<OverViewData> OverViewList
        {
            get { return _overViewList; }
            set
            {
                SetProperty(ref _overViewList, value);
            }
        }




        public OverViewViewModel()
        {
            _database = new TimeManagerDatabase();
            _overViewList = new ObservableCollection<OverViewData>();

        }



        public async System.Threading.Tasks.Task LoadOverViewDataAsync()
        {
            OverViewList = new ObservableCollection<OverViewData>(await _database.GetOverViewDataAsync());
        }



        private bool IsActionPossible()
        {
            bool isActionPossible = true;

            return isActionPossible;
        }

    }
}
