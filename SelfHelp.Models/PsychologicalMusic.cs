using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class PsychologicalMusic
    {
        public PsychologicalMusic() 
        {
            TabID = 0;
        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PMID { get; set; }
        [StringLength(50)]
        public string PMName { get; set; }
        /// <summary>
        /// 心里音乐封面图片
        /// </summary>
        [StringLength(50)]
        public string PMImgSrc { get; set; }
        /// <summary>
        /// 音乐地址
        /// </summary>
        [StringLength(100)]
        public string PMSrc { get; set; }
        /// <summary>
        /// 音乐类型
        /// </summary>
        public int MTID { get; set; }
        [StringLength(100)]
        public string CreatePerson { get; set; }
        public DateTime? CreateTime { get; set; }
        public int TabID { get; set; }
    }
}
