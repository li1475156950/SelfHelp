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
    public class MyTestListService : IMyTestListService
    {
        public MyTestListDAL dal;
        public MyTestListService()
        {
            dal = new MyTestListDAL();
        }
        public List<Amount_Info> GetAmountList(int AType)
        {
            return dal.GetAmountList(AType);
        }
    }
}
