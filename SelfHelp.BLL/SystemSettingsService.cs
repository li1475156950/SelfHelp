using SelfHelp.Common;
using SelfHelp.Contract;
using SelfHelp.DAL.DAL;
using SelfHelp.IDAL;
using SelfHelp.Models;
using SelfHelp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.BLL
{
    public class SystemSettingsService : ISystemSettingsService
    {
        public ISystemSettingsDAL dal;
        public SystemSettingsService()
        {
            dal = new SystemSettingsDAL();
        }
        public string GetCompanyImages()
        {
            return dal.GetCompanyImages();
        }
        public Company GetCompanyEntity()
        {
            return dal.GetCompanyEntity();
        }
        public int Insert(Company entity)
        {
            return dal.InsertEntity(entity);
        }
        public int Update(Company entity)
        {
            return dal.UpdateEntity(entity);
        }
        public int UpdateCompany(Company entity)
        {
            return dal.UpdateCompany(entity);
        }
        public NewsCenterTableViewModel GetNewsCenterList(int pageSize, int pageIndex, string titleContent)
        {
            return dal.GetNewsCenterList(pageSize, pageIndex, titleContent);
        }
        public List<NewsCenter> NewDetails()
        {
            return dal.NewDetails();
        }
        public List<User> GetUser()
        {
            return dal.GetUser();
        }
        public int RemoveNews(string[] ncIDArray)
        {
            return dal.RemoveNews(ncIDArray);
        }
        public int AddNews(NewsCenter model)
        {
            return dal.InsertEntity<NewsCenter>(model);
        }
        public UserTableViewModel GetUserList(int pageSize, int pageIndex, string userName) 
        {
            return dal.GetUserList(pageSize, pageIndex, userName);
        }
        public int RemoveUsers(string[] userIDArray)
        {
            return dal.RemoveUsers(userIDArray);
        }
        public int BulkImportUser(List<User> list)
        {
            return dal.BulkImportUser(list);
        }
        public int UpdateUser(User user)
        {
            return dal.UpdateUser(user);
        }
        public int InsertUser(User model)
        {
            return dal.InsertEntity(model);
        }
        public int UpdatePwd(User user)
        {
            return dal.UpdatePwd(user);
        }
        public UserTableViewModel GetUserLists(string userName)
        {
            return dal.GetUserLists(userName);
        }
        public int GetUserByName(string userName)
        {
            return dal.FindAll<User>(m => m.UserName == userName).ToList().Count;
        }
        public int AddAnalysisData(AnalysisData model)
        {
            return dal.InsertEntity(model);
        }
        public int GetNewsCenter()
        {
            return dal.GetNewsCenter();
        }
        public AnalysisDataChartModel GetAllTabClickCount(string startTime, string endTime,int tabID)
        {
            return dal.GetAllTabClickCount(startTime,endTime,tabID);
        }
        public List<TabType> GetAllTabType()
        {
            return dal.FindAll<TabType>().ToList();
        }
        public List<Tab> GetTabByTTID(int tabTypeID)
        {
            return dal.FindAll<Tab>(m=>m.TTID == tabTypeID).ToList();
        }
        public List<Tab> GetAllTab()
        {
            return dal.FindAll<Tab>();
        }
        public int GetVisitPeopleCountByTabID(string startTime,string endTime,int tabID)
        {
            return dal.GetVisitPeopleCountByTabID(startTime,endTime,tabID);
        }
        public int GetAllClickCountByTabID(string startTime, string endTime, int tabID)
        {
            return dal.GetAllClickCountByTabID(startTime,endTime,tabID);
        }
        public Int64 GetAllStayTimeByTabID(string startTime, string endTime, int tabID)
        {
            return dal.GetAllStayTimeByTabID(startTime,endTime,tabID);
        }
        public bool GetPwd(string OldPwd, int UserID)
        {
            return dal.GetPwd(OldPwd,UserID);
        }
         //public async void LoadContext() 
         //{
         //    dal.FindAll<TabType>();
         //}
    }
}
