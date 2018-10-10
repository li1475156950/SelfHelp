using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class MovieAppreciation
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MAID { get; set; }
        /// <summary>
        /// 电影赏析名称
        /// </summary>
        [StringLength(50)]
        public string MAName { get; set; }
        /// <summary>
        /// 封面图片地址
        /// </summary>
        [StringLength(50)]
        public string MAImgSrc { get; set; }
        /// <summary>
        /// 视频地址
        /// </summary>
        [StringLength(50)]
        public string MAMovieSrc { get; set; }
        /// <summary>
        /// 赏析
        /// </summary>
        [MaxLength]
        public string MAAppreciation { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [StringLength(50)]
        public string CreatePerson { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
