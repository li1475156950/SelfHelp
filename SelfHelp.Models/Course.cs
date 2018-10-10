using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class Course
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CouID { get; set; }
        [StringLength(50)]
        public string CouName { get; set; }
        [StringLength(500)]
        public string CouImgSrc { get; set; }
        [MaxLength]
        public string CouIntroduce { get; set; }
        [StringLength(100)]
        public string CreatePerson { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
