using Swd.TimeManager.Model;
using Swd.TimeManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Business
{
    public class PersonService
    {
        private IPersonRepository _repository;




        public PersonService() {


            _repository = new PersonRepository();

        }


        public void Add(Person item)
        {
            _repository.Add(item);
        }


        public async System.Threading.Tasks.Task AddAsync(Person item)
        {
            await _repository.AddAsync(item);
        }

        public IQueryable<Person> ReadAll()
        {
            return _repository.ReadAll();
        }
        public async Task<IQueryable<Person>> ReadAllAsync()
        {
            return await _repository.ReadAllAsync();

        }


        public Person ReadByKey(int id) {
        
            return _repository.ReadByKey(id);   
        }


        public void Update(Person item) {
            _repository.Update(item, item.Id);
        }



        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
