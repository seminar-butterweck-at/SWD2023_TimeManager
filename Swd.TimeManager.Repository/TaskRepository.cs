using Microsoft.EntityFrameworkCore;
using Swd.TimeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = Swd.TimeManager.Model.Task;


namespace Swd.TimeManager.Repository
{
    public class TaskRepository : GenericRepository<Task, TimeManagerContext>, ITaskRepository
    {

    }
}
