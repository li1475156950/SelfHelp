using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class VideoClip
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VCID { get; set; }
        [StringLength(50)]
        public string VCName { get; set; }
        [StringLength(100)]
        public string VCImgSrc { get; set; }
        [StringLength(100)]
        public string VCSrc { get; set; }
        [StringLength(100)]
        public string CreatePerson { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
