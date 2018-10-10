
using SelfHelp.IDAL;
using SelfHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.DAL.DAL
{
    public class MyTestListDAL : DaoBase, IMyTestListDAL
    {
        public List<Amount_Info> GetAmountList(int AType)
        {
            //List<string> GetList = new List<string> { ""};
            return context.Amount_Infos.Where(m => m.Amount_TypeID == AType).ToList();
        }
    }
}
