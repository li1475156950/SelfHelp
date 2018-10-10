using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class PsychicArticle
    {
        public PsychicArticle() 
        {
            TabID = 0;
        }
        /// <summary>
        /// 心理美文自增列
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PAID { get; set; }
        /// <summary>
        /// 心理美文名称
        /// </summary>
        [StringLength(50)]
        public string PAName { get; set; }
        /// <summary>
        /// 心理美文内容
        /// </summary>
        [MaxLength]
        public string PAContent { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [StringLength(50)]
        public string CreatePerson { get; set; }
        /// <summary>
        /// 文章类别
        /// </summary>
        public int ATID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        public int TabID { get; set; }
    }
}
