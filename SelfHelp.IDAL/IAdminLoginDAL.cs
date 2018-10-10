using SelfHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.IDAL
{
    public interface IAdminLoginDAL:IRepository
    {
        User Login(string userName,string pwd);
    }
}
