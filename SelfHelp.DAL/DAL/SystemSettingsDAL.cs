using SelfHelp.Common;
using SelfHelp.IDAL;
using SelfHelp.Models;
using SelfHelp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfHelp.Utility;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Collections;
namespace SelfHelp.DAL.DAL
{
    public class SystemSettingsDAL : DaoBase, ISystemSettingsDAL
    {
        public string GetCompanyImages()
        {
            return this.context.Companys.ToList()[0].ComImages;
        }
        public Company GetCompanyEntity()
        {
            return this.context.Companys.ToList()[0];
        }
        public int UpdateCompany(Company entity)
        {
            var set = context.Set<Company>();
            set.Attach(entity);
            context.Entry<Company>(entity).State = System.Data.Entity.EntityState.Modified;
            context.Entry(entity).Property(x => x.CreatePerson).IsModified = false;
            context.Entry(entity).Property(x => x.CreateTime).IsModified = false;
            if (entity.ComImages == null)
            {
                context.Entry(entity).Property(x => x.ComImages).IsModified = false;
            }
            return context.SaveChanges();
        }
        public NewsCenterTableViewModel GetNewsCenterList(int pageSize, int pageIndex, string titleContent)
        {
            var tempTable = new NewsCenterTableViewModel();
            var totalCount = context.NewsCenters.Where(m => m.NCTitle.Contains(titleContent)).ToList().Count;
            tempTable.PageCount = totalCount/pageSize;
            if (totalCount < pageSize)
            {
                tempTable.PageCount = 1;
            }
            if (totalCount % pageSize != 0&&totalCount>pageSize) 
            {
                tempTable.PageCount += 1;
            }
            SqlParameter[] param = { 
                new SqlParameter("@titleContent","%"+titleContent+"%")
                                   };
            var convertList = context.Database.SqlQuery<NewsCenter>("select * from NewsCenter where NCTitle like @titleContent order by CreateDateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            tempTable.ModelList = convertList;
            return tempTable;
        }

        public List<NewsCenter> NewDetails()
        {
            return context.NewsCenters.ToList();
        }
        public List<User> GetUser()
        {
            var list = (from a in context.Users
                        where a.RoleID == 1 || a.RoleID == 2
                        select a).ToList();
            return list;
        }
        public int RemoveNews(string[] ncIDArray)
        {
            for (int i = 0; i < ncIDArray.Length; i++)
            {
                var ncID = Convert.ToInt32(ncIDArray[i]);
                var entity = context.NewsCenters.FirstOrDefault(m => m.NCID == ncID);
                context.NewsCenters.Remove(entity);
            }
            return context.SaveChanges();
        }
        public UserTableViewModel GetUserList(int pageSize, int pageIndex, string userName)
        {
            var userTable = new UserTableViewModel();
            var totalCount = context.Users.Where(m => m.UserName.Contains(userName)).ToList().Count;
            userTable.PageCount = totalCount/pageSize;
            if (totalCount < pageSize)
            {
                userTable.PageCount = 1;
            }
            if (totalCount % pageSize != 0&&totalCount>pageSize) 
            {
                userTable.PageCount+=1;
            }
            SqlParameter[] param = { 
                new SqlParameter("@userName","%"+userName+"%")
                                   };
            var convertList = context.Database.SqlQuery<UserViewModel>("select UserID,UserIdentity,UserName,Pwd,BornDate,Job,Tel,Email,Sex,RoleName from [User] inner join [Role] on [Role].RoleID = [User].RoleID where UserName like @userName order by CreateTime desc", param).ToList().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            convertList.ForEach(m => { m.Age = SelfHelp.Utility.Common.CalculateAgeCorrect(m.BornDate, DateTime.Now); m.BornDateFormat = m.BornDate.ToString("yyyy-MM-dd"); });
            userTable.ModelList = convertList;
            return userTable;
        }
        public UserTableViewModel GetUserLists(string userName)
        {
            var userTable = new UserTableViewModel();
            SqlParameter[] param = { 
                new SqlParameter("@userName","%"+userName+"%")
                                   };
            var convertList = context.Database.SqlQuery<UserViewModel>("select ROW_NUMBER() over(order by CreateTime desc) as PageCount, UserID,UserIdentity,UserName,Pwd,BornDate,Job,Tel,Email,Sex,RoleName from [User] inner join [Role] on [Role].RoleID = [User].RoleID where UserName like @userName", param).ToList();
            convertList.ForEach(m => { m.Age = SelfHelp.Utility.Common.CalculateAgeCorrect(m.BornDate, DateTime.Now); m.BornDateFormat = m.BornDate.ToString("yyyy-MM-dd"); });
            userTable.ModelList = convertList;
            return userTable;
        }
        public int RemoveUsers(string[] userIDArray)
        {
            for (int i = 0; i < userIDArray.Length; i++)
            {
                var userID = Convert.ToInt32(userIDArray[i]);
                var entity = context.Users.FirstOrDefault(m => m.UserID == userID);
                context.Users.Remove(entity);
            }
            return context.SaveChanges();
        }
        public int BulkImportUser(List<User> list)
        {
            context.Users.AddRange(list);
            return context.SaveChanges();
        }
        public int UpdateUser(User user)
        {
            DbEntityEntry<User> entry = context.Entry<User>(user);
            entry.State = System.Data.Entity.EntityState.Unchanged;
            entry.Property("Sex").IsModified = true;
            entry.Property("BornDate").IsModified = true;
            entry.Property("Job").IsModified = true;
            entry.Property("Tel").IsModified = true;
            entry.Property("Email").IsModified = true;
            return context.SaveChanges();
        }
        public int UpdatePwd(User user)
        {
            DbEntityEntry<User> entry = context.Entry<User>(user);
            entry.State = System.Data.Entity.EntityState.Unchanged;
            entry.Property("Pwd").IsModified = true;
            return context.SaveChanges();
        }
        public int GetNewsCenter()
        {
            int pagecount;
            pagecount = context.NewsCenters.Count();
            return pagecount;
        }
        public AnalysisDataChartModel GetAllTabClickCount(string startTime, string endTime, int tabID)
        {
            SqlParameter[] paras = new SqlParameter[] {
                     new SqlParameter("@tabID",tabID),
                    };
            if (string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
            {
                return context.Database.SqlQuery<AnalysisDataChartModel>("select COUNT(TabID) as AllClickCount,AnalysisData.TabID,TabType.TTID as TabTypeID from AnalysisData" +
                                                                        " inner join Tab on Tab.TID = AnalysisData.TabID" +
                                                                        " inner join TabType on .Tab.TTID=TabType.TTID " +
                                                                        " where AnalysisData.TabID = @tabID" +
                                                                        " group by AnalysisData.TabID,TabType.TTID order by AnalysisData.TabID", paras).SingleOrDefault();
            }
            if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
            {
                var parasList = paras.ToList();
                var childPara = new SqlParameter("@startTime", startTime);
                parasList.Add(childPara);
                paras = parasList.ToArray();
                return context.Database.SqlQuery<AnalysisDataChartModel>("select COUNT(TabID) as AllClickCount,AnalysisData.TabID,TabType.TTID as TabTypeID from AnalysisData" +
                                                                        " inner join Tab on Tab.TID = AnalysisData.TabID" +
                                                                        " inner join TabType on .Tab.TTID=TabType.TTID " +
                                                                        " where AnalysisData.TabID = @tabID and (AnalysisData.CreateTime> @startTime) " +
                                                                        " group by AnalysisData.TabID,TabType.TTID order by AnalysisData.TabID", paras).SingleOrDefault();
            }
            if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                var parasList = paras.ToList();
                var childPara = new SqlParameter("@endTime", endTime);
                parasList.Add(childPara);
                paras = parasList.ToArray();
                return context.Database.SqlQuery<AnalysisDataChartModel>("select COUNT(TabID) as AllClickCount,AnalysisData.TabID,TabType.TTID as TabTypeID from AnalysisData" +
                                                                        " inner join Tab on Tab.TID = AnalysisData.TabID" +
                                                                        " inner join TabType on .Tab.TTID=TabType.TTID " +
                                                                        " where AnalysisData.TabID = @tabID and (AnalysisData.CreateTime< @endTime) " +
                                                                        " group by AnalysisData.TabID,TabType.TTID order by AnalysisData.TabID", paras).SingleOrDefault();
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                var parasList = paras.ToList();
                var childPara = new SqlParameter("@startTime", startTime);
                var childPara1 = new SqlParameter("@endTime", endTime);
                parasList.Add(childPara);
                parasList.Add(childPara1);
                paras = parasList.ToArray();
                return context.Database.SqlQuery<AnalysisDataChartModel>("select COUNT(TabID) as AllClickCount,AnalysisData.TabID,TabType.TTID as TabTypeID from AnalysisData" +
                                                                        " inner join Tab on Tab.TID = AnalysisData.TabID" +
                                                                        " inner join TabType on .Tab.TTID=TabType.TTID " +
                                                                        " where AnalysisData.TabID = @tabID and (AnalysisData.CreateTime between @startTime and @endTime) " +
                                                                        " group by AnalysisData.TabID,TabType.TTID order by AnalysisData.TabID", paras).SingleOrDefault();
            }
            return null;
        }
        public int GetVisitPeopleCountByTabID(string startTime, string endTime, int tabID)
        {
            SqlParameter[] paras = new SqlParameter[] {
                     new SqlParameter("@tabID",tabID)
                    };
            if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
            {
                var parasList = paras.ToList();
                var childPara = new SqlParameter("@startTime", startTime);
                parasList.Add(childPara);
                paras = parasList.ToArray();
                var tempList = context.Database.SqlQuery<string>("select CreatePeople from AnalysisData where AnalysisData.TabID = @tabID and AnalysisData.CreateTime>@startTime group by AnalysisData.CreatePeople", paras).ToList();
                return tempList.Count;
            }
            if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                var parasList = paras.ToList();
                var childPara = new SqlParameter("@endTime", endTime);
                parasList.Add(childPara);
                paras = parasList.ToArray();
                var tempList = context.Database.SqlQuery<string>("select CreatePeople from AnalysisData where AnalysisData.TabID = @tabID and AnalysisData.CreateTime<@endTime group by AnalysisData.CreatePeople", paras).ToList();
                return tempList.Count;
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                var parasList = paras.ToList();
                var childPara = new SqlParameter("@startTime", startTime);
                var childPara1 = new SqlParameter("@endTime", endTime);
                parasList.Add(childPara);
                parasList.Add(childPara1);
                paras = parasList.ToArray();
                var tempList = context.Database.SqlQuery<string>("select CreatePeople from AnalysisData where AnalysisData.TabID = @tabID and (AnalysisData.CreateTime between @startTime and @endTime) group by AnalysisData.CreatePeople", paras).ToList();
                return tempList.Count;
            }
            var tempCountList = context.Database.SqlQuery<string>("select CreatePeople from AnalysisData where AnalysisData.TabID = @tabID group by AnalysisData.CreatePeople", paras).ToList();
            return tempCountList.Count;
        }
        public int GetAllClickCountByTabID(string startTime, string endTime, int tabID)
        {
            SqlParameter[] paras = new SqlParameter[] {
                     new SqlParameter("@tabID",tabID)
                    };
            if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
            {
                var parasList = paras.ToList();
                var childPara = new SqlParameter("@startTime", startTime);
                parasList.Add(childPara);
                paras = parasList.ToArray();
                return context.Database.SqlQuery<int>("select COUNT(*) as Count from AnalysisData where AnalysisData.TabID = @tabID and AnalysisData.CreateTime>@startTime group by AnalysisData.TabID", paras).SingleOrDefault();
            }
            if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                var parasList = paras.ToList();
                var childPara = new SqlParameter("@endTime", endTime);
                parasList.Add(childPara);
                paras = parasList.ToArray();
                return context.Database.SqlQuery<int>("select COUNT(*) as Count from AnalysisData where AnalysisData.TabID = @tabID and AnalysisData.CreateTime<@endTime group by AnalysisData.TabID", paras).SingleOrDefault();
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                var parasList = paras.ToList();
                var childPara = new SqlParameter("@startTime", startTime);
                var childPara1 = new SqlParameter("@endTime", endTime);
                parasList.Add(childPara);
                parasList.Add(childPara1);
                paras = parasList.ToArray();
                return context.Database.SqlQuery<int>("select COUNT(*) as Count from AnalysisData where AnalysisData.TabID = @tabID and (AnalysisData.CreateTime between @startTime and @endTime) group by AnalysisData.TabID", paras).SingleOrDefault();
            }
            return context.Database.SqlQuery<int>("select COUNT(*) as Count from AnalysisData where AnalysisData.TabID = @tabID group by AnalysisData.TabID", paras).SingleOrDefault();
        }
        public Int64 GetAllStayTimeByTabID(string startTime, string endTime, int tabID)
        {
            SqlParameter[] paras = new SqlParameter[] {
                     new SqlParameter("@tabID",tabID)
                    };
            if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
            {
                var parasList = paras.ToList();
                var childPara = new SqlParameter("@startTime", startTime);
                parasList.Add(childPara);
                paras = parasList.ToArray();
                return context.Database.SqlQuery<Int64>("select sum(AnalysisData.StayTime) as Count from AnalysisData where AnalysisData.TabID = @tabID and AnalysisData.CreateTime>@startTime group by AnalysisData.TabID", paras).SingleOrDefault();
            }
            if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                var parasList = paras.ToList();
                var childPara = new SqlParameter("@endTime", endTime);
                parasList.Add(childPara);
                paras = parasList.ToArray();
                return context.Database.SqlQuery<Int64>("select sum(AnalysisData.StayTime) as Count from AnalysisData where AnalysisData.TabID = @tabID and AnalysisData.CreateTime<@endTime group by AnalysisData.TabID", paras).SingleOrDefault();
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                var parasList = paras.ToList();
                var childPara = new SqlParameter("@startTime", startTime);
                var childPara1 = new SqlParameter("@endTime", endTime);
                parasList.Add(childPara);
                parasList.Add(childPara1);
                paras = parasList.ToArray();
                return context.Database.SqlQuery<Int64>("select sum(AnalysisData.StayTime) as Count from AnalysisData where AnalysisData.TabID = @tabID and (AnalysisData.CreateTime between @startTime and @endTime) group by AnalysisData.TabID", paras).SingleOrDefault();
            }
            return context.Database.SqlQuery<Int64>("select sum(AnalysisData.StayTime) as Count from AnalysisData where AnalysisData.TabID = @tabID group by AnalysisData.TabID", paras).SingleOrDefault();
        }
        public bool GetPwd(string OldPwd, int UserID)
        {

            var list = (from a in context.Users where a.UserID==UserID && a.Pwd==OldPwd  select a.Pwd).ToList();
           

            if (list.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
