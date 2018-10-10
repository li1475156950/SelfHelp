using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SelfHelp.Models;
using SelfHelp.Common;
using SelfHelp.Models.ViewModel;
namespace SelfHelp.Contract
{
    [ServiceContract]
    public interface ISystemSettingsService
    {
        [OperationContract]
        string GetCompanyImages();
        [OperationContract]
        Company GetCompanyEntity();
        [OperationContract]
        int Insert(Company entity);
        [OperationContract]
        int Update(Company entity);
        [OperationContract]
        int UpdateCompany(Company entity);
        [OperationContract]
        NewsCenterTableViewModel GetNewsCenterList(int pageSize, int pageIndex, string titleContent);
        [OperationContract]
        List<NewsCenter> NewDetails();
        [OperationContract]
        List<User> GetUser();
        [OperationContract]
        int RemoveNews(string[] ncIDArray);
        [OperationContract]
        int AddNews(NewsCenter model);
        [OperationContract]
        UserTableViewModel GetUserList(int pageSize, int pageIndex, string userName);
        [OperationContract]
        int RemoveUsers(string[] userIDArray);
        [OperationContract]
        int BulkImportUser(List<User> list);
        [OperationContract]
        int UpdateUser(User user);
        [OperationContract]
        int InsertUser(User model);
        [OperationContract]
        int UpdatePwd(User user);
        [OperationContract]
        UserTableViewModel GetUserLists(string userName);
        [OperationContract]
        int GetUserByName(string userName);
        [OperationContract]
        int AddAnalysisData(AnalysisData model);
        [OperationContract]
        int GetNewsCenter();
        [OperationContract]
        AnalysisDataChartModel GetAllTabClickCount(string startTime, string endTime,int tabID);
        [OperationContract]
        List<TabType> GetAllTabType();
        [OperationContract]
        List<Tab> GetTabByTTID(int tabTypeID);
        [OperationContract]
        int GetVisitPeopleCountByTabID(string startTime, string endTime, int tabID);
        [OperationContract]
        int GetAllClickCountByTabID(string startTime, string endTime, int tabID);
        [OperationContract]
        Int64 GetAllStayTimeByTabID(string startTime, string endTime, int tabID);
        [OperationContract]
        List<Tab> GetAllTab();
         [OperationContract]
        bool GetPwd(string OldPwd, int UserID);
    }
}
