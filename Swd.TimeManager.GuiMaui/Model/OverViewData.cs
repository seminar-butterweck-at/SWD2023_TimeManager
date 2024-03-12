using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.GuiMaui.Model
{
    public class OverViewData
    {
        public int ProjectId {  get; set; }
        public string ProjectName { get; set; }
        public decimal Duration { get; set; }   
        public List<OverViewTaskData> Tasks { get; set; }


        public OverViewData()
        {
            Tasks = new List<OverViewTaskData>();
        }

    }
}
