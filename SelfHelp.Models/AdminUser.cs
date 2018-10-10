using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class AdminUser
    {
        /// <summary>
        /// 管理员表ID
        /// </summary>
       [Key]
        public int AUID { get; set; }
       public int TestIDM { get; set; }
        /// <summary>
        /// 管理员用户ID,唯一
        /// </summary>
        [StringLength(20)]
        public string AUIdentity { get; set; }
        /// <summary>
        /// 管理员用户名称
        /// </summary>
        [StringLength(10)]
        public string AUName { get; set; }
        /// <summary>
        /// 管理员用户密码
        /// </summary>
        [StringLength(50)]
        public string AUPwd { get; set; }
    }
}
