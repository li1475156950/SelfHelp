using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models.ViewModel
{
    public class PsychicArticleViewModel
    {
        public int PAID { get; set; }
        /// <summary>
        /// 心理美文名称
        /// </summary>
        public string PAName { get; set; }
        /// <summary>
        /// 心理美文内容
        /// </summary>
        public string PAContent { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatePerson { get; set; }
        /// <summary>
        /// 文章类别
        /// </summary>
        public string ATName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        public int ATID { get; set; }
        public int TabID { get; set; }
    }
}
