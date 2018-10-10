using SelfHelp.Contract;
using SelfHelp.DAL.DAL;
using SelfHelp.IDAL;
using SelfHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.BLL
{
    public class AdminLoginService:IAdminLoginService
    {
        public IAdminLoginDAL dal;
        public AdminLoginService()
        {
            dal = new AdminLoginDAL();
        }
        public User Login(string userName,string pwd)
        {
            return dal.Login(userName,pwd);
        }
    }
}
