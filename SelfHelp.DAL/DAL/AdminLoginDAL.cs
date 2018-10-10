using SelfHelp.IDAL;
using SelfHelp.Models;
using SelfHelp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.DAL.DAL
{
    public class AdminLoginDAL:DaoBase,IAdminLoginDAL
    {
        public User Login(string userName,string pwd)
        {
            pwd = Encrypt.MD5(pwd);
            var temp = context.Users.AsNoTracking().Where(m => m.UserName == userName && m.Pwd == pwd).FirstOrDefault();
            return temp;
        }
    }
}
