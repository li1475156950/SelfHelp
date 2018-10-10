using System;
using SelfHelp.Contract;
using System.Collections.Generic;
using SelfHelp.Models;
using SelfHelp.IDAL;
using System.Linq.Expressions;
using SelfHelp.Common;
using SelfHelp.WCFExtension;

namespace SelfHelp.BLL
{
    public class Service : IService
    {
        public IDAO dao;
        
        public Service()
        {
            //Need to inject dynamic later
            this.dao = new SelfHelp.DAL.DAL.DAO();
        }
        public List<Role> GetProducts(int pageSize, int pageIndex, int categoryId = 0)
        {
            //Test WCFContext
            //var context = WCFContext.Current.Operater;
            
            return this.dao.FindAllByPage<Role, int>(p=>p.RoleName.Contains("adsf"), p => p.RoleID, pageSize, pageIndex);
        }
    }
}
