using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models
{
    public class User
    {
        /// <summary>
        /// 用户表标识
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        /// <summary>
        /// 用户身份标识列，唯一
        /// </summary>
        [StringLength(50)]
        public string UserIdentity { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [StringLength(20)]
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [StringLength(50)]
        public string Pwd { get; set; }
        /// <summary>
        /// 用户出生日期
        /// </summary>
        public DateTime BornDate { get; set; }
        /// <summary>
        /// 用户职业
        /// </summary>
        [StringLength(20)]
        public string Job { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        [StringLength(20)]
        public string Tel { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        [StringLength(20)]
        public string Email { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        [StringLength(4)]
        public string Sex { get; set; }
        /// <summary>
        /// 用户角色类型
        /// </summary>
        public int RoleID { get; set; }
        [StringLength(50)]
        public string CreatePerson { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        [StringLength(100)]
        public string UserImg { get; set; }
        /// <summary>
        /// 用户简介，特指咨询师简介
        /// </summary>
        [MaxLength]
        public string UserIntroduce { get; set; }
    }
}
