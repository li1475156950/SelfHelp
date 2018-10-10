using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class PsychologyExperiment
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PEID { get; set; }
        /// <summary>
        /// 心理学实验名称
        /// </summary>
        [StringLength(50)]
        public string PEName { get; set; }
        /// <summary>
        /// 心理学实验封面图片
        /// </summary>

        [StringLength(100)]
        public string PEImage { get; set; }
        /// <summary>
        /// 心理学实验内容
        /// </summary>
        [MaxLength]
        public string PEContent { get; set; }
        [StringLength(100)]
        public string CreatePerson { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
