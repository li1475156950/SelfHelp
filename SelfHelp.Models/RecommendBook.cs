using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class RecommendBook
    {
        /// <summary>
        /// 推荐书籍自增ID
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecBoID { get; set; }
        /// <summary>
        /// 书籍名称
        /// </summary>
        [StringLength(50)]
        public string RecBoName { get; set; }
        /// <summary>
        /// 书籍封面图片
        /// </summary>
        [StringLength(100)]
        public string RecBoImgSrc { get; set; }
        /// <summary>
        /// 作者名称
        /// </summary>
        [StringLength(500)]
        public string AuthorName { get; set; }
        /// <summary>
        /// 作者简介
        /// </summary>
        [MaxLength]
        public string AuthorIntroduce { get; set; }
       
        /// <summary>
        /// 书籍书评
        /// </summary>
        [MaxLength]
        public string RecoBoComment { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [StringLength(50)]
        public string CreatePerson { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 书籍简介
        /// </summary>
        [MaxLength]
        public string BookIntroduce { get; set; }
    }
}
