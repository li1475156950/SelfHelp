using SelfHelp.Common;
using SelfHelp.Models;
using SelfHelp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.IDAL
{
    public interface ISystemSettingsDAL : IRepository
    {
        string GetCompanyImages();
        Company GetCompanyEntity();
        int UpdateCompany(Company entity);
        NewsCenterTableViewModel GetNewsCenterList(int pageSize, int pageIndex, string titleContent);
        List<NewsCenter> NewDetails();
        List<User> GetUser();
        int RemoveNews(string[] ncIDArray);
        UserTableViewModel GetUserList(int pageSize, int pageIndex, string userName);
        int RemoveUsers(string[] userIDArray);
        int BulkImportUser(List<User> list);
        int UpdateUser(User user);
        int UpdatePwd(User user);
        UserTableViewModel GetUserLists(string userName);
        int GetNewsCenter();
        AnalysisDataChartModel GetAllTabClickCount(string startTime, string endTime,int tabID);
        int GetVisitPeopleCountByTabID(string startTime, string endTime, int tabID);
        int GetAllClickCountByTabID(string startTime, string endTime, int tabID);
        Int64 GetAllStayTimeByTabID(string startTime, string endTime, int tabID);
        bool GetPwd(string OldPwd, int UserID);
    }
}
