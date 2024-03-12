using Microsoft.Maui.Controls;
using SQLite;
using Swd.TimeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Swd.TimeManager.GuiMaui.Model
{

    public class TimeManagerDatabase
    {
        SQLiteAsyncConnection _database;

        async System.Threading.Tasks.Task Init()
        {
            if(_database != null) {
                return;
            }

            var dir = FileSystem.AppDataDirectory;

            _database = new SQLiteAsyncConnection(Constants.DATABASEPATH, Constants.FLAGS);
            await _database.CreateTableAsync<Project>();
            await _database.CreateTableAsync<Person>();
            await _database.CreateTableAsync<TimeRecord>();
            await _database.CreateTableAsync<Task>();
        }


        public async Task<List<Project>> GetProjectsAsync()
        {
            await Init();
            return await _database.Table<Project>().ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int key)
        {
            await Init();
            return await _database.Table<Project>().Where(p=>p.Id == key).FirstOrDefaultAsync();
        }

        public async Task<int> SaveProjectAsync(Project project)
        {
            await Init();
            if(project.Id != 0) {
                return await _database.UpdateAsync(project);
            }
            else
            {
                return await _database.InsertAsync(project);
            }
        }

        public async Task<int> DeleteProjectAsync(Project project)
        {
            await Init();
            return await _database.DeleteAsync(project);
        }



        public async Task<List<TimeRecord>> GetTimeRecordsAsync()
        {
            await Init();
            return await _database.Table<TimeRecord>().ToListAsync();
        }

        public async Task<TimeRecord> GetTimeRecordByIdAsync(int key)
        {
            await Init();
            return await _database.Table<TimeRecord>().Where(p => p.Id == key).FirstOrDefaultAsync();
        }

        public async Task<int> SaveTimeRecordAsync(TimeRecord timeRecord)
        {
            await Init();
            if (timeRecord.Id != 0)
            {
                return await _database.UpdateAsync(timeRecord);
            }
            else
            {
                return await _database.InsertAsync(timeRecord);
            }
        }

        public async Task<int> DeletTimeRecordAsync(TimeRecord timeRecord)
        {
            await Init();
            return await _database.DeleteAsync(timeRecord);
        }


        public async Task<List<Person>> GetPersonsAsync()
        {
            await Init();
            return await _database.Table<Person>().ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int key)
        {
            await Init();
            return await _database.Table<Person>().Where(p => p.Id == key).FirstOrDefaultAsync();
        }

        public async Task<int> SavePersonAsync(Person person)
        {
            await Init();
            if (person.Id != 0)
            {
                return await _database.UpdateAsync(person);
            }
            else
            {
                return await _database.InsertAsync(person);
            }
        }

        public async Task<int> DeletePersonAsync(Person person)
        {
            await Init();
            return await _database.DeleteAsync(person);
        }


        public async Task<List<Task>> GetTaskAsync()
        {
            await Init();
            return await _database.Table<Task>().ToListAsync();
        }

        public async Task<Task> GetTaskByIdAsync(int key)
        {
            await Init();
            return await _database.Table<Task>().Where(p => p.Id == key).FirstOrDefaultAsync();
        }

        public async Task<int> SaveTaskAsync(Task task)
        {
            await Init();
            if (task.Id != 0)
            {
                return await _database.UpdateAsync(task);
            }
            else
            {
                return await _database.InsertAsync(task);
            }
        }

        public async Task<int> DeleteTaskAsync(Task task)
        {
            await Init();
            return await _database.DeleteAsync(task);
        }


        public async Task<List<SearchResult>> GetSearchResultAsync(string searchValue)
        {
            await Init();

            string sql = string.Empty;
            sql += "SELECT ";
            sql += "TimeRecord.Id as Id, ";
            sql += "TimeRecord.Date as Date, ";
            sql += "TimeRecord.ProjectId as ProjectId, ";
            sql += "Project.Name as ProjectName, ";
            sql += "TimeRecord.TaskId as TaskId, ";
            sql += "Task.Name as TaskName, ";
            sql += "TimeRecord.PersonId as PersonId, ";
            sql += "Person.LastName || ' ' || Person.FirstName as PersonName, ";
            sql += "TimeRecord.Duration as Duration ";
            sql += "FROM TimeRecord ";
            sql += "INNER JOIN Project ON TimeRecord.ProjectId = Project.Id ";
            sql += "INNER JOIN Person ON TimeRecord.PersonId = Person.Id ";
            sql += "INNER JOIN Task ON TimeRecord.TaskId = Person.Id ";
            //sql += "WHERE Project.Name like '%" + searchValue + "%' "; => Achtung SQL Injection
            sql += "WHERE Project.Name like ? ";
            sql += "ORDER BY Project.Name, TimeRecord.Date";

            string adaptedSearchValue = $"%{searchValue}%";

            var result = await _database.QueryAsync<SearchResult>(sql, adaptedSearchValue );
            return result.ToList();

        }


        public async Task<List<OverViewData>> GetOverViewDataAsync()
        {
            await Init();

            //OverViewData ov1 = new OverViewData { ProjectId = 1, ProjectName = "Project 1", Duration = 60.0M };
            //OverViewData ov2 = new OverViewData { ProjectId = 2, ProjectName = "Project 2", Duration = 100.25M };
            //OverViewData ov3 = new OverViewData { ProjectId = 3, ProjectName = "Project 3", Duration = 5.0M };
            //OverViewData ov4 = new OverViewData { ProjectId = 4, ProjectName = "Project 4", Duration = 12.0M };

            //List<OverViewData> l = new List<OverViewData>();
            //l.Add(ov1 );
            //l.Add(ov2); 
            //l.Add(ov3); 
            //l.Add(ov4);

            //1. Project aus Datenbank lesen
            //2. Zu jedem Projekt alle Tasks mit Summen lesen
            //3. Overviewdata um Liste mit den Taskinformationen (Taskname, Stunden) erweitern
            //4. Gesamtstundenanzahl berechnen und in OverViewData Duration speichern.


            List<OverViewData> overViewDataList = new List<OverViewData>();

            string sql = string.Empty;
            sql += "SELECT Id as ProjectId, Name as ProjectName from Project ";
            var projectList = await _database.QueryAsync<SearchResult>(sql);
            foreach ( var item in projectList )
            {
                string taskSql = string.Empty;
                taskSql += "SELECT Task.Name as Name, Sum(TimeRecord.Duration) as Duration ";
                taskSql += "FROM TimeRecord ";
                taskSql += "INNER JOIN Task ON TimeRecord.TaskId = Task.Id ";
                taskSql += "GROUP BY TimeRecord.ProjectId, Task.Name ";
                taskSql += "HAVING(TimeRecord.ProjectId = ?) ";

                var taskList = await _database.QueryAsync<OverViewTaskData>(taskSql, item.ProjectId);
                var sumDuration = taskList.Sum(x => x.Duration);


                OverViewData ovwData = new OverViewData();
                ovwData.ProjectId = item.ProjectId;
                ovwData.ProjectName = item.ProjectName;
                ovwData.Duration = sumDuration;
                ovwData.Tasks = taskList.ToList();
                overViewDataList.Add(ovwData);    
            }
            return overViewDataList;

        }


    }
}

