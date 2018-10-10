using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models.ViewModel
{
    public class AnalysisDataTableModel
    {
        public string TabName { get; set; }
        public int VisitPeopleCount { get; set; }
        public decimal AverageClickCount { get; set; }
        public decimal AverageStayTime { get; set; }
        public int TabTypeID { get; set; }
    }
}
