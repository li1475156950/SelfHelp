using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class Chapter
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChapID { get; set; }
        [StringLength(50)]
        public string ChapName { get; set; }
        /// <summary>
        /// 章节视频地址
        /// </summary>
        [StringLength(100)]
        public string ChapVideoSrc { get; set; }
        /// <summary>
        /// 所属课程ID
        /// </summary>
        public int CouID { get; set; }

    }
}
