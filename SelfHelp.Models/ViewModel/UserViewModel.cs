using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Models.ViewModel
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        /// <summary>
        /// 用户身份标识列，唯一
        /// </summary>
        public string UserIdentity { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Pwd { get; set; }
        public int Age { get; set; }
        /// <summary>
        /// 用户出生日期
        /// </summary>
        public DateTime BornDate { get; set; }
        public string BornDateFormat { get; set; }
        /// <summary>
        /// 用户职业
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }
        public string  UserIntroduce { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 用户角色类型
        /// </summary>
        public string RoleName { get; set; }
    }
}
