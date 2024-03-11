using SQLite;
using Swd.TimeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


    }
}

