using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class Psychologist
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PsyID { get; set; }
        /// <summary>
        /// 心理学家名称
        /// </summary>
        [StringLength(50)]
        public string PsyName { get; set; }
        /// <summary>
        /// 心理学家封面图
        /// </summary>
        [StringLength(200)]
        public string PsyImage { get; set; }
        /// <summary>
        /// 心理学家介绍
        /// </summary>
        [MaxLength]
        public string PsyContent { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [StringLength(100)]
        public string CreatePerson { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
