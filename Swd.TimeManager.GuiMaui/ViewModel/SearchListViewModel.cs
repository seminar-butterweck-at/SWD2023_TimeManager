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
    public class SearchListViewModel : BaseViewModel
    {


        //Fields
        private TimeManagerDatabase _database;
        private ObservableCollection<SearchResult> _resultList;
        private string _searchValue;
        private decimal _resultSum;


        //Properties
        public string SearchValue
        {
            get { return _searchValue; }
            set
            {
                _searchValue = value;
                OnPropertyChanged();
            }
        }
        public decimal ResultSum
        {
            get { return _resultSum; }
            set
            {
                _resultSum = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<SearchResult> ResultList
        {
            get { return _resultList; }
            set
            {
                _resultList = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand SearchCommand { get; set; }
        


        public SearchListViewModel()
        {
            _database = new TimeManagerDatabase();


 
            SearchCommand = new Command(
                (object searchValue) => Search(searchValue),
                (object searchValue) => IsActionPossible()
                );
        }





        public async System.Threading.Tasks.Task Search(object searchValue)
        {
            SearchValue = searchValue.ToString();
            ObservableCollection<SearchResult> resultList =
                new ObservableCollection<SearchResult>(await _database.GetSearchResultAsync(SearchValue));
            ResultList = resultList;

            ResultSum = ResultList.Sum(r => r.Duration);
        }




        private bool IsActionPossible()
        {
            bool isActionPossible = true;


            return isActionPossible;
        }

    }
}
