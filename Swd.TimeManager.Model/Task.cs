using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Model
{
    public class Task: ModelBase
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public string? Name { get; set; }


    }
}
