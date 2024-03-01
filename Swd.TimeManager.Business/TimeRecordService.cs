using Swd.TimeManager.Model;
using Swd.TimeManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Business
{
    public class TimeRecordService
    {
        private ITimeRecordRepository _repository;




        public TimeRecordService() {


            _repository = new TimeRecordRepository();

        }


        public void Add(TimeRecord item)
        {
            _repository.Add(item);
        }


        public async System.Threading.Tasks.Task AddAsync(TimeRecord item)
        {
            await _repository.AddAsync(item);
        }

        public IQueryable<TimeRecord> ReadAll()
        {
            return _repository.ReadAll();
        }
        public async Task<IQueryable<TimeRecord>> ReadAllAsync()
        {
            return await _repository.ReadAllAsync();

        }


        public TimeRecord ReadByKey(int id) {
        
            return _repository.ReadByKey(id);   
        }


        public void Update(TimeRecord item) {
            _repository.Update(item, item.Id);
        }



        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
