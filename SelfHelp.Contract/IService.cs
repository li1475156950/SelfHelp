using System;
using System.ServiceModel;
using System.Collections.Generic;
using SelfHelp.Models;
using SelfHelp.Common;

namespace SelfHelp.Contract
{
    [ServiceContract]
    public interface IService
    {   
        [OperationContract]
        List<Role> GetProducts(int pageSize, int pageIndex, int categoryId = 0);
    }
}
