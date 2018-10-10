using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models.ViewModel
{
    public class PsychologyImageViewModel
    {
        public int PsyImgID { get; set; }
        public string PsyImgName { get; set; }
        public string PsyImgSrc { get; set; }
        public string PsyImgTypeName { get; set; }
        public string CreatePerson { get; set; }
        public DateTime? CreateTime { get; set; }
        public int PsyImgTypeID { get; set; }
    }
}
