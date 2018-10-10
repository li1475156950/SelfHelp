using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class PsychologyImage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PsyImgID { get; set; }
        [StringLength(20)]
        public string PsyImgName { get; set; }
        [StringLength(100)]
        public string PsyImgSrc { get; set; }
        public int PsyImgTypeID { get; set; }
        [StringLength(50)]
        public string CreatePerson { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
