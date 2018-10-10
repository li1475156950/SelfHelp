using SelfHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.IDAL
{
    public interface IMyTestListDAL : IRepository
    {
        List<Amount_Info> GetAmountList(int AType);
    }
}
