using SelfHelp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Contract
{
    [ServiceContract]
    public  interface IMyTestListService
    {
         [OperationContract(IsOneWay=false)]
        List<Amount_Info> GetAmountList(int AType);
    }
}
