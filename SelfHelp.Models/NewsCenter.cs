using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class NewsCenter
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NCID { get; set; }
        [StringLength(100)]
        public string NCTitle { get; set; }
        [MaxLength]
        public string NCContent { get; set; }
        public string CreatePerson { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
