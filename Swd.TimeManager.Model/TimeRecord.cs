using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Model
{
    public class TimeRecord: ModelBase
    {

        public long Id { get; set; }
        public DateTime Date {  get; set; }
        public decimal Duration { get; set; }   

        public long PersonId { get; set; }  
        public Person Person { get; set; }
        
        public long ProjectId { get; set; }
        public Project Project { get; set; }

        public long TaskId { get; set; }
        public Task Task { get; set; }
    }
}
