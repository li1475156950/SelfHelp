using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models.ViewModel
{
    public class ReportListTableViewModel
    {
        public List<ReportListModel> ModelList { get; set; }
        public int PageCount { get; set; }
    }
}
