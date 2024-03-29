﻿using Microsoft.EntityFrameworkCore;
using Swd.TimeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Repository
{
    public class TimeRecordRepository : GenericRepository<TimeRecord, TimeManagerContext>, ITimeRecordRepository
    {


        public TimeRecord ReadByKeyInklusive(object key)
        {
            TimeManagerContext context = new TimeManagerContext();
            var timeRecord = context.TimeRecord
                .Include(rec => rec.Person)
                .Include(rec => rec.Project)
                .Include(rec => rec.Task)
                .Where(w => w.Id == Convert.ToInt64(key))
                .FirstOrDefault();
            return timeRecord;
        }


    }
}
