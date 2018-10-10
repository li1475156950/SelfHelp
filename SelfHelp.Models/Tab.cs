using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class Tab
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TID { get; set; }
        [StringLength(20)]
        public string TName { get; set; }
        public int TTID { get; set; }
    }
}
