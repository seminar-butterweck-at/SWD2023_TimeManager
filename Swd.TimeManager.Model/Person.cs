using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Model
{
    public class Person: ModelBase
    {

        public long Id { get; set; }
        
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string DisplayName { get; }


        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }
    }

}






