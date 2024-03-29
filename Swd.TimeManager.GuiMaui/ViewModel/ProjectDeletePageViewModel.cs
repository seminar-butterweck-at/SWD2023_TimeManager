﻿using Swd.TimeManager.GuiMaui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
    [QueryProperty(nameof(ProjectId), "projectId")]
    public class ProjectDeletePageViewModel : BaseViewModel
    {

        //Fields
        private Project _project;
        private int _projectId;
        private TimeManagerDatabase _database;


        //Properties
        public Project Project
        {
            get { return _project; }
            set
            {
                _project = value;
                OnPropertyChanged();
            }
        }

        public int ProjectId
        {
            get { return _projectId; }
            set
            {
                _projectId = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        public ProjectDeletePageViewModel()
        {
            _database = new TimeManagerDatabase();

            DeleteCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Delete(),
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

        public async System.Threading.Tasks.Task Delete()
        {
            TimeManagerDatabase database = new TimeManagerDatabase();
            await database.DeleteProjectAsync(this.Project);
            await Shell.Current.GoToAsync("..");
        }

        public async System.Threading.Tasks.Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async System.Threading.Tasks.Task LoadProjectAsync()
        {
            Project = await _database.GetProjectByIdAsync(ProjectId);
        }


        private bool IsActionPossible()
        {
            bool isActionPossible = true;

            return isActionPossible;
        }

    }
}
