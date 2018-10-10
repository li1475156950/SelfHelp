using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class PsychologyDictionary
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PDID { get; set; }
        [StringLength(50)]
        public string PDName { get; set; }
        [StringLength(20)]
        public string PDSpell { get; set; }
        [MaxLength]
        public string PDContent { get; set; }
        [StringLength(50)]
        public string CreatePerson { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
